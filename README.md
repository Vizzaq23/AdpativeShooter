# AI Aim Trainer (Unity)

An adaptive 3D aim trainer built in Unity and C# that adjusts difficulty in real time based on player performance.
This project was designed to feel more intelligent than a basic target shooter by tracking player accuracy and reaction time, then using those metrics to dynamically adjust target spawn rate, movement speed, and target size during gameplay. The result is a more responsive and personalized training experience.

---

## Demo / Screenshots

### Home Screen and Start Screen
<img width="817" height="406" alt="HomeScreenSS" src="https://github.com/user-attachments/assets/6ad03689-fd20-4312-be20-119edcd90544" />
<img width="823" height="406" alt="image" src="https://github.com/user-attachments/assets/22b39675-0026-4881-94ee-134e46be26c2" />


### Gameplay
<img width="820" height="409" alt="image" src="https://github.com/user-attachments/assets/21c7f767-6a00-4af9-bd63-f27bbd925e82" />


### Adaptive Difficulty in Action
<img width="806" height="392" alt="image" src="https://github.com/user-attachments/assets/eecebd1d-5ddb-45bd-a352-6eb5e0dfa2f4" />


### End Screen Stats
<img width="818" height="412" alt="image" src="https://github.com/user-attachments/assets/d301f9d0-9c18-480e-8c7e-d627ab277954" />


---

## Features

- Real-time adaptive difficulty system
- Tracks player accuracy and average reaction time
- Dynamically adjusts:
  - target spawn interval
  - target movement speed
  - target size
- Smooth difficulty scaling using interpolation
- Hit feedback system for better game feel
- End-of-round stats screen
- Skill rating based on performance
- Restart and home screen flow

---

## Tech Stack

- **Engine:** Unity
- **Language:** C#
- **Core Concepts:** Game state management, adaptive systems, performance tracking, UI systems, object-oriented scripting

---

## How It Works

The game continuously measures player performance during each round using two main metrics:

- **Accuracy** = targets hit / shots fired
- **Average reaction time** = total reaction time / successful hits

These values are converted into performance scores and combined into a weighted difficulty score.

### Difficulty Logic
- Higher accuracy increases difficulty
- Faster reaction time increases difficulty
- Lower accuracy or slower reaction time decreases difficulty

The difficulty score is then used to modify:
- how quickly new targets spawn
- how fast targets move
- how small the targets appear

To prevent the game from feeling too abrupt or unfair, smoothing is applied so difficulty changes happen gradually instead of instantly.

This creates a system that feels more adaptive and responsive to the player over time.

---

## Adaptive Difficulty Algorithm

The adaptive system works in the following steps:

1. Track player shots fired
2. Track targets hit
3. Record reaction time whenever a target is hit
4. Calculate:
   - current accuracy
   - average reaction time
5. Convert those into a weighted difficulty score
6. Adjust gameplay parameters in real time
7. Smooth transitions so difficulty changes feel natural

   
##  How to Run the Game

### Option 1: Run in Unity 

1. Clone the repository:
git clone https://github.com/Vizzaq23/AdaptiveShooter.git
open in unity

###Option 2: 
https://vizzaq23.itch.io/adaptive-shooter





