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
    public abstract void SayHi();
    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }
    public void Go (Direction direction)
    {
        string direction_lowercase = direction.ToString().ToLower();
        Console.WriteLine($"{name} goes to {direction_lowercase}");
    }
    public void Go (Direction[] directions)
    {
        foreach (var direction in directions) Go(direction);
    }
    public void Go (string directions)
    {
        Direction[] direction_parsed = DirectionParser.Parse(directions);
        Go(direction_parsed);
    }
    public abstract int Power { get; }
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
