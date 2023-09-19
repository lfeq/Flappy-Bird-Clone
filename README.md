# Flappy Bird Clone

## Description

Flappy Bird Clone is a simple clone of the classic Flappy Bird game, created using Unity. You can play the game online at [Flappy Bird Clone on itch.io](https://oopolo.itch.io/flappy-bird-no-10000000) or clone the repository to play it on your computer. This project demonstrates the use of various design patterns and techniques in game development.

## Features

- **State Machines:** The game uses state machines to manage different game states, including gameplay, menu, and tutorial screens. This ensures smooth transitions between different parts of the game.

- **Singletons:** Singleton design patterns are implemented to manage the player's score and game state. This allows for easy access to critical game data and ensures data consistency.

- **Object Pool Pattern:** To optimize memory usage, an Object Pool pattern is employed for the pipes in the game. Instead of creating and destroying pipe objects, they are recycled from a pool, reducing memory overhead.

## Installation

To play the game on your computer, follow these steps:

1. Clone this repository to your local machine using Git:
```
git clone https://github.com/yourusername/flappy-bird-clone.git
```


2. Open the project in Unity.

3. Build and run the game in the Unity Editor or export it to your desired platform.

## Controls

- **Spacebar:** Jump and keep the bird afloat.
- **Escape (in menu):** Quit the game.

## Gameplay

Your goal in Flappy Bird Clone is to navigate the bird through a series of pipes without colliding with them. Each successful pass through a pair of pipes earns you a point. Try to achieve the highest score possible!

## Credits

This game was created by [develion](https://develion.itch.io/flappy-bird-unity-project) I just implemented the features explained above.

Available on [itch.io](https://oopolo.itch.io/flappy-bird-no-10000000).

Enjoy the game!
