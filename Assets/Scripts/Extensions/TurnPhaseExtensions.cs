
using System;
using System.Linq;

public static class TurnPhaseExtensions
{
    public static States.TurnPhase FinalPhase(this States.TurnPhase @this)
    {
        return Enum.GetValues(typeof(States.TurnPhase)).Cast<States.TurnPhase>().Max();
    }

    public static States.TurnPhase NextPhase(this States.TurnPhase @this)
    {
        if (@this != @this.FinalPhase())
        {
            return @this + 1;
        }

        return 0;
    }
}