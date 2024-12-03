namespace Simulator;

public class Birds: Animals
{
    public bool CanFly { get; set; } = true;
    public Birds(string description, uint size, bool canFly = true) : base(description, size)
    {
        CanFly = canFly;
    }
    public override string Info => $"{Description} ({(CanFly? "fly+" : "fly-")}) <{Size}>";
    public override void Go(Direction direction)
    {
        if (Map != null)
        {
            if (CanFly)
            {
                var nextPosition = Map.Next(Map.Next(Position, direction), direction);
                Map.Move(this, Position, nextPosition);
                Position = nextPosition;
            }
            else
            {
                var nextPosition = Map.NextDiagonal(Position, direction);
                Map.Move(this, Position, nextPosition);
                Position = nextPosition;
            }
        }
    }
}
