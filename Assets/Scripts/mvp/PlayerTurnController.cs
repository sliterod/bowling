using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnController : MonoBehaviour
{
    private const float MinBallThrust = 1200f;
    private const float MaxBallThrustDifference = 200f;

    public GameObject BallGameObject;
    public GameObject PowerBarGameObject;
    public States.TurnPhase currentPhase;
    public event EventHandler<BallEventArgs> StateChanged;

    private IBall ball;
    private IBar powerBar;
    private INumberGenerator<float> barPowerNumberGenerator;
    private float ballThrust = 1300f;

    // Use this for initialization
    void Start()
    {
        this.currentPhase = States.TurnPhase.Move;
        this.ball = BallGameObject.GetComponent<IBall>();
        this.powerBar = PowerBarGameObject.GetComponent<IBar>();
        this.barPowerNumberGenerator = this.GetComponent<INumberGenerator<float>>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPhase == States.TurnPhase.Move)
        {
            this.MoveControl();
        }

        else if (currentPhase == States.TurnPhase.Rotate)
        {
            this.RotateControl();
        }

        else if (currentPhase == States.TurnPhase.Force)
        {
            this.ForceControl();
        }
    }

    protected virtual void OnChangePhase(States.TurnPhase newState)
    {
        if (StateChanged != null)
        {
            StateChanged(this, new BallEventArgs() { NewState = newState });
        }

        if (newState == States.TurnPhase.Force)
        {
            this.powerBar.Visible = true;
            this.barPowerNumberGenerator.Reset();
            this.powerBar.Value = this.barPowerNumberGenerator.GetValue();
        }

        if (newState == States.TurnPhase.Roll)
        {
            this.ball.Throw();
        }
    }

    private void ChangePhase()
    {
        this.currentPhase = this.currentPhase.NextPhase();
        this.OnChangePhase(this.currentPhase);
    }

    private void MoveControl()
    {
        if (Input.GetKeyDown("space"))
        {
            this.ChangePhase();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.ball.MoveSideways(-1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.ball.MoveSideways(1);
        }
    }

    private void RotateControl()
    {
        if (Input.GetKeyDown("space"))
        {
            this.powerBar.Visible = false;
            this.ChangePhase();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.ball.Rotate(-1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.ball.Rotate(1);
        }
    }

    private void ForceControl()
    {
        if (Input.GetKeyDown("space"))
        {
            this.powerBar.Visible = false;
            this.ballThrust = MinBallThrust + (MaxBallThrustDifference * this.barPowerNumberGenerator.GetValue());
            this.ball.SetThrust(this.ballThrust);
            this.powerBar.Visible = false;
            this.ChangePhase();
        }
        else
        {
            this.powerBar.Value = this.barPowerNumberGenerator.GetValue();
        }
    }
}
