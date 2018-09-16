using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineHelper : MonoBehaviour, IBar
{
    private const float BaseLength = 29.54f;

    private float lengthMultiplier = 1;

    public PlayerTurnController playerTurnController;

    private void Start()
    {
        this.playerTurnController.StateChanged += this.OnChangeState;
    }

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
            this.transform.localScale = new Vector3(1, 1, BaseLength * value);
        }
    }

    public void OnChangeState(object source, BallEventArgs args)
    {
        if(args.NewState == States.TurnPhase.Roll)
        {
            this.gameObject.SetActive(false);
        }
    }
}
