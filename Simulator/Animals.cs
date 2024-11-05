namespace Simulator;

public class Animals
{
    private string description = "Unknown";
    public required string Description 
    {
        get { return description; }
        init
        {
            description = value.Trim();
            if (description.Length > 15)
            {
                description = description.Substring(0, 15);
                description = description.Trim();
            }
            if (description.Length < 3)
            {
                description = description.PadRight(3, '#');
            }
            description = description[0].ToString().ToUpper() + description.Substring((1));
        }
    }
    public uint Size { get; set; } = 3;
    public virtual string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
