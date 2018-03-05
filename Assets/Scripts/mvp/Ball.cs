using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private const float MoveSpeed = 0.1f; 

    public float thrust = 1300f;
    public Rigidbody rb;
    public States.BallStates currentState;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        currentState = States.BallStates.Move;
    }
	
	// Update is called once per frame
	void Update () {
        if (currentState == States.BallStates.Move)
        {
            this.MoveControl();
        }            
    }

    // Called on the update when the state is Move
    private void MoveControl ()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(transform.forward * thrust);
            this.currentState = States.BallStates.Roll;
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
}
