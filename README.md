# 🏰 **Dungeon Game Procedural Generation**

## **📜 Introduction**
This project explores the dungeon map generation methods inspired by *The Binding of Isaac* and other rogue-like games.

## **💡 Inspiration**
In January, I played *The Binding of Isaac* for over **200 hours**, completely immersed in its **procedural dungeon generation**. The randomness made every run feel fresh and exciting. However, after finishing the game, I wondered:  
*"What would it take to create such a complex system?"*

During my **CTIN 544** class, my professor demonstrated **Excel-based game design** using a game called *Minotaur*. Different numbers in Excel represented various terrains, allowing for **easy visualization** of game maps. When I saw this, I had a realization:  
*"How can I create a random map like this programmatically?"*  

Since **procedural generation is the heart of dungeon crawlers**, I decided to implement my own **random dungeon generator** as part of my coursework.

---

## **🛠 Implementation Steps**
### **1️⃣ Researching Procedural Dungeon Generation**
I watched various tutorials and read articles on **random map generation**. However, I found most explanations either **too simple or too complex**, so I **started coding from scratch** using my own logic.

### **2️⃣ Designing the Room Structure**
To create an *Isaac*-like dungeon, I built a **base room prefab** with the following elements:
- 🏠 **A floor tile**
- 🚪 **Four doors** (up, down, left, right)
- 🧱 **Walls surrounding the room**

This serves as the **foundation** for all rooms in the dungeon.

### **3️⃣ Writing the Dungeon Generation Algorithm**
I divided the procedural generation process into **three key phases**:

#### **🛤 Phase 1: Generating the Main Pathway**
- Used a **random walk algorithm** to generate a **linear path from the spawn room to the boss room**.
- Stored dungeon layout in a **matrix**, where:
  - `1` = **Normal room**
  - `2` = **Boss room**

#### **🌿 Phase 2: Adding Side Branches**
- To create **more exploration paths**, I added **extra rooms branching from the main path**.
- **Constraint:** Each newly generated room **must have exactly one connecting door**, preventing isolated areas.

#### **🏗 Phase 3: Placing Rooms and Managing Doors**
- Tracked **room positions** in a list.
- A function **checks adjacent rooms** and **hides unnecessary doors**, ensuring proper connectivity.
- Converted **matrix data into world coordinates**, **starting from the center** and expanding outward.

---

## **🎮 Play the Game!**
You can try the **procedural dungeon generator** here:  
👉 [**Play on Itch.io**](https://dotagood.itch.io/randomdungeongenerator)


bit.ly/StructuredData-Minotaur


