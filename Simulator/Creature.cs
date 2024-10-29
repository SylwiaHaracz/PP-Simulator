namespace Simulator;

internal class Creature
{
    private string name = "Unknown";
    private int level;

    public string Name {
        get { return name; }
        init
        {
            name = value.Trim();
            if (name.Length > 25)
            {
                name = name.Substring(0, 25);
                name = name.Trim();
            }
            if (name.Length < 3)
            {
                name = name.PadRight(3, '#');
            }
            name = name[0].ToString().ToUpper() + name.Substring((1));
            
        }
        
    }
    public int Level
    {
        init 
        { 
            if (value < 1)
            {
                level = 1;
            }
            else if (value > 10)
            {
                level = 10;
            }
            else
            {
                level = value;
            }
            
        }
    }
    public string Info
    {
        get { return $"{name} [{level}]"; }
    }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature() {}
    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {name}, my level is {level}.");
    }

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }

}
