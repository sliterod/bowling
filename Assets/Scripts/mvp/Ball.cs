using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private const float MoveSpeed = 0.1f;
    private const float RotationSpeed = 5f;
    private const float MaxRotation = 50f;

    public float thrust = 1300f;
    public Rigidbody rb;
    public States.BallStates currentState;
    public Vector3 ShotDirection;

    public event EventHandler<BallEventArgs> StateChanged;

    // Use this for initialization
    void Start () {
        this.rb = GetComponent<Rigidbody>();
        this.currentState = States.BallStates.Move;
        this.ShotDirection = transform.forward;
    }
	
	// Update is called once per frame
	void Update () {
        if (currentState == States.BallStates.Move)
        {
            this.MoveControl();
        }

        else if (currentState == States.BallStates.Rotate)
        {
            this.RotateControl();
        }

    }

    protected virtual void OnChangeState(States.BallStates newState)
    {
        if (StateChanged != null)
        {
            StateChanged(this, new BallEventArgs() { NewState = newState });
        }

    }

    // Called on the update when the state is Move
    private void MoveControl ()
    {
        if (Input.GetKeyDown("space"))
        {
            this.ChangeState(States.BallStates.Rotate);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x -= MoveSpeed;
            this.transform.position = position;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x += MoveSpeed;
            this.transform.position = position;
        }
    }

    private void RotateControl ()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.AddRelativeForce(ShotDirection * thrust);
            this.ChangeState(States.BallStates.Roll);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.up * -RotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
        }
    }

    private void ChangeState(States.BallStates newState)
    {
        this.currentState = newState;
        this.OnChangeState(newState);
    }
}
