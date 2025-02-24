using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Board board = new Board();
        // Change to your filepath, on Windows change to board.txt
        string boardFile = "/tmp/board.txt";

        Console.WriteLine("Welcome to the Battleship Guesser!");
        char user_input = ' ';

        // Allows user to choose to load a previously saved board.
        while (char.ToLower(user_input) != 'y' && char.ToLower(user_input) != 'n')
        {
            Console.WriteLine("Would you like to load your previous game? (y/n)");
            user_input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (user_input == 'y')
            {
                board.LoadBoard(boardFile);
                board.ReturnCells();
            }
            else if (user_input == 'n')
            {
                board = new Board();
                board.CreateBoard();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Please type 'y' or 'n'.");
            }
        }

        Point point;
        int sunk_count = 0;

        // This loop runs until all 5 ships are sunk
        while (sunk_count < 5)
        {
            int hit_count = 0;
            // Creates a new Guess class, then loads previous
            // guesses to prevent guessing the same location
            Guess guess = new Guess();
            guess.LoadGuessCoords(board);

            // Generates a random guess in a checkerboard pattern
            guess.CheckerboardGuess();
            // Displays guess coordinates for the user to
            // determine if the coordinate was a hit or miss
            guess.DisplayCoords();
            // Loads point for hit check
            point = guess.GetPoint();

            // Checks for hit using the guess
            bool hit = board.CheckHit("Was it a hit? (y/n) ", point);
            Console.Clear();
            // Displays the board to the user
            board.ReturnCells();

            // If there is a hit, change guessing
            // behavior to finding direction of the ship
            if (hit)
            {
                hit_count++;
                // Anchor is the first hit location
                // It is used to determine the direction
                // and switch the direction if the ship
                // is not sunk
                Point anchor = guess.GetPoint();
                bool sunk = false;

                while (hit_count >= 1)
                {
                    if (sunk)
                    {
                        break;
                    }

                    guess.GuessDirection();
                    guess.IncrementDirection();
                    guess.DisplayCoords();
                    point = guess.GetPoint();
                    hit = board.CheckHit("Was it a hit? (y/n) ", point);
                    Console.Clear();
                    // Save after each guess
                    board.SaveBoard(boardFile);
                    board.ReturnCells();

                    // If a second hit is confirmed change 
                    // guessing behavior to guess in a line
                    if (hit)
                    {
                        hit_count++;

                        while (!sunk)
                        {
                            if (hit)
                            {
                                hit_count++;

                                if (hit_count >= 2)
                                {
                                    sunk = board.CheckHit("Was ship sunk? (y/n)");
                                    Console.WriteLine();
                                    if (sunk)
                                    {
                                        sunk_count++;
                                        hit_count = 0;
                                        break;
                                    }
                                }
                            }

                            // Move in the determined direction 1 tile
                            guess.IncrementDirection();
                            guess.DisplayCoords();
                            point = guess.GetPoint();

                            hit = board.CheckHit("Was it a hit? (y/n) ", point);
                            Console.Clear();
                            board.SaveBoard(boardFile);
                            board.ReturnCells();

                            // Switch direction if an end if found or a wall is hit
                            if (!hit || guess.CheckGuess(guess.CheckDirection()))
                            {
                                guess.SetPoint(anchor);
                                guess.ChangeDirection();
                            }
                        }
                    }
                    else
                    {
                        guess.SetPoint(anchor);
                    }
                }
            }
        }

        Console.WriteLine("You guessed all of the ships!");
    }
}