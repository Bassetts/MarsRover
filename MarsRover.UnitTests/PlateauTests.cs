namespace MarsRover.UnitTests;

public class PlateauTests
{
    [TestCase(0, 0)]
    [TestCase(0, 1)]
    [TestCase(1, 0)]
    [TestCase(5, 5)]
    [TestCase(0, 5)]
    [TestCase(5, 0)]
    public void CheckBounds_PointWithinBounds_ReturnsTrue(int x, int y)
    {
        var point = new Point(x, y);
        var plateau = new Plateau(new Point(5, 5));

        var result = plateau.CheckBounds(point);

        Assert.That(result, Is.True);
    }

    [TestCase(-1, -1)]
    [TestCase(0, -1)]
    [TestCase(-1, 0)]
    [TestCase(0, 6)]
    [TestCase(6, 0)]
    public void CheckBounds_PointOutsideBounds_ReturnsFalse(int x, int y)
    {
        var point = new Point(x, y);
        var plateau = new Plateau(new Point(5, 5));

        var result = plateau.CheckBounds(point);

        Assert.That(result, Is.False);
    }
}