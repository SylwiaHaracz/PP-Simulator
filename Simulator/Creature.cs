namespace Simulator;

public abstract class Creature
{
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
    public string[] Go (Direction[] directions)
    {
        var result = new string[directions.Length];
        for (int i=0; i<directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }
        return result;
    }
    public string[] Go (string directions)
    {
        Direction[] direction_parsed = DirectionParser.Parse(directions);
        return Go(direction_parsed);
    }
    public abstract int Power { get; }
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
