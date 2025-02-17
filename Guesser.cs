using System.Drawing;
using System.Numerics;
using System.Runtime.Serialization;
using System.Threading.Channels;

public class Guess
{
    private Point guessCoord;
    private int guessDirection = 4;
    Dictionary<int, char> letters = new Dictionary<int, char>()
    {
        { 0, 'a' },
        { 1, 'b' },
        { 2, 'c' },
        { 3, 'd' },
        { 4, 'e' },
        { 5, 'f' },
        { 6, 'g' },
        { 7, 'h' },
        { 8, 'i' },
        { 9, 'j' }
    };
    
    public Point CheckerboardGuess()
    {
        bool is_check = false;
        Random randx = new Random();
        int x = randx.Next(0, 10);
        Random randy = new Random();
        int y = randy.Next(0, 10);

        // Checkerboard pattern for random guessing
        while (is_check == false)
        {
            if (y % 2 == 0)
            {
                while (x % 2 != 0)
                {
                    x = randx.Next(0, 10);
                }
                is_check = true;
            }

            else
            {
                while (x % 2 == 0)
                {
                    x = randx.Next(0, 10);
                }
                is_check = true;
            }
        }

        DisplayCoords(x, y);
        guessCoord = new Point(x, y);

        return guessCoord;
    }

    public void SetGuessDirection(int direction)
    {
        guessDirection = direction;
    }
    
    public int GetGuessDirection()
    {
        return guessDirection;
    }
    
    public Point DirectionGuess(Point point)
    {
        // [right+, left-, down+, up-]
        bool bounds = true;

        if (guessDirection > 3)
        {
            while(bounds == true)
            {
                guessDirection = new Random().Next(0, 4);
                if (
                    (point.X == 0 && guessDirection == 1) ||
                    (point.X == 9 && guessDirection == 0) ||
                    (point.Y == 0 && guessDirection == 3) ||
                    (point.Y == 9 && guessDirection == 2)
                    )
                {
                    guessDirection = new Random().Next(0, 4);
                }
                else
                {
                    bounds = false;
                }
            }
        }

        int x = point.X;
        int y = point.Y;

        point = guessDirection switch
        {
            0 => new Point(point.X + 1, y),
            1 => new Point(point.X - 1, y),
            2 => new Point(x, point.Y + 1),
            3 => new Point(x, point.Y - 1),
        };

        // Console.WriteLine(dir_str[guessDirection]);
        DisplayCoords(point.X, point.Y);

        return point;
    }

    private void DisplayCoords(int x, int y)
    {
        Console.Write(letters[y]);
        Console.WriteLine(x);
    }
}