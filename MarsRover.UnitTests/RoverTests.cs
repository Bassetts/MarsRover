namespace MarsRover.UnitTests;

public class RoverTests
{
    private readonly Plateau _plateau = new(new Point(5, 5));

    [TestCase(
        0, 0,
        Direction.N,
        new[] { Instruction.R, Instruction.M, Instruction.L, Instruction.M, Instruction.M },
        "1 2 N")]
    [TestCase(
        1, 2,
        Direction.N,
        new[]
        {
            Instruction.L, Instruction.M, Instruction.L, Instruction.M, Instruction.L, Instruction.M, Instruction.L,
            Instruction.M, Instruction.M
        },
        "1 3 N")]
    [TestCase(
        3, 3,
        Direction.E,
        new[]
        {
            Instruction.M, Instruction.M, Instruction.R, Instruction.M, Instruction.M, Instruction.R, Instruction.M,
            Instruction.R, Instruction.R, Instruction.M
        },
        "5 1 E")]
    public void Execute_HasValidInput_ToStringReturnsCorrectOutput(int x, int y, Direction direction,
        Instruction[] instructions, string expected)
    {
        var point = new Point(x, y);
        var rover = new Rover(point, direction, instructions, _plateau);

        rover.Execute();

        Assert.That(rover.ToString(), Is.EqualTo(expected));
    }
}