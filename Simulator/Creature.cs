namespace Simulator;

using Simulator.Maps;
public abstract class Creature
{

    public Map? Map { get; private set; }
    public Point Position {get; private set;}

    public void InitMapAndPosition(Map map, Point position)
    {

    }


    private string name = "Unknown";
    private int level=1;

    public string Name {
        get { return name; }
        init
        {
            name = Validator.Shortener(value, 3, 25, '#');
            
        }
        
    }
    public int Level
    {
        get { return level; }
        init 
        {
            level = Validator.Limiter(value, 1, 10);
        }
    }
    public abstract string Info { get; }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature() {}
    public abstract string Greeting();
    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }
    public string Go (Direction direction)=> $"{direction.ToString().ToLower()}";
    public List<string> Go (List<Direction> directions)
    {
        
        
        //Map.Next(); - musi chodzić po dobrej mapie
        //Map.Next() == Position -> i wtedy nie wykonujemy ruchu
        
        // Map.Move()


        var result = new List<string>(directions.Count);
        for (int i=0; i<directions.Count; i++)
        {
            result[i] = Go(directions[i]);
        }
        return result;
    }
    public List<string> Go (string directions)
    {
        List<Direction> direction_parsed = DirectionParser.Parse(directions);
        return Go(direction_parsed);
    }
    public abstract int Power { get; }
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
