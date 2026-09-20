<div align="center">

# 🐦 Flappy Bird — Unity Edition

### *My very first Unity Engine project — built with passion & a little help from Gemini AI* 🤖✨

<br/>

[![Unity](https://img.shields.io/badge/Engine-Unity-000000?style=for-the-badge&logo=unity&logoColor=white)](https://unity.com/)
[![C#](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Gemini AI](https://img.shields.io/badge/Powered%20by-Gemini%20AI-4285F4?style=for-the-badge&logo=google&logoColor=white)](https://gemini.google.com/)
[![Status](https://img.shields.io/badge/Status-Playable-brightgreen?style=for-the-badge)](#)
[![First Project](https://img.shields.io/badge/This%20is%20my-1st%20Unity%20Project-ff6b35?style=for-the-badge)](#)

</div>

---

## 🎮 About This Game

**Flappy Bird — Unity Edition** is a faithful recreation of the legendary 2013 mobile game, **Flappy Bird**, built from the ground up using the **Unity Game Engine**. The classic gameplay is simple yet brutally challenging — press `Space` to flap the bird's wings, navigate through an endless stream of pipes, and survive as long as you can!

> 🌟 **What makes this special?** This is my **very first ever Unity project**. I had zero prior game-development experience before starting this. Armed with curiosity, determination, and the guidance of **Google Gemini AI**, I built this game piece by piece — and it actually works beautifully! 🎉

---

## 🤖 Built with Gemini AI

One of the most exciting parts of this journey was learning how to leverage **Google Gemini AI** as a coding assistant and mentor throughout the entire development process.

Gemini helped me with:
- 🧠 **Understanding Unity concepts** like MonoBehaviour, Rigidbody2D, and Colliders
- 🐛 **Debugging tricky issues** like the difference between trigger vs collision detection
- 📐 **Designing the game architecture** — how scripts talk to each other
- 🎨 **Generating game assets** — some sprites in this project were even Gemini-generated! *(check `Gemini_Generated_Image` in `Assets/Sprites/`)*
- 📖 **Learning C# on the fly** — writing clean, working code from scratch
- ⚡ **Optimizing game performance** — targeting 60 FPS from day one

> *"I didn't just copy-paste code — I used Gemini as a teacher, asking WHY things work the way they do. This project is proof that AI and human curiosity together can build something great."*

---

## 🕹️ How to Play

| Action | Control |
|--------|---------|
| 🐦 Flap / Jump | `Space Bar` |
| ▶️ Start Game | Click the **Play Button** |
| 🔄 Restart | Click **Play Button** after Game Over |

### 🎯 Objective
- Guide the bird through the gaps between the green pipes
- **Every pipe pair you pass = +1 Score**
- Don't hit the pipes or the ground — **Game Over!**
- Beat your high score and keep improving! 🏆

---

## 🏗️ Project Structure

```
Flappy Bird/
│
├── 📁 Assets/
│   ├── 🖼️  Sprites/          → All game graphics (bird, pipes, background, UI)
│   ├── 📜  Scripts/          → All C# game logic (5 scripts)
│   ├── 🎨  Materials/        → Unity materials for rendering
│   ├── 🔤  Fonts/            → Typography assets
│   ├── 🧱  Mould_For_Pipe/   → Pipe prefab mould
│   ├── 🎬  Scenes/           → The main game scene
│   └── ⚙️  Settings/         → Unity input & render settings
│
├── 📦 Packages/              → Unity package dependencies
├── ⚙️  ProjectSettings/      → Unity project configuration
└── 📄 README.md              → You're reading it! 😊
```

---

## 📜 The Scripts — Game Logic Breakdown

This game is powered by **5 C# scripts**, each with a specific, focused role:

### 🐦 `BirdController.cs`
> Controls the player character — the bird!

- Handles **Space bar input** using Unity's new Input System
- Applies **upward velocity** to simulate a flap/jump
- Drives a **3-frame wing animation** loop using `InvokeRepeating`
- Detects **trigger collisions** to signal Game Over or Score point events

```csharp
// Core flap mechanic — clean and instant!
rb.linearVelocity = new Vector2(0, flapStrength);
```

---

### 🎮 `GameManager.cs`
> The brain of the game — manages all game states.

- Controls **Play / Pause / Game Over** state transitions
- Manages the **score counter** with live UI text updates
- On restart: resets bird position, rotation, and physics velocity to zero
- Destroys all existing pipes on the screen for a clean fresh start
- Locks the game to **60 FPS** for smooth, consistent gameplay

```csharp
Application.targetFrameRate = 60; // Silky smooth from the start!
```

---

### 🌿 `Pipes.cs`
> Moves each pipe pair from right to left.

- Every pipe continuously moves **leftward** at a configurable speed
- Auto-**destroys itself** when it scrolls off screen (`x < -12`)
- Keeps the game clean and prevents memory leaks

```csharp
transform.position += Vector3.left * speed * Time.deltaTime;
```

---

### 🏭 `Spawner.cs`
> The endless pipe factory!

- Spawns new pipe pairs at a **regular interval** (every 2 seconds)
- Randomly offsets each pipe's **vertical position** for endless variety
- Uses `InvokeRepeating` for reliable, framerate-independent spawning

```csharp
pipes.transform.position += Vector3.up * Random.Range(lowerLimit, upperLimit);
```

---

### 🌄 `BackgroundMovement.cs`
> Creates the illusion of endless flight.

- Scrolls the background texture using **UV texture offset animation**
- Runs every frame for a seamless, looping parallax scroll effect
- Makes the world feel alive even though the bird stays center-screen!

```csharp
meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
```

---

## ✨ Features

- ✅ Smooth **60 FPS** target gameplay
- ✅ Animated **3-frame bird wing flapping**
- ✅ **Infinitely scrolling** background & ground
- ✅ **Randomly positioned pipes** for endless replayability
- ✅ **Live score tracking** with on-screen UI
- ✅ **Game Over screen** with instant restart
- ✅ Clean **state management** (menu → playing → game over)
- ✅ Gemini AI-generated **custom sprite artwork**
- ✅ Physics-based bird movement with **Rigidbody2D**
- ✅ **Trigger-based collision** system (precise and lag-free!)

---

## 🚀 Getting Started

### Prerequisites
- [Unity Hub](https://unity.com/download) installed
- **Unity 6.x** or later

### Run the Game
1. **Clone** this repository:
   ```bash
   git clone https://github.com/H-P-Jadeja/Flappy-Bird.git
   ```
2. Open **Unity Hub** → Click **"Add project from disk"**
3. Select the cloned `Flappy-Bird` folder
4. Unity will import all assets automatically
5. Open `Assets/Scenes/` and load the main scene
6. Hit the ▶️ **Play** button in the Unity Editor
7. Press `Space` to flap — **good luck!** 🍀

---

## 🌱 My Learning Journey

This project represents a **milestone** in my development journey. Starting with absolutely no Unity experience, here's what I learned building this game:

| Concept | What I Learned |
|---------|---------------|
| 🎮 Unity Basics | Scenes, GameObjects, Components, Prefabs |
| 📜 C# Scripting | MonoBehaviour lifecycle (`Update`, `Awake`, `Start`) |
| ⚙️ Physics | Rigidbody2D, velocity, gravity, colliders |
| 🎯 Collision System | `OnCollisionEnter2D` vs `OnTriggerEnter2D` |
| 🎨 2D Rendering | SpriteRenderer, Materials, UV texture scrolling |
| 🏗️ Game Architecture | Inter-script communication with `FindAnyObjectByType<T>()` |
| ⏱️ Timing | `InvokeRepeating`, `Time.deltaTime`, `Time.timeScale` |
| 🤖 AI-Assisted Dev | Using Gemini AI as a learning partner & code mentor |

---

## 🙏 Acknowledgements

| Who | Why |
|-----|-----|
| **Dong Nguyen** | Original creator of Flappy Bird (2013) — the game that started it all |
| **Google Gemini AI** | My AI mentor who guided me through every single step of this project |
| **Unity Technologies** | For the incredible (and free!) game engine that made this possible |
| **The Unity Community** | For the amazing tutorials, forums, and documentation |

---

## 👨‍💻 About the Developer

**H.P. Jadeja** — A developer who took the leap into game development with zero prior experience and built a fully working game with the power of curiosity + Gemini AI. This is just the beginning! 🚀

> *"Every expert was once a beginner. This Flappy Bird clone is my 'Hello, World!' to the game development universe."*

---

<div align="center">

### ⭐ If you liked this project, please give it a star! ⭐

**Made with ❤️, Unity, C#, and a LOT of help from 🤖 Gemini AI**

[![GitHub](https://img.shields.io/badge/GitHub-H--P--Jadeja-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/H-P-Jadeja/Flappy-Bird)
[![Gemini](https://img.shields.io/badge/AI%20Partner-Google%20Gemini-4285F4?style=for-the-badge&logo=google&logoColor=white)](https://gemini.google.com/)
[![Unity](https://img.shields.io/badge/Built%20With-Unity%20Engine-000000?style=for-the-badge&logo=unity&logoColor=white)](https://unity.com/)

<br/>

*🐦 Keep Flapping, Keep Learning! 🐦*

*© 2026 H.P. Jadeja — First Unity Project*

</div>
