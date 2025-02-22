using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Board board = new Board();
        Point point;
        int sunk_count = 0;

        board.CreateBoard();

        while (sunk_count < 5)
        {
            int hit_count = 0;
            Guess guess = new Guess();
            Console.WriteLine("Guess set");

            guess.CheckerboardGuess();
            guess.DisplayCoords();
            point = guess.GetPoint();

            bool hit = board.CheckHit("1 Was it a hit? (y/n) ", point);
            board.ReturnCells();

            if (hit)
            {
                hit_count++;
                Point anchor = guess.GetPoint();
                bool sunk = false;

                while (hit_count >= 1 && !sunk)
                {
                    guess.GuessDirection();
                    guess.DisplayCoords();
                    point = guess.GetPoint();
                    hit = board.CheckHit("2 Was it a hit? (y/n) ", point);
                    board.ReturnCells();

                    if (hit)
                    {
                        hit_count++;

                        while (!sunk)
                        {
                            guess.IncrementDirection();
                            guess.DisplayCoords();
                            point = guess.GetPoint();

                            hit = board.CheckHit("3 Was it a hit? (y/n) ", point);
                            board.ReturnCells();

                            if (!hit)
                            {
                                guess.SetPoint(anchor);
                                guess.ChangeDirection();
                                Console.WriteLine("Direction switched");
                            }

                            if (hit_count > 1 && hit)
                            {
                                sunk = board.CheckHit("Was ship sunk? (y/n)");
                            }

                            if (sunk)
                            {
                                sunk_count++;
                                hit_count = 0;
                            }
                        }
                    }
                }
            }
        }
    }
}