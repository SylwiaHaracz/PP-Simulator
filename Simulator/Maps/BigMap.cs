using System.Collections.Generic;
using System.Drawing;

namespace Simulator.Maps;

public  class BigMap:Map
{
    private readonly List<IMappable>?[,] _fields;
    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000 ) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide");
        if (sizeY > 1000) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too high");
        _fields = new List<IMappable>[sizeX, sizeY];
    }
    protected override List<IMappable>?[,] Fields => _fields;

    private Dictionary<Point, List<IMappable>> keyValuePairs = new Dictionary<Point, List<IMappable>>();

    public override Point Next(Point p, Direction d)
    {
        return p.Next(d);
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        return p.NextDiagonal(d);
    }

    public override void Add(IMappable m, Point p)
    {
        if (!Exist(p))
            throw new ArgumentException($"Punkt {p} jest poza granicami mapy.");
        if (!keyValuePairs.ContainsKey(p))
        {
            keyValuePairs[p] = new List<IMappable>();
        }
        keyValuePairs[p].Add(m);
    }

    public override void Remove(IMappable m, Point p)
    {
        if (keyValuePairs.ContainsKey(p))
        {
            keyValuePairs[p].Remove(m);
            if (keyValuePairs[p].Count == 0)
            {
                keyValuePairs.Remove(p);
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
        if (keyValuePairs.ContainsKey(p))
        {
            return keyValuePairs[p];
        }
        return new List<IMappable>();
    }

    public override List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }
}
