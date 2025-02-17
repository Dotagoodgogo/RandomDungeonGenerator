using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public int width = 10, height = 6;
    public int maxRooms = 10;
    public GameObject[] roomPrefabs;
    public GameObject bossRoomPrefab;
    public int RoomDistance = 1;
    private List<Vector2Int> roomPositions = new List<Vector2Int>();

    private int[,] grid;
    private Vector2Int startPos;

    void Start()
    {
        GenerateMap();
        GenerateRooms();
        PrintGrid();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RegenerateDungeon();
        }
    }

    void RegenerateDungeon()
    {
        foreach (GameObject room in GameObject.FindGameObjectsWithTag("Room"))
        {
            Destroy(room);
        }

        grid = new int[width, height];
        roomPositions.Clear();
        GenerateMap();
        GenerateRooms();
        PrintGrid();
    }

    void GenerateMap()
    {
        grid = new int[width, height];
        startPos = new Vector2Int(width / 2, height / 2);
        grid[startPos.x, startPos.y] = 1;
        GenerateMainPath();
        GenerateExtraRooms();
    }

    void GenerateMainPath()
    {
        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        Vector2Int currentPos = startPos;
        roomPositions.Add(currentPos);
        queue.Enqueue(currentPos);
        int roomsCreated = 1;

        Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };

        Vector2Int bossPos = currentPos;
        int maxDistance = 0;
        Dictionary<Vector2Int, int> distanceMap = new Dictionary<Vector2Int, int>();
        distanceMap[currentPos] = 0;

        while (roomsCreated < maxRooms * 0.6f && queue.Count > 0)
        {
            currentPos = queue.Dequeue();
            List<Vector2Int> validDirections = new List<Vector2Int>();

            foreach (Vector2Int dir in directions)
            {
                Vector2Int newPos = currentPos + dir;
                if (IsValidPosition(newPos))
                {
                    validDirections.Add(newPos);
                }
            }

            if (validDirections.Count > 0)
            {
                Vector2Int nextPos = validDirections[Random.Range(0, validDirections.Count)];
                grid[nextPos.x, nextPos.y] = 1;
                queue.Enqueue(nextPos);
                roomPositions.Add(nextPos);
                roomsCreated++;

                int distance = distanceMap[currentPos] + 1;
                distanceMap[nextPos] = distance;

                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    bossPos = nextPos;
                }
            }
        }

        grid[bossPos.x, bossPos.y] = 2;
        roomPositions.Add(bossPos);
        Debug.Log($"Boss Room placed at: {bossPos.x}, {bossPos.y}, Distance: {maxDistance}");
    }

    void GenerateExtraRooms()
    {
        List<Vector2Int> possibleRooms = new List<Vector2Int>();
        Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };

        for (int x = 1; x < width - 1; x++)
        {
            for (int y = 1; y < height - 1; y++)
            {
                if (grid[x, y] == 1)
                {
                    foreach (Vector2Int dir in directions)
                    {
                        Vector2Int newPos = new Vector2Int(x, y) + dir;

                        if (grid[newPos.x, newPos.y] == 0 && HasOnlyOneNeighbor(newPos))
                        {
                            possibleRooms.Add(newPos);
                        }
                    }
                }
            }
        }

        int extraRoomsToAdd = maxRooms / 2;
        while (extraRoomsToAdd > 0 && possibleRooms.Count > 0)
        {
            int index = Random.Range(0, possibleRooms.Count);
            Vector2Int chosenRoom = possibleRooms[index];

            if (HasOnlyOneNeighbor(chosenRoom))
            {
                grid[chosenRoom.x, chosenRoom.y] = 1;
                roomPositions.Add(chosenRoom);
                extraRoomsToAdd--;
            }

            possibleRooms.RemoveAt(index);
        }

        Debug.Log("额外房间生成完毕");
    }

    bool CanPlaceExtraRoom(Vector2Int pos)
    {
        if (pos.x < 0 || pos.x >= width || pos.y < 0 || pos.y >= height)
            return false;

        Vector2Int bossPos = FindBossRoomPosition();
        int originalPathLength = FindPathLength(startPos, bossPos);

        grid[pos.x, pos.y] = 1;
        int newPathLength = FindPathLength(startPos, bossPos);
        grid[pos.x, pos.y] = 0;

        return newPathLength == originalPathLength;
    }

    Vector2Int FindBossRoomPosition()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (grid[x, y] == 2) return new Vector2Int(x, y);
            }
        }
        return new Vector2Int(-1, -1);
    }

    int FindPathLength(Vector2Int start, Vector2Int goal)
    {
        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        Dictionary<Vector2Int, int> distanceMap = new Dictionary<Vector2Int, int>();

        queue.Enqueue(start);
        distanceMap[start] = 0;

        Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };

        while (queue.Count > 0)
        {
            Vector2Int current = queue.Dequeue();
            int currentDistance = distanceMap[current];

            if (current == goal) return currentDistance;

            foreach (Vector2Int dir in directions)
            {
                Vector2Int newPos = current + dir;
                if (newPos.x < 0 || newPos.x >= width || newPos.y < 0 || newPos.y >= height)
                    continue;

                if (grid[newPos.x, newPos.y] == 1 && !distanceMap.ContainsKey(newPos))
                {
                    distanceMap[newPos] = currentDistance + 1;
                    queue.Enqueue(newPos);
                }
            }
        }
        return int.MaxValue;
    }

    bool HasOnlyOneNeighbor(Vector2Int pos)
    {
        int neighbors = 0;
        Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };

        foreach (Vector2Int dir in directions)
        {
            Vector2Int neighbor = pos + dir;
            if (neighbor.x >= 0 && neighbor.x < width && neighbor.y >= 0 && neighbor.y < height)
            {
                if (grid[neighbor.x, neighbor.y] == 1 || grid[neighbor.x, neighbor.y] == 2)
                {
                    neighbors++;
                    if (neighbors > 1) return false;
                }
            }
        }
        return neighbors == 1;
    }

    bool IsValidPosition(Vector2Int pos)
    {
        if (pos.x <= 0 || pos.x >= width - 1 || pos.y <= 0 || pos.y >= height - 1) return false;
        if (grid[pos.x, pos.y] == 1 || grid[pos.x, pos.y] == 2) return false;

        int neighbors = 0;
        if (grid[pos.x + 1, pos.y] > 0) neighbors++;
        if (grid[pos.x - 1, pos.y] > 0) neighbors++;
        if (grid[pos.x, pos.y + 1] > 0) neighbors++;
        if (grid[pos.x, pos.y - 1] > 0) neighbors++;

        return neighbors == 1;
    }

    void GenerateRooms()
    {
        foreach (Vector2Int roomPos in roomPositions)
        {
            Vector2Int gridCenter = new Vector2Int(width / 2, height / 2);
            Vector3 worldPos = new Vector3(roomPos.x - gridCenter.x, roomPos.y - gridCenter.y, 0);
            GameObject room = Instantiate(roomPrefabs[0], worldPos, Quaternion.identity);
            if (worldPos == new Vector3(0, 0, 0))
            {
                ChangeRoomColor(room, Color.blue);
            }
            else if (grid[roomPos.x, roomPos.y] == 2)
            {
                ChangeRoomColor(room, Color.red);
            }

            HideUnnecessaryDoors(room, roomPos);
        }
    }

    void HideUnnecessaryDoors(GameObject room, Vector2Int position)
    {
        Transform doorsParent = room.transform.Find("Doors");
        if (doorsParent == null) return;

        foreach (Transform door in doorsParent)
        {
            Vector2 localPos = door.localPosition.normalized;

            bool shouldHide = false;
            if (localPos == Vector2.up && (position.y + 1 >= height || grid[position.x, position.y + 1] == 0))
                shouldHide = true;
            if (localPos == Vector2.down && (position.y - 1 < 0 || grid[position.x, position.y - 1] == 0))
                shouldHide = true;
            if (localPos == Vector2.left && (position.x - 1 < 0 || grid[position.x - 1, position.y] == 0))
                shouldHide = true;
            if (localPos == Vector2.right && (position.x + 1 >= width || grid[position.x + 1, position.y] == 0))
                shouldHide = true;

            if (shouldHide)
                door.gameObject.SetActive(false);
        }
    }

    void ChangeRoomColor(GameObject room, Color color)
    {
        Transform baseTransform = room.transform.Find("Base");
        if (baseTransform != null)
        {
            SpriteRenderer sr = baseTransform.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = color;
            }
            else
            {
                Debug.LogWarning("SpriteRenderer not found!");
            }
        }
        else
        {
            Debug.LogWarning("Base found!");
        }
    }

    void PrintGrid()
    {
        StringBuilder sb = new StringBuilder();
        for (int y = height - 1; y >= 0; y--)
        {
            for (int x = 0; x < width; x++)
            {
                sb.Append(grid[x, y] + " ");
            }
            sb.AppendLine();
        }
        Debug.Log(sb.ToString());
    }
}