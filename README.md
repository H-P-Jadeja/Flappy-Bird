# Flappy Bird – Unity Edition

A 2D recreation of the classic Flappy Bird game, built with **Unity 6** and **C#**. This is my first Unity project, developed as my individual Capstone Project for the ISD course.

[![Play Live](https://img.shields.io/badge/Play_Live-Vercel-ff4757?style=for-the-badge&logo=vercel&logoColor=white)](https://flappy-bird-lake-psi.vercel.app/)
![Unity](https://img.shields.io/badge/Engine-Unity_6-000000?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

**Play in your browser (WebGL):** https://flappy-bird-lake-psi.vercel.app/

---

## About the Game

The player controls a bird that constantly falls due to gravity. Pressing **Space** makes the bird flap upward. The goal is to fly through the gaps between pipes for as long as possible. Each pipe pair passed gives **+1 score**, and touching a pipe ends the game.

## Controls

| Action | Input |
| ------ | ----- |
| Flap | `Space` key |
| Start / Restart | Click the **Play** button |

> Input is handled with Unity's new **Input System** (keyboard). Touch input is not implemented yet.

---

## Features

- Physics-based flapping using `Rigidbody2D`
- Three-frame animated bird wings
- Endlessly scrolling background (texture offset scrolling)
- Randomly positioned pipes spawned at regular intervals
- Live score display using Unity UI
- Game Over screen with a Play button to restart
- Clean restart: bird position, rotation, velocity, score, and pipes are all reset
- Target frame rate set to 60 FPS
- WebGL build deployed on Vercel

---

## Project Structure

```
Flappy Bird/
├── Assets/
│   ├── Scripts/          C# game logic (5 scripts)
│   ├── Sprites/          Bird, pipes, background, and UI graphics
│   ├── Materials/        Materials (including the scrolling background)
│   ├── Fonts/            UI fonts
│   ├── Mould_For_Pipe/   Pipe prefab
│   ├── Scenes/           Main game scene
│   └── Settings/         Input and render settings
├── Packages/             Unity package dependencies
├── ProjectSettings/      Unity project configuration
├── dist/                 WebGL build files hosted on Vercel
└── README.md
```

---

## Scripts

| Script | Responsibility |
| ------ | -------------- |
| `BirdController.cs` | Reads Space input and sets the bird's upward velocity. Animates the wing sprites. Detects trigger collisions with pipes (game over) and score zones (score). |
| `GameManager.cs` | Controls game flow, score, and UI. Pauses the game at start and on game over. Resets everything when Play is pressed. |
| `Spawner.cs` | Spawns a pipe prefab every 2 seconds at a random vertical offset. |
| `Pipes.cs` | Moves each pipe to the left every frame and destroys it once it leaves the screen. |
| `BackgroundMovement.cs` | Scrolls the background by changing the material's texture offset every frame. |

### How it works

- **Flapping:** when Space is pressed, the bird's `Rigidbody2D.linearVelocity` is set to a fixed upward value, so every flap has the same strength. Gravity pulls it down between flaps.
- **Collision and scoring:** pipes are tagged `Obstacle` and the gap between each pipe pair has an invisible trigger tagged `Scoring`. `OnTriggerEnter2D` in `BirdController` checks the tag and calls `GameOver()` or `ScorePoint()` on the `GameManager`.
- **Game state:** the game starts paused. `Pause()` sets `Time.timeScale = 0` and disables the bird controller. `Play()` sets `Time.timeScale = 1`, hides the UI, resets the bird, and destroys leftover pipes. Because movement, scrolling, and animation use scaled time, setting `timeScale` to 0 freezes all of them.
- **Pipes:** movement uses `Time.deltaTime` so speed does not depend on frame rate. Pipes destroy themselves at `x < -12` to avoid piling up in memory.

---

## Unity Concepts Used

- Scenes, GameObjects, Components, and Prefabs
- MonoBehaviour lifecycle (`Awake`, `Start`, `Update`, `OnEnable`, `OnDisable`)
- 2D physics: `Rigidbody2D`, gravity, velocity, colliders, and triggers
- Tags for identifying objects in collisions
- Sprite rendering and sprite-swap animation
- Material texture offset for scrolling effects
- Unity UI (score text, Game Over, Play button)
- `Time.deltaTime`, `Time.timeScale`, and `InvokeRepeating`
- Input System package
- WebGL build and deployment

---

## Run in the Unity Editor

**Requirements:** Unity Hub and Unity 6.

1. Clone the repository:
   ```
   git clone https://github.com/H-P-Jadeja/Flappy-Bird.git
   ```
2. Open Unity Hub, click **Add project from disk**, and select the cloned folder.
3. Open the main scene from `Assets/Scenes/`.
4. Press **Play**, click the Play button in the game, and use `Space` to flap.

---

## Known Limitations

- No touch or mobile input (keyboard only)
- No sound effects or music
- High score is not saved between sessions
- Difficulty does not increase over time
- Restart is done by clicking the Play button (Space does not restart)

## Possible Future Improvements

- Touch input support
- Sound effects and background music
- Saving the high score with `PlayerPrefs`
- Increasing pipe speed as the score grows

---

## Development Notes

This was my first Unity project, so I used **Google Gemini** as a learning aid to understand Unity and C# concepts and help with debugging. Some sprites were generated with Gemini (see `Assets/Sprites/`). I built and configured the scene, integrated the scripts, set up the physics and UI, tested the game, and deployed the WebGL build myself.

## Credits

- Original game concept: **Flappy Bird** by Dong Nguyen (2013)
- Built with **Unity**
- Hosted on **Vercel**

## Author

**H.P. Jadeja**
