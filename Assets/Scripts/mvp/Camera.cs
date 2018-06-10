using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    const float zOffset = -10f;

    public Transform Ball; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = this.transform.position;
        position.z = Mathf.Clamp(Ball.position.z + zOffset, -100f, 10f);
        this.transform.position = position;

    }
}
