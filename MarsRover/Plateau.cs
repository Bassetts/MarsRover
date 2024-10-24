namespace MarsRover;

public class Plateau(Point upperCoordinates)
{
    public bool CheckBounds(Point point)
    {
        return point.X >= 0 && point.X <= upperCoordinates.X && point.Y >= 0 && point.Y <= upperCoordinates.Y;
    }
}