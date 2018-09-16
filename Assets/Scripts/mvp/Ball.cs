using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IBall
{

    private const float MoveSpeed = 0.1f;
    private const float RotationSpeed = 5f;
    private const float MaxRotation = 50f;

    private float thrust = 1300f;

    public Rigidbody rb;
    public Vector3 ShotDirection;

    // Use this for initialization
    void Start () {
        this.rb = GetComponent<Rigidbody>();
        this.ShotDirection = transform.forward;
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void Rotate(float direction)
    {
        this.transform.Rotate(Vector3.up * RotationSpeed * direction * Time.deltaTime);
    }

    public void MoveSideways(float direction)
    {
        Vector3 position = this.transform.position;
        position.x += MoveSpeed * direction;
        this.transform.position = position;
    }

    public void SetThrust(float thrust)
    {
        this.thrust = thrust;
    }

    public void Throw()
    {
        rb.AddRelativeForce(ShotDirection * thrust);
    }
}
