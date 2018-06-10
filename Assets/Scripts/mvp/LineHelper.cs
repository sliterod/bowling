using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineHelper : MonoBehaviour
{
    public Ball Ball;

    private void Start()
    {
        this.Ball.StateChanged += this.OnChangeState;
    }

    public void OnChangeState(object source, BallEventArgs args)
    {
        if(args.NewState == States.BallStates.Roll)
        {
            this.gameObject.SetActive(false);
        }
    }
}
