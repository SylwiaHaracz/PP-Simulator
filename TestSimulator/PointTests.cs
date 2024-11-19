using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Theory]
    [InlineData (10, 25)]
    [InlineData(15,3)]
    [InlineData(-1, 0)]
    [InlineData(0, -5)]
    [InlineData(0, 0)]
    [InlineData(8, -3)]
    [InlineData(-8, 5)]
    public void Point_Create_ShouldPassCorrectly(int x, int y)
    {
        var point = new Point(x, y);
        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Theory]
    [InlineData (1,1, Direction.Right,2,1)]
    [InlineData(3, 3, Direction.Up, 3, 4)]
    [InlineData(3, 3, Direction.Down, 3, 2)]
    [InlineData(3, 3, Direction.Right, 4, 3)]
    [InlineData(3, 3, Direction.Left, 2, 3)]
    [InlineData(9, 3, Direction.Up, 9, 4)]
    [InlineData(9, 3, Direction.Right, 10, 3)]
    [InlineData(8, 3, Direction.Right, 9, 3)]
    [InlineData(0, 0, Direction.Left, -1, 0)]
    [InlineData(0, 0, Direction.Down, 0, -1)]
    [InlineData(0, 0, Direction.Right, 1, 0)]
    [InlineData(-15, 8, Direction.Up, -15, 9)]
    [InlineData(-15, 8, Direction.Down, -15, 7)]
    [InlineData(-15, 8, Direction.Left, -16, 8)]
    [InlineData(-15, 8, Direction.Right, -14, 8)]
    public void Point_Next_ShouldPassCorecctly(int x, int y, Direction d, int nextX, int nextY)
    {
        var point = new Point (x, y);
        var nextPoint = new Point(nextX, nextY);
        Assert.Equal(nextPoint, point.Next(d));
    }

    [Theory]
    [InlineData(1, 1, Direction.Down, 0, 0)]
    [InlineData(3, 3, Direction.Up, 4, 4)]
    [InlineData(8, 3, Direction.Right, 9, 2)]
    [InlineData(3, 3, Direction.Left, 2, 4)]
    [InlineData(9, 3, Direction.Up, 10, 4)]
    [InlineData(9, 3, Direction.Right, 10, 2)]
    [InlineData(0, 0, Direction.Left, -1, 1)]
    [InlineData(0, 0, Direction.Down, -1, -1)]
    [InlineData(0, 0, Direction.Right, 1, -1)]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    [InlineData(-15, 8, Direction.Up, -14, 9)]
    [InlineData(-15, 8, Direction.Down, -16, 7)]
    [InlineData(-15, 8, Direction.Left, -16, 9)]
    [InlineData(-15, 8, Direction.Right, -14, 7)]

    public void Point_NextDiagonal_ShouldPassCorecctly(int x, int y, Direction d, int nextX, int nextY)
    {
        var point = new Point(x, y);
        var nextPoint = new Point(nextX, nextY);
        Assert.Equal(nextPoint, point.NextDiagonal(d));
    }
}
