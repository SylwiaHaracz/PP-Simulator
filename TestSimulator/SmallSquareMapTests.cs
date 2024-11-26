using Simulator.Maps;
using Simulator;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Theory]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(12)]
    [InlineData(5)]
    [InlineData(8)]
    public void SmallSquareMap_Create_ShouldNotThrowAnException(int size)
    {
        var map = new SmallSquareMap(size);
        Assert.Equal(size, map.SizeX);
        Assert.Equal(size, map.SizeY);
    }
    [Theory]
    [InlineData(4)]
    [InlineData(-3)]
    [InlineData(21)]
    [InlineData(50)]
    public void SmallSquareMap_Create_ShouldThrowAnExeption(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }
    [Fact]
    public void SmallSquareMap_PointExists_ShouldReturnCorrect()
    {
        var map = new SmallSquareMap(10);
        var point1 = new Point(3, 3);
        var point2 = new Point(10, 3);
        var point3 = new Point(3, 15);
        var point4 = new Point(-1, -2);
        var point5 = new Point(9, 3);
        Assert.True(map.Exist(point1));
        Assert.False(map.Exist(point2));
        Assert.False(map.Exist(point3));
        Assert.False(map.Exist(point4));
        Assert.True(map.Exist(point5));
    }
    [Theory]
    [InlineData(5, 3,3,Direction.Up,3,4)]
    [InlineData(5, 3, 3, Direction.Down, 3, 2)]
    [InlineData(5, 3, 3, Direction.Right, 4, 3)]
    [InlineData(5, 3, 3, Direction.Left, 2, 3)]
    [InlineData(10, 9, 3, Direction.Up, 9, 4)]
    [InlineData(10, 9, 3, Direction.Right, 9, 3)]
    [InlineData(10, 8, 3, Direction.Right, 9, 3)]
    [InlineData(6, 0, 0, Direction.Left, 0, 0)]
    [InlineData(6, 0, 0, Direction.Down, 0, 0)]
    [InlineData(6, 0, 0, Direction.Right, 1, 0)]
    public void SmallSquareMap_Next_ShouldReturnCorrect(int mapSize, int x, int y, Direction direction, int nextX, int nextY)
    {
        var map = new SmallSquareMap(mapSize);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);
        var expectedPoint = new Point(nextX, nextY);
        Assert.Equal(nextPoint, expectedPoint);

    }
    [Theory]
    [InlineData(5, 3, 3, Direction.Up, 4, 4)]
    [InlineData(10, 8, 3, Direction.Right, 9, 2)]
    [InlineData(5, 3, 3, Direction.Left, 2, 4)]
    [InlineData(10, 9, 3, Direction.Up, 9, 3)]
    [InlineData(10, 9, 3, Direction.Right, 9, 3)]
    [InlineData(6, 0, 0, Direction.Left, 0, 0)]
    [InlineData(6, 0, 0, Direction.Down, 0, 0)]
    [InlineData(6, 0, 0, Direction.Right, 0, 0)]
    [InlineData(6, 0, 0, Direction.Up, 1, 1)]
    public void SmallSquareMap_NextDiagonal_ShouldReturnCorrect(int mapSize, int x, int y, Direction direction, int nextX, int nextY)
    {
        var map = new SmallSquareMap(mapSize);
        var point = new Point(x, y);
        var nextPoint = map.NextDiagonal(point, direction);
        var expectedPoint = new Point(nextX, nextY);
        Assert.Equal(nextPoint, expectedPoint);

    }
}
