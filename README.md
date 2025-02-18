# RandomDungeonGenerator
 
## 🎮 Play the Game!
[Click here to play on itch.io!](https://dotagood.itch.io/randomdungeongenerator)


Dungeon Game Procedural Generation

Introduction

This project explores the dungeon map generation methods used in The Binding of Isaac and other rogue-like games.

Inspiration

In January, I spent over 200 hours playing The Binding of Isaac, deeply captivated by the randomness and unpredictability of dungeon crawlers. However, after finishing the game, my biggest takeaway was simply how fun it was. Creating a game of this scale, though, clearly requires a large development team.

This realization sparked an idea: How could I replicate a similar procedural generation system on my own?

During my CTIN 544 class, the professor introduced the concept of using Excel for game design. While working on a game called Minotaur, he demonstrated how different numbers in an Excel sheet could represent different terrains in the game. When I saw the map visualized in Excel, I started wondering:
“What kind of algorithm could randomly generate such a map?”

Then, it hit me—random generation is at the core of dungeon games. My mind immediately flashed back to The Binding of Isaac. What if I could develop my own procedural dungeon generator as part of my coursework? I realized this would be an excellent trade for a CTIN 544 assignment.

---
Implementation Steps

Step 1: Researching Procedural Dungeon Generation

I watched several videos and read articles on procedural generation techniques, but I found most approaches either too simple or overly complex. So, instead of overanalyzing, I decided to dive right in and start coding based on my own understanding.

Step 2: Designing the Room Structure

To create an Isaac-like dungeon, I designed a base GameObject that includes:
	•	A floor tile
	•	Four doors (up, down, left, and right)
	•	Walls enclosing the room

This served as the basic template for every dungeon room.

Step 3: Writing the Code

I divided the implementation into three key phases:

Phase 1: Generating the Main Pathway
	•	I used a random walk algorithm to generate a linear path from the spawn room to the boss room.
	•	A matrix records the dungeon layout:
	•	1 represents a normal room.
	•	2 represents the boss room.

Phase 2: Adding Side Branches
	•	To make the dungeon more diverse, I generated extra rooms branching off the main path.
	•	Constraint: Each newly generated room must have exactly one door (ensuring a structured and fair layout).

Phase 3: Placing Rooms and Managing Doors
	•	I recorded the exact position of each room.
	•	A function checks neighboring rooms and hides unnecessary doors, ensuring correct connectivity.
	•	The matrix data is then mapped to world coordinates, with room placement originating from the screen’s center and expanding outward.


