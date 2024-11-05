namespace Simulator;

internal class Orc: Creature
{
    //public int Rage { get; set; } = 1;

    private int rage;
    private int hunt_count = 0;
    public int Rage
    {
        get { return rage; }
        init
        {
            if (value < 1)
            {
                rage = 1;
            }
            else if (value > 10)
            {
                rage = 10;
            }
            else
            {
                rage = value;
            }

        }
    }
    public override int Power => 7 * Level + 3 * rage;
    public void Hunt()
    {
        hunt_count++;
        if (hunt_count % 2 == 0)
        {
            if (rage < 10)
            {
                rage++;
            }
        }
        Console.WriteLine($"{Name} is hunting.");
    }
    public Orc() { }
    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {rage}.");
}
