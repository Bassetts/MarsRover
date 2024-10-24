namespace MarsRover;

public class Rover(Point position, Direction direction, IEnumerable<Instruction> instructions, Plateau plateau)
{
    private Direction _direction = direction;
    private Point _position = position;

    public void Execute()
    {
        foreach (var instruction in instructions)
            switch (instruction)
            {
                case Instruction.L:
                    TurnLeft();
                    break;
                case Instruction.R:
                    TurnRight();
                    break;
                case Instruction.M:
                    MoveForward();
                    break;
            }
    }

    private void TurnLeft()
    {
        _direction = _direction switch
        {
            Direction.N => Direction.W,
            Direction.E => Direction.N,
            Direction.S => Direction.E,
            Direction.W => Direction.S,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void TurnRight()
    {
        _direction = _direction switch
        {
            Direction.N => Direction.E,
            Direction.E => Direction.S,
            Direction.S => Direction.W,
            Direction.W => Direction.N,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void MoveForward()
    {
        var newPosition = _direction switch
        {
            Direction.N => _position with { Y = _position.Y + 1 },
            Direction.E => _position with { X = _position.X + 1 },
            Direction.S => _position with { Y = _position.Y - 1 },
            Direction.W => _position with { X = _position.X - 1 },
            _ => throw new ArgumentOutOfRangeException()
        };

        if (plateau.CheckBounds(_position)) _position = newPosition;
    }

    public override string ToString()
    {
        return $"{_position.X} {_position.Y} {_direction}";
    }
}