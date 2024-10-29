namespace Simulator;

internal class Creature
{
    private string name;
    private int level;

    public string Name
    {
        set { name = value; }
    }
    public int Level
    {
        set { level = value > 0 ? value : 1; }
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

}
