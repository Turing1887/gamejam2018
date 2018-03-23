using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int speed = 5;
    float gravity = -9.8f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 pos = transform.position;
        //transform.position = new Vector3(pos.x, pos.y + gravity * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3 (pos.x - speed * Time.deltaTime, pos.y, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(pos.x + speed * Time.deltaTime, pos.y, 0);
        }


    }
}
