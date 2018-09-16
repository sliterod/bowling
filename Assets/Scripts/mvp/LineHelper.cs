using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineHelper : MonoBehaviour, IBar
{
    private const float BaseLength = 29.54f;

    private float lengthMultiplier = 1;

    public PlayerTurnController playerTurnController;

    public bool Visible
    {
        set
        {
            this.gameObject.SetActive(value);
        }
    }

    public float Value
    {
        set
        {
            this.lengthMultiplier = value;
        }
    }

    private void Start()
    {
        this.playerTurnController.StateChanged += this.OnChangeState;
    }

    public void OnChangeState(object source, BallEventArgs args)
    {
        if(args.NewState == States.TurnPhase.Roll)
        {
            this.gameObject.SetActive(false);
        }
    }
}
