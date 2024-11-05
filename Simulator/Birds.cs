﻿namespace Simulator;

internal class Birds: Animals
{
    public bool CanFly { get; set; } = true;
    public override string Info => $"{Description} ({(CanFly? "fly+" : "fly-")}) <{Size}>";

}
