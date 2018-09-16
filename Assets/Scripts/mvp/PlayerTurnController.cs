using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnController : MonoBehaviour {

    public IBall Ball;
    public IBar PowerBar;
    public States.TurnPhase currentState;
    public event EventHandler<BallEventArgs> StateChanged;

    // Use this for initialization
    void Start () {
        this.currentState = States.TurnPhase.Move;
        this.Ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<IBall>();
    }
	
	// Update is called once per frame
	void Update () {
        if (currentState == States.TurnPhase.Move)
        {
            this.MoveControl();
        }

        else if (currentState == States.TurnPhase.Rotate)
        {
            this.RotateControl();
        }
    }

    protected virtual void OnChangeState(States.TurnPhase newState)
    {
        if (StateChanged != null)
        {
            StateChanged(this, new BallEventArgs() { NewState = newState });
        }

    }

    private void ChangeState(States.TurnPhase newState)
    {
        this.currentState = newState;
        this.OnChangeState(newState);
    }

    private void MoveControl()
    {
        if (Input.GetKeyDown("space"))
        {
            this.ChangeState(States.TurnPhase.Rotate);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.Ball.MoveSideways(-1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.Ball.MoveSideways(1);
        }
    }

    private void RotateControl()
    {
        if (Input.GetKeyDown("space"))
        {
            this.Ball.Throw();
            this.ChangeState(States.TurnPhase.Roll);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.Ball.Rotate(-1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.Ball.Rotate(1);
        }
    }
}
