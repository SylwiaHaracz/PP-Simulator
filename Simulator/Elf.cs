namespace Simulator;

internal class Elf: Creature
{
    private int agility;
    private int sing_count = 0;
    public int Agility
    {
        get { return agility; }
        init
        {
            agility = Validator.Limiter(value, 0, 10);
        }
    }
    public override int Power => 8 * Level + 2 * agility;
    public void Sing() 
    {
        sing_count++;
        if (sing_count % 3 == 0)
        {
            if (agility < 10)
            {
                agility++;
            }
        }
        Console.WriteLine($"{Name} is singing.");
    }
    public Elf() { }
    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {agility}.");
    public override string Info => $"{Name} [{Level}][{Agility}]";
}
