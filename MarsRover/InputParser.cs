namespace MarsRover;

public static class InputParser
{
    public static List<Rover> ParseInput(string input)
    {
        var lines = input
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Replace(Environment.NewLine, string.Empty))
            .ToList();

        var upperCoordinates = lines[0].Split(' ');
        var upperXCoordinate = int.Parse(upperCoordinates[0]);
        var upperYCoordinate = int.Parse(upperCoordinates[1]);

        var plateau = new Plateau(new Point(upperXCoordinate, upperYCoordinate));

        var rovers = new List<Rover>();

        lines = lines.Skip(1).ToList();
        for (var i = 0; i < lines.Count; i += 2)
        {
            var initialValues = lines[i].Split(' ');
            var initialXCoordinate = int.Parse(initialValues[0]);
            var initialYCoordinate = int.Parse(initialValues[1]);
            var initialDirection = initialValues[2][0];

            var instructions = ParseInstructions(lines[i + 1]);
            var initialPoint = new Point(initialXCoordinate, initialYCoordinate);
            rovers.Add(new Rover(initialPoint, (Direction)initialDirection, instructions, plateau));
        }

        return rovers;
    }

    private static IEnumerable<Instruction> ParseInstructions(string instructions)
    {
        return instructions.Select(instruction => (Instruction)instruction);
    }
}