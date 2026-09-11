# Adaptive Combat Trainer — Unity / C#

A 3D aim-training prototype that adjusts target difficulty using player accuracy and time to hit a target. Built with Unity and C# to explore feedback loops, game-state management, and responsive UI.

**[Play the published prototype](https://vizzaq23.itch.io/adaptive-shooter) · [Latest development demo](https://www.quintinvizza.dev/demos/trainer-20260911.mp4) · [Portfolio](https://www.quintinvizza.dev/#projects)**

> Version note: this repository's current default branch contains the original prototype. The September 2026 portfolio video shows a newer local development build with Flick/Tracking sessions and coaching feedback; those newer features are not all present in this checkout.

## Prototype features

- Timed aim-training rounds with live statistics and end-of-round feedback.
- Difficulty changes affecting target spawn interval, movement speed, and size.
- Gradual interpolation between difficulty values.
- Main-menu, start, restart, and return-to-menu flows.
- Separate aim-training and enemy-sandbox scenes.

## How difficulty works

`RoundManager.cs` calculates accuracy as hits divided by shots. It combines that value with the average recorded time for successful hits, using a 60/40 weighting, then interpolates toward new target parameters.

The implementation is a deterministic heuristic, not a trained machine-learning model. The timing metric is an in-game time-to-hit measure; it is not a controlled measurement of human reaction time. The displayed skill categories are application rules, not validated player rankings.

## Run the published source

The committed project version is **Unity 6000.4.1f1**; check [ProjectVersion.txt](ProjectSettings/ProjectVersion.txt) before opening a later revision.

```sh
git clone https://github.com/Vizzaq23/AdpativeShooter.git
```

1. Add the cloned folder in Unity Hub and open it with the matching editor.
2. Allow Unity to import assets and packages.
3. Open `Assets/Scenes/MainMenu.unity`.
4. Press **Play** and start a training round.

The repository name is spelled `AdpativeShooter`; the clone URL above matches the actual repository.

## Code map

| Path | Responsibility |
| --- | --- |
| `Assets/Scripts/RoundManager.cs` | Round lifecycle, statistics, and difficulty |
| `Assets/Scripts/PlayerShooter.cs` | Player shooting |
| `Assets/Scripts/TargetSpawner.cs` | Target creation |
| `Assets/Scripts/MovingTarget.cs` | Target movement |
| `Assets/Scripts/UIManager.cs` | Interface updates |
| `Assets/Scenes/` | Main menu, trainer, and enemy sandbox |

## Prototype screenshots

![Aim trainer gameplay](https://github.com/user-attachments/assets/21c7f767-6a00-4af9-bd63-f27bbd925e82)
![End-of-round statistics](https://github.com/user-attachments/assets/d301f9d0-9c18-480e-8c7e-d627ab277954)

## Verification

A useful manual check is to start a round, confirm shots/hits update, observe difficulty changes, reach the results screen, and restart. This README does not claim an automated test suite for the published prototype.
