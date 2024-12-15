using System.Collections.Generic;

namespace Simulator.Maps;

public abstract class SmallMap:Map
{
    private readonly List<IMappable>?[,] _fields;
    protected SmallMap(int sizeX, int sizeY):base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too high");
        _fields = new List<IMappable>?[sizeX, sizeY];
    }
    protected override List<IMappable>?[,] Fields => _fields;
    public override void Add(IMappable c, Point p)
    {
        int x = p.X;
        int y = p.Y;

        if (Fields[x, y] == null)
        {
            Fields[x, y] = new List<IMappable>();
        }
        Fields[x, y]!.Add(c);
    }
    public override void Remove(IMappable creature, Point p)
    {
        int x = p.X;
        int y = p.Y;

        var creatures = Fields[x, y];
        if (creatures != null)
        {
            creatures.RemoveAll(c => c == creature);

            if (creatures.Count == 0)
            {
                Fields[x, y] = null;
            }
        }
    }

    public override void Move(IMappable c, Point point1, Point point2)
    {
        Remove(c, point1);
        Add(c, point2);
    }

    public override List<IMappable> At(Point p)
    {
        int x = p.X;
        int y = p.Y;
        var creaturesAtPoint = new List<IMappable>();
        var creatures = Fields[x, y];
        if (creatures != null)
        {
            creaturesAtPoint.AddRange(creatures);
        }
        return creaturesAtPoint;
    }

    public override List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }
}
