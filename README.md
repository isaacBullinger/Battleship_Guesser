# Overview

I wrote a Battleship guesser program. This helps the user to guess the locations of enemy ships. It uses an algorithm that guesses randomly in a checkerboard pattern until it finds a ship. Then it tries to guess the direction of the ship by guessing random directions. When the direction is found, it guesses in that direction until the ship is sunk or it hits a boundary or previously guessed coordinate. After the ship is sunk it goes back to guessing in the checkerboard pattern. I also implemented saving and loading boards from a text file.

My purpose for writing this software is to learn the C# programming language. I wanted to learn how to program with classes and create something complex.

To setup the game, make sure you change boardFile in Program.cs on line 10 to a filepath that works for you.

{Provide a link to your YouTube demonstration. It should be a 4-5 minute demo of the software running and a walkthrough of the code. Focus should be on sharing what you learned about the language syntax.}

[Battleship Guesser](https://youtu.be/1dItAMpk5Zs)

# Development Environment

I used Visual Studio Code with the NeoVim extension, and the Bash terminal to view the saved files.

{Describe the programming language that you used and any libraries.}
I used C#, an object oriented language. I used System.IO for reading and writing files. I also used System.Drawing library for the Point structure. For lists and hash sets I used System.Collections.Generic.

# Useful Websites

- [W3 Schools](https://www.w3schools.com/cs/index.php)
- [C# Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/)

# Future Work

- I would like to use this for the computer AI with a terminal Battleship game.
- I would like to make the UI more refined.
- There may be small bugs that need fixed.
