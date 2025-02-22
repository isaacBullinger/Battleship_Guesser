using System.Drawing;
using System.IO;

public class Board
{
    private Cell[,] cells = new Cell[10, 10];
    private string[] letters = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};

    // Saves the board to determined filename
    public void SaveBoard(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("   0  1  2  3  4  5  6  7  8  9");
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                writer.Write(letters[i]);
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    writer.Write($"[{cells[i, j].GetIndicator()}]");
                }
                writer.WriteLine();
            }
        }
    }

    // Loads board from determined filename
    public void LoadBoard(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        CreateBoard();

        string[] lines = File.ReadAllLines(filename);
        
        for (int i = 1; i <= 10; i++)
        {
            string line = lines[i].Trim();
            for (int j = 0, col = 2; j < 10; j++, col += 3)
            {
                if (line.Length > col + 1)
                {
                    char indicator = line[col];
                    cells[i - 1, j].SetIndicator(indicator);
                }
            }
        }
    }

    // Returns previously guessed cells
    public Cell[,] GetCells()
    {
        return cells;
    }

    // Creates a new empty board
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

    // Displays the board to the user
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

    // Checks if the location was a hit or miss
    // Also checks if the ships were sunk if a point is not given
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