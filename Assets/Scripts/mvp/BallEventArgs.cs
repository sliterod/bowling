using System;
using System.Collections.Generic;
using UnityEngine;

public class BallEventArgs : EventArgs
{
    public States.BallStates NewState { get; set; }	
}
