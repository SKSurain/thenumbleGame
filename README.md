Numble Game

Overview
Numble Game is a simple yet engaging console-based number guessing game written in C#. It pits a human player against the computer in a series of guessing rounds. Each player attempts to guess a randomly generated number within a specified range. The game consists of four rounds, with points awarded based on the accuracy and speed of guesses.

Features
Turn-based gameplay with a human player and a computer opponent.
Four rounds of guessing for increased engagement.
Scoring system based on the number of attempts and closeness to the guessed number.
Input validation and special conditions handling (e.g., option to abandon a round).


Prerequisites
To run Numble Game, ensure you have the following installed:

.NET SDK (version 5.0 or later)
An IDE such as Visual Studio or Visual Studio Code

Installation

1. git clone [URL to your repository]
2. Open the solution file (NumbleGame.sln) in Visual Studio or Visual Studio Code.
3. Build the solution to resolve dependencies.

How to Play
1.Start the game by running the console application.
2.Enter your name when prompted.
3.Guess the randomly generated number in each round.
4.For each guess, you'll receive feedback if your guess is too high or too low.
5.You can choose to abandon a round by entering 999.
6. After four rounds, the game ends, and the player with the highest score wins.

Game Rules

1.The game consists of four rounds.
2.Each round, a number between 1 and 100 (inclusive) is randomly generated.
3.Players take turns to guess the number.
4.Points are awarded based on guess accuracy.
5.A player can choose to abandon the round by entering 999.

Classes and Structure

1.Player: Represents a player in the game.
2.Game: Manages the game logic and flow.
3.NumberGenerator: Utility class for generating random numbers.

Contributing
Contributions to Numble Game are welcome! If you have suggestions or improvements, feel free to fork this repository and submit a pull request.

License
MIT License - feel free to use and modify this project for personal or educational purposes.

