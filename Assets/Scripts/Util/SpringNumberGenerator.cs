using System;
using UnityEngine;

public class SpringNumberGenerator : MonoBehaviour, INumberGenerator<float> {

    private float currentValue;
    private float speed = 0.8f;

    private void Start()
    {
        this.Reset();
    }

    private void Update()
    {
        this.currentValue = Mathf.PingPong(speed * Time.time, 1);
    }

    public float GetValue()
    {
        return this.currentValue;
    }

    public void Reset()
    {
        this.currentValue = 0;
    }
}
