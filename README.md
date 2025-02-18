# 🏰 Procedural Dungeon Generation
## 🎮 Play the Game!  

👉 **[Try me](https://dotagood.itch.io/randomdungeongenerator)** 

## 📜 Introduction  
This project explores **procedural dungeon generation**, inspired by *The Binding of Isaac* and similar roguelike games.  
<div align = "center">
   <img src="https://github.com/user-attachments/assets/188ff806-9b32-4012-94a7-b938e0b46925" width="500">
</div>

---

## 🎮 Inspiration  
In January, I spent over **200 hours** playing *The Binding of Isaac*, completely immersed in the **randomness and replayability** of dungeon exploration.  




However, after finishing the game, I was left wondering:  
*"How are these dungeons generated?"*  

During my **CTIN 544** course, my professor demonstrated how Excel could be used for game design. In a game called *Minotaur*, he visualized an entire map using Excel, representing different terrains with **numerical values**.  

👉 **[View the Sample](https://docs.google.com/spreadsheets/d/1Gni2NLv4U_fvIccR21YbUcfSlahaI2mznOcw0Enf8Ko/edit?gid=1892812712#gid=1892812712)** 

That moment sparked an idea:  
- **The map is really cool.** 
- **What algorithm could I use to generate such a dungeon map?**  
 
---

## 🔍 Development Process  

### 🛠 **Step 1: Researching Procedural Generation**  
I explored various videos and articles explaining dungeon generation techniques. However, I found most to be **either too simple or overly complex**, so I decided to start coding based on my own logic.


### 🏠 **Step 2: Designing the Room Structure**  
To replicate *The Binding of Isaac* dungeon style, I created a **base room prefab** in Unity, consisting of:  
- 🏠 **A floor tile**  
- 🚪 **Four doors** (up, down, left, right)  
- 🧱 **Walls enclosing the room**
<p align="center">
    <img src="https://github.com/user-attachments/assets/3fcd269d-2106-44e7-8759-12809babfc31" width="300">
    <img src="https://github.com/user-attachments/assets/be3db3a2-0d28-4d67-a282-1631f4da93c7" width="300">
</p>



This served as the foundation for all dungeon rooms.

### 🔄 **Step 3: Implementing the Algorithm**  
I divided the dungeon generation into **three key phases**:  
1. **Generating the Main Path**  
   - Implemented a **random walk algorithm** to create a **primary path** from the **starting room to the boss room**.  
   - Used a **matrix/grid** to track the dungeon layout:  
     - `1` = Normal Room  
     - `2` = Boss Room

<div align = "center">
   <img src="https://github.com/user-attachments/assets/d9b5c0b2-f131-4024-8e31-4fe36085a650" width="500">
</div>

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
<div align = "center">
   <img src="https://github.com/user-attachments/assets/c350416e-f4d3-48fe-97e0-2600eb502a40" width="500">
</div>


4. **Performance Optimization**  
   - Improve algorithm efficiency for **faster and smoother dungeon generation**.  

---

## 🌍 Beyond Dungeon 

Once this procedural system is refined, I want to **expand it to other game genres**:  
- **2D Side-Scrolling Dungeon Games** (*e.g., Dead Cells*)
- **3D Procedural Dungeon Games** (*e.g., Windblown*) 
- **Randomly Generated FPS Maps** (*What if CS:GO or Valorant had procedurally generated maps?*)
- > 🤔 *How would procedural FPS maps impact game balance and strategy?*  
> - Would it create **fresh gameplay experiences** every match?  
> - How would it **affect competitive fairness**?   
<div align = "center">
   <img src="https://github.com/user-attachments/assets/e87d3be3-32eb-4029-bc5a-e3f8f3885612" width="500">
   <img src="https://github.com/user-attachments/assets/e2c49e24-f822-440e-a10f-99adc04a9699" width="500">
   <img src="https://cdn1.epicgames.com/offer/cbd5b3d310a54b12bf3fe8c41994174f/EGS_VALORANT_RiotGames_S1_2560x1440-1dade6e50659c8e05805cb150b349e56" width="500">
   <img src="https://www.tobyscs.com/files/de_train-map-callouts.jpg" width="500">
</div>
 

---

 




