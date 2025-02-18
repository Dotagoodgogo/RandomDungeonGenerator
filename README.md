# 🏰 Procedural Dungeon Generation

## 📜 Introduction  
This project explores **procedural dungeon generation**, inspired by *The Binding of Isaac* and similar roguelike games.  

---

## 🎮 Inspiration  
In January, I spent over **200 hours** playing *The Binding of Isaac*, completely immersed in the **randomness and replayability** of dungeon exploration.  

However, after finishing the game, I was left wondering:  
*"How are these dungeons generated?"*  

During my **CTIN 544** course, my professor demonstrated how Excel could be used for game design. In a game called *Minotaur*, he visualized an entire map using Excel, representing different terrains with **numerical values**.  

That moment sparked an idea:  
- **What algorithm could I use to generate such a dungeon map?**  
- **Isn’t procedural generation the core of dungeon crawlers?**  

With these thoughts, I **traded one of my CTIN 544 assignments** for this project, exploring procedural dungeon generation.

---

## 🔍 Development Process  

### 🛠 **Step 1: Researching Procedural Generation**  
I explored various videos and articles explaining dungeon generation techniques. However, I found most to be **either too simple or overly complex**, so I decided to start coding based on my own logic.

### 🏠 **Step 2: Designing the Room Structure**  
To replicate *The Binding of Isaac* dungeon style, I created a **base room prefab** in Unity, consisting of:  
- 🏠 **A floor tile**  
- 🚪 **Four doors** (up, down, left, right)  
- 🧱 **Walls enclosing the room**  

This served as the foundation for all dungeon rooms.

### 🔄 **Step 3: Implementing the Algorithm**  
I divided the dungeon generation into **three key phases**:  
1. **Generating the Main Path**  
   - Implemented a **random walk algorithm** to create a **primary path** from the **starting room to the boss room**.  
   - Used a **matrix/grid** to track the dungeon layout:  
     - `1` = Normal Room  
     - `2` = Boss Room  

2. **Adding Side Paths**  
   - Ensured that new rooms had only **one entrance** to avoid dead ends and create a structured flow.  

3. **Room Placement & Door Management**  
   - Converted **matrix data into actual game objects** in Unity.  
   - Used a **function to detect surrounding rooms** and automatically **hide unnecessary doors**.  

---

## 🚀 Future Enhancements  

This procedural dungeon generator is just the **first prototype**. My ultimate goal is to create an **easy-to-use** system where developers can **adjust parameters** and integrate it seamlessly into their own games.

### 🔹 **Next Steps**
1. **Adjustable Dungeon Parameters**  
   - Allow developers to control **room size, layout density, and difficulty scaling**.  

2. **Expanded Room Variety**  
   - Introduce **larger rooms** and **irregularly shaped layouts** for more dynamic dungeon designs.  

3. **Special Room Types**  
   - 🎁 **Treasure Rooms**  
   - 🏚 **Secret Rooms**  
   - 🔥 **Probability-based Encounters**  

4. **Performance Optimization**  
   - Improve algorithm efficiency for **faster and smoother dungeon generation**.  

---

## 🌍 Beyond Dungeon Crawlers  

Once this procedural system is refined, I want to **expand it to other game genres**:  
- **2D Side-Scrolling Dungeon Games** (*e.g., Dead Cells*)  
- **3D Procedural Dungeon Games** (*e.g., The Legend of Zelda-inspired dungeons*)  
- **Randomly Generated FPS Maps** (*What if CS:GO or Valorant had procedurally generated maps?*)  

> 🤔 *How would procedural FPS maps impact game balance and strategy?*  
> - Would it create **fresh gameplay experiences** every match?  
> - How would it **affect competitive fairness**?  

---

## 🎮 Play the Game!  

👉 **[Play on Itch.io](https://dotagood.itch.io/randomdungeongenerator)**  




