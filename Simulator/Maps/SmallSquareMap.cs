namespace Simulator.Maps;

internal class SmallSquareMap : Map
{
    public readonly int Size;
    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException("Invalid size. Size shuld be between 5 and 20. Try again.");
        }
        Size = size;
    }
    public override bool Exist(Point p)
    {
        try
        {
            Rectangle r = new Rectangle(0, 0, Size - 1, Size - 1);
            return r.Contains(p);
        }
        catch
        {
            throw new NotImplementedException();
        }
    }
    public override Point Next(Point p, Direction d)
    {
        try
        {
            Point nextPoint = p.Next(d);
            return Exist(nextPoint) ? nextPoint : p;
        }
        catch
        {
            throw new NotImplementedException();
        }
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        try
        {
            Point nextPoint = p.NextDiagonal(d);
            return Exist(nextPoint) ? nextPoint : p;
        }
        catch
        {
            throw new NotImplementedException();
        }
    }
}
