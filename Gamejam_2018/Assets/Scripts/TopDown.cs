using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDown : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;


	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal_P1"), 0f, Input.GetAxisRaw("Vertical_P1"));
        moveVelocity = moveInput * moveSpeed;
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;

    }
}
