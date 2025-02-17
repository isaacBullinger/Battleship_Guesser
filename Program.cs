using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {

        Cell[,] cells = new Cell[10, 10];
        Board board = new Board();
        Guess guess = new Guess();
        Point point;

        board.CreateBoard(cells);
        bool all_sunk = false;

        while (all_sunk == false)
        {
            bool hit = false;
            bool sunk = false;

            point = guess.CheckerboardGuess();
            
            if (cells[point.X, point.Y].GetIndicator() == ' ')
            {
                hit = board.CheckHit("Was it a hit? (y/n) ");

                while (hit)
                {
                    if (hit && !sunk)
                    {
                        cells[point.X, point.Y].SetIndicator('H');
                        sunk = board.CheckHit("Was it sunk? (y/n) ");
                        if (!sunk)
                        {
                            point = guess.DirectionGuess(point);
                        }
                        else
                        {
                            point = guess.CheckerboardGuess();
                        }
                    }
                    else
                    {
                        cells[point.X, point.Y].SetIndicator('~');
                        point = guess.CheckerboardGuess();
                    }

                    hit = board.CheckHit("Was it a hit? (y/n) ");
                }
            }

            board.ReturnCells(cells);
            all_sunk = board.CheckHit("Are all ships sunk? (y/n) ");
        }
    }
}