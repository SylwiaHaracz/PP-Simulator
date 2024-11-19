using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Theory]
    [InlineData(1,1,5,5)]
    [InlineData(1,2,3,4)]
    [InlineData(3,4,1,2)]
    [InlineData(-5,3,-2,1)]
    public void Rectangle_Create_ShouldPassCorrectly(int x1, int y1, int x2, int y2)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(Math.Min(x1,x2), rectangle.X1);
        Assert.Equal(Math.Min(y1, y2), rectangle.Y1);
        Assert.Equal(Math.Max(x1, x2), rectangle.X2);
        Assert.Equal(Math.Max(y1, y2), rectangle.Y2);
    }

    [Theory]
    [InlineData(1, 1, 1, 1)]
    [InlineData(2, 3, 2, 4)]
    [InlineData(1, 8, 2, 8)]
    [InlineData(-3,-2,-3,-8)]
    [InlineData(3, 2, -3, 2)]
    public void Rectangle_Create_ShouldThrowAnExeption(int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(x1,y1,x2,y2));
    }

    [Theory]
    [InlineData(1, 1, 5, 5, 3, 3)]
    [InlineData(-3, -5, 5, 5, 3, 3)]
    [InlineData(-3, -5, 5, 5, -1, -2)]
    public void Rectangle_ConsistsPoint_ShouldContainPoint(int x1, int y1, int x2, int y2, int pointX, int pointY)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var point = new Point(pointX, pointY);
        Assert.True(rectangle.Contains(point));
    }

    [Theory]
    [InlineData(-3, -5, 5, 5, -8, -12)]
    [InlineData(1, 1, 3, 3, 8, 2)]
    [InlineData(-3, -5, 5, 5, 6, 6)]
    [InlineData(-1, 1, -3, 3, -4, 7)]
    public void Rectangle_ConsistsPoint_ShouldNotContainPoint (int x1, int y1, int x2, int y2, int pointX, int pointY)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var point = new Point(pointX, pointY);
        Assert.False(rectangle.Contains(point));
    }
}
