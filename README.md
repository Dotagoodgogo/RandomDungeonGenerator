# Dungeon Game Procedural Generation

## Introduction
This project explores the map generation techniques used in *The Binding of Isaac*.

![Dungeon Map Example](https://upload.wikimedia.org/wikipedia/commons/7/7d/Procedural_Map_Example.png)

## Inspiration
In January, I spent over 200 hours playing *The Binding of Isaac*. I was deeply fascinated by the sense of randomness in dungeon games. However, once I finished the game, I was left with a simple realization: it was an enjoyable experience, but such a large-scale production required a massive team.

During my CTIN544 class, the professor introduced the use of Excel in game design. While working on the game *Minotaur*, he used Excel to visualize the entire map by assigning different numbers to represent various terrains. Seeing the map displayed in Excel, I started wondering: what algorithm could I use to generate such a map randomly? Then, I had a sudden flashback to *The Binding of Isaac* and its room generation. I realized that this idea could be exchanged for one of the assignments in my CTIN544 course—an excellent trade.

## Development Steps

### Step 1: Research
I watched several videos and read articles about dungeon procedural generation. However, many implementations were either too simple or overly complex. Based on my own ideas, I decided to start coding right away.

![Research Process](https://upload.wikimedia.org/wikipedia/commons/6/60/Research_Process.png)

### Step 2: Creating a Basic Room
To simulate an Isaac-like room, I set up a *GameObject* consisting of:
- A floor
- Four doors
- Walls

This completed the basic room design.

### Step 3: Implementing the Algorithm
The dungeon generation consists of three steps:

![Dungeon Algorithm Flow](https://upload.wikimedia.org/wikipedia/commons/3/3a/Flowchart.png)

1. **Generating the Main Path:**
   - I used *random walk* to create a pathway from the spawn room to the boss room.
   - A matrix records the map layout:
     - Normal rooms are labeled as `1`
     - The boss room is labeled as `2`

2. **Adding Branches:**
   - Additional rooms are generated branching off the main path.
   - Newly created rooms always have a single entrance.

3. **Finalizing Room Generation:**
   - The function checks surrounding rooms and hides unnecessary doors.
   - The matrix data is converted into on-screen coordinates, starting from the screen's center and expanding outward.

## Future Enhancements
This dungeon generation model is an early prototype. My goal is to make it user-friendly, meaning that developers should be able to integrate it into their games with minimal adjustments. Here are some planned improvements:

1. **Parameter Adjustments:**
   - Allow players to tweak map parameters easily.

2. **Varied Room Modules:**
   - Introduce larger and irregularly shaped rooms.

3. **Additional Room Types:**
   - Implement secret rooms, treasure rooms, and probability-based room generation.

4. **Optimization:**
   - Improve algorithm efficiency to generate maps faster.

## Expanding Beyond Traditional Dungeons
Once these improvements are complete, I want to explore other dungeon generation techniques, such as:
- 2D dungeon-based *Metroidvania* games (*Dead Cells*)
- 3D dungeon exploration games (*The Legend of Zelda: The Wind Waker*)

![Metroidvania Example](https://upload.wikimedia.org/wikipedia/commons/5/58/Metroidvania_Map.png)

## A Bold Idea: Randomly Generated FPS Maps
I noticed that some *Counter-Strike* maps share structured layouts. What if maps in FPS games like *Counter-Strike* or *Valorant* were procedurally generated? How would randomized maps impact the overall gameplay experience?

![FPS Map Example](https://upload.wikimedia.org/wikipedia/commons/d/d2/FPS_Level_Design.png)

---

This document outlines my initial thoughts on procedural dungeon generation and future exploration. Stay tuned for further updates!



