using System.Drawing;
using System.Numerics;
using System.Runtime.Serialization;
using System.Threading.Channels;

public class Guess
{
    private Point _point;
    private List<int> _directions = new List<int> {0, 1, 2, 3};
    private int _direction;
    private static Random random = new Random();
    private HashSet<Point> guessedPoints = new HashSet<Point>();

    Dictionary<int, char> letters = new Dictionary<int, char>()
    {
        { 0, 'A' },
        { 1, 'B' },
        { 2, 'C' },
        { 3, 'D' },
        { 4, 'E' },
        { 5, 'F' },
        { 6, 'G' },
        { 7, 'H' },
        { 8, 'I' },
        { 9, 'J' }
    };

    // Getters and setters
    public void SetPoint(Point point)
    {
        _point = point;
    }

    public Point GetPoint()
    {
        return _point;
    }

    // Loads previously guessed coordinates to prevent guessing in the same location
    public void LoadGuessCoords(Board board)
    {
        Cell [,] cells = board.GetCells();

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (cells[i, j].GetIndicator() != ' ')
                {
                    guessedPoints.Add(new Point(i, j));
                }
            }
        }
    }

    // Displays guess coordinates to the user
    public void DisplayCoords()
    {
        Console.WriteLine($"{letters[_point.X]}{_point.Y}");
    }
    
    // Returns locations in a checkerboard pattern
    public void CheckerboardGuess()
    {
        int x;
        int y;

        do
        {
            x = random.Next(0, 10);
            y = random.Next(0, 10);

            _point = new Point(x, y);
        }
        while ((x + y) % 2 != 0 || CheckGuess(_point));

        guessedPoints.Add(_point);
    }

    // Guesses a random direction, and removes invalid directions
    public void GuessDirection()
    {
        while (_directions.Count > 0)
        {
            int index = random.Next(_directions.Count);
            _direction = _directions[index];

            Point newPoint = CheckDirection();
            if (!CheckGuess(newPoint))
            {
                _directions.RemoveAt(index);
                guessedPoints.Add(newPoint);
                return;
            }
            else
            {
                _directions.RemoveAt(index);
            }
        }        
    }

    // Switches to opposite direction
    public void ChangeDirection()
    {
        _direction = _direction switch
        {
            0 => 1,
            1 => 0,
            2 => 3,
            3 => 2,
            _ => _direction
        };
        // Console.WriteLine(_direction);
    }

    // Checks if the point in the given direction is valid
    public Point CheckDirection()
    {
        int x = _point.X;
        int y = _point.Y;
        Point newPoint;

        newPoint = _direction switch
        {
            0 => new Point(x + 1, y),
            1 => new Point(x - 1, y),
            2 => new Point(x, y + 1),
            3 => new Point(x, y - 1),
            _ => _point
        };

        return newPoint;
    }

    // Moves 1 tile in the given direction
    public void IncrementDirection()
    {
        int x = _point.X;
        int y = _point.Y;

        _point = _direction switch
        {
            0 => new Point(x + 1, y),
            1 => new Point(x - 1, y),
            2 => new Point(x, y + 1),
            3 => new Point(x, y - 1),
            _ => _point
        };
    }

    // Checks for invalid guesses
    public bool CheckGuess(Point point)
    {
        return guessedPoints.Contains(point) || point.X < 0 || point.X > 9 || point.Y < 0 || point.Y > 9;
    }
}