public class Board
{

    public Cell[,] CreateBoard(Cell[,] cells)
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

    public void ReturnCells(Cell[,] cells)
    {
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                Console.Write($"[{cells[i, j].GetIndicator()}]");
            }
            Console.WriteLine();
        }
    }

    public bool CheckHit(string msg)
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
            }
            else if (user_input == 'n')
            {
                hit = false;
            }
            else
            {
                Console.WriteLine("Please type 'y' or 'n'.");
            }
        }

        return hit;
    }
}