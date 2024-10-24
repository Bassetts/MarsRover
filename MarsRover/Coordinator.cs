namespace MarsRover;

public class Coordinator(IEnumerable<Rover> rovers)
{
    private readonly List<Rover> _rovers = rovers.ToList();

    public List<string> Execute()
    {
        var result = new List<string>();

        foreach (var rover in _rovers)
        {
            rover.Execute();
            result.Add(rover.ToString());
        }

        return result;
    }
}