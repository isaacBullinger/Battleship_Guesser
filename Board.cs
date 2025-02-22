using System.Drawing;

public class Board
{
    private Cell[,] cells = new Cell[10, 10];
    private string[] letters = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};

    public Cell[,] GetCells()
    {
        return cells;
    }

    public Cell[,] CreateBoard()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                cells[i, j] = new Cell();
            }
        }

        return cells;
    }

    public void ReturnCells()
    {
        Console.WriteLine("   0  1  2  3  4  5  6  7  8  9");
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            Console.Write(letters[i] + " ");
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                Console.Write($"[{cells[i, j].GetIndicator()}]");
            }
            Console.WriteLine();
        }
    }

    public bool CheckHit(string msg, Point? point=null)
    {
        bool hit = false;
        char user_input = ' ';

        while (char.ToLower(user_input) != 'y' && char.ToLower(user_input) != 'n')
        {
            Console.Write(msg);
            user_input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (user_input == 'y')
            {
                hit = true;
                if(point.HasValue)
                {
                    cells[point.Value.X, point.Value.Y].SetIndicator('H');
                }
            }
            else if (user_input == 'n')
            {
                hit = false;
                if(point.HasValue)
                {
                    cells[point.Value.X, point.Value.Y].SetIndicator('~');
                }
            }
            else
            {
                Console.WriteLine("Please type 'y' or 'n'.");
            }
        }

        return hit;
    }
}