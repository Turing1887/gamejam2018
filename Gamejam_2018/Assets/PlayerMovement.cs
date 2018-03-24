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
<<<<<<< HEAD

=======
>>>>>>> 40a5e446cb8ba7bfbab7081f003c800a7928dca3
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

            if (Input.GetButton("Player1_R1"))
            {
                transform.Rotate(-Vector3.forward * turnSpeed * Time.deltaTime);
            }

            if (Input.GetButton("Player1_L1"))
            {

                transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
            }
        }
    }
}