using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int speed = 5;
    public float turnSpeed = 60;
    private Rigidbody2D rig;

    void Start () {
        rig = GetComponent<Rigidbody2D>();
	}

	void Update () {
        if(gameObject.tag == "Player_1")
        {
            float hAxis = Input.GetAxis("Horizontal_P1");
            float vAxis = Input.GetAxis("Vertical_P1");

            Vector2 movement = new Vector2(hAxis, vAxis);

            rig.AddForce(movement * speed);

            if (Input.GetButton("Player1_R1"))
            {
                transform.Rotate(-Vector3.forward * turnSpeed * Time.deltaTime);
            }

            if (Input.GetButton("Player1_L1"))
            {

                transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
            }
        }else if (gameObject.tag == "Player_2")
        {
            float hAxis = Input.GetAxis("Horizontal_P2");
            float vAxis = Input.GetAxis("Vertical_P2");

            Vector2 movement = new Vector2(hAxis, vAxis);

            rig.AddForce(movement * speed);

            if (Input.GetButton("Player2_R1"))
            {
                transform.Rotate(-Vector3.forward * turnSpeed * Time.deltaTime);
            }

            if (Input.GetButton("Player2_L1"))
            {

                transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
            }
		}else if (gameObject.tag == "Player_3")
		{
			float hAxis = Input.GetAxis("Horizontal_P3");
			float vAxis = Input.GetAxis("Vertical_P3");

			Vector2 movement = new Vector2(hAxis, vAxis);

			rig.AddForce(movement * speed);

			if (Input.GetButton("Player3_R1"))
			{
				transform.Rotate(-Vector3.forward * turnSpeed * Time.deltaTime);
			}

			if (Input.GetButton("Player3_L1"))
			{

				transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
			}
		}else if (gameObject.tag == "Player_4")
		{
			float hAxis = Input.GetAxis("Horizontal_P4");
			float vAxis = Input.GetAxis("Vertical_P4");

			Vector2 movement = new Vector2(hAxis, vAxis);

			rig.AddForce(movement * speed);

			if (Input.GetButton("Player4_R1"))
			{
				transform.Rotate(-Vector3.forward * turnSpeed * Time.deltaTime);
			}

			if (Input.GetButton("Player4_L1"))
			{

				transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
			}
		}
    }
}