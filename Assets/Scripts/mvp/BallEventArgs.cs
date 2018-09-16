using System;
using System.Collections.Generic;
using UnityEngine;

public class BallEventArgs : EventArgs
{
    public States.TurnPhase NewState { get; set; }	
}
