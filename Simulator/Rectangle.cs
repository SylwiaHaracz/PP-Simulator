namespace Simulator;

internal class Rectangle
{
    public readonly int X1, Y1;//lewy dolny
    public readonly int X2, Y2; //prawy górny

    public Rectangle (int X1, int Y1, int X2, int Y2)
    {
        if (X1==X2 || Y1 == Y2)
        {
            throw new ArgumentException("Invalid rectangle. Try again.");
        }

        this.X1 = (X1 < X2 ? X1 : X2);
        this.X2 = (X2 > X1 ? X2 : X1);
        this.Y1 = (Y1 < Y2 ? Y1 : Y2);
        this.Y2 = (Y2 > Y1 ? Y2 : Y1);

    }

    public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y)
    {

    }

    public bool Contains(Point point)
    {
        return (point.X >= X1 && point.X <= X2 && point.Y >= Y1 && point.Y <= Y2) ? true : false;

    }

    public override string ToString()
    {
        return $"({X1}, {Y1}):({X2}, {Y2})";
    }

}
