<!-- README presentation: Vizzaq23 portfolio palette -->
<p align="center">
  <a href="https://github.com/Vizzaq23"><img src="https://img.shields.io/badge/Vizzaq23%20%C2%B7%20UNITY%20PROTOTYPE-101722?style=flat-square&amp;labelColor=101722&amp;color=D7B877" alt="Vizzaq23 · UNITY PROTOTYPE" /></a>
</p>

<h1 align="center">Adaptive Combat Trainer</h1>

<p align="center"><strong>An aim-training prototype that adapts to how you play.</strong></p>

<p align="center">
  <img src="https://img.shields.io/badge/Unity-101722?style=flat-square&amp;labelColor=101722&amp;color=85CFE8" alt="Unity" />
  <img src="https://img.shields.io/badge/C%23-101722?style=flat-square&amp;labelColor=101722&amp;color=D7B877" alt="C#" />
  <img src="https://img.shields.io/badge/Adaptive%20difficulty-101722?style=flat-square&amp;labelColor=101722&amp;color=B8A1E3" alt="Adaptive difficulty" />
</p>

<p align="center">
  <a href="https://vizzaq23.itch.io/adaptive-shooter">Play prototype</a> · <a href="https://www.quintinvizza.dev/demos/trainer-20260911.mp4">Newer development demo</a> · <a href="https://quintinvizza.dev">Portfolio</a> · <a href="https://github.com/Vizzaq23">GitHub profile</a>
</p>

<p align="center">
  <a href="#overview">Overview</a> · <a href="#prototype-features">Features</a> · <a href="#how-difficulty-works">How it works</a> · <a href="#run-the-published-source">Quick start</a> · <a href="#prototype-screenshots">Screenshots</a>
</p>

<img src="https://raw.githubusercontent.com/Vizzaq23/Vizzaq23/main/assets/divider.svg" width="100%" alt="" />

## Overview

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

<img src="https://raw.githubusercontent.com/Vizzaq23/Vizzaq23/main/assets/divider.svg" width="100%" alt="" />

<p align="center"><sub>Built by <a href="https://github.com/Vizzaq23">Quintin Vizza</a> · <a href="https://quintinvizza.dev">Explore my work</a></sub></p>
