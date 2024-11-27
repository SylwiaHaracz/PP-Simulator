namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>



    //Add(IMappable, Point)
    //Remove(IMappable, Point)
    //Move()  -> Remove+add
    //At(Point)  a druga x i y


    private readonly Rectangle _map;
    public int SizeX { get; }
    public int SizeY { get; }

    protected abstract List<IMappable>?[,] Fields { get; }

    protected Map(int sizeX, int sizeY)
    {
        if(sizeX<5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too small");
        }
        if (sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Map too small");
        }
        SizeX = sizeX;
        SizeY = sizeY;
        _map = new Rectangle(0,0,SizeX-1,SizeY-1);
    }

    public virtual bool Exist(Point p) => _map.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);

    public abstract void Add(IMappable c, Point p);

    public abstract void Remove(IMappable c, Point p);

    public abstract void Move(IMappable c, Point point1, Point point2);

    public abstract List<IMappable> At(Point p);

    public abstract List<IMappable> At(int x, int y);
    

}
