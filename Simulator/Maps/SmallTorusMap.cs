namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public readonly int Size;
    public SmallTorusMap(int size)
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
            Point nextPoint  = new Point((p.Next(d).X + Size) % Size, (p.Next(d).Y + Size) % Size);
            return nextPoint;
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
            Point nextPoint = new Point((p.NextDiagonal(d).X + Size) % Size, (p.NextDiagonal(d).Y + Size) % Size);
            return nextPoint;
        }
        catch
        {
            throw new NotImplementedException();
        }
    }
}
