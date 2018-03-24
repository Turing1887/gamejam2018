using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermMovement : MonoBehaviour
{

    public float speed = 9;
    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal_P1");
        float vAxis = Input.GetAxis("Vertical_P1");

        float rStickX = Input.GetAxis("360_RStickX");

        Vector3 lookVec = new Vector3(Input.GetAxis("Horizontal_P1"), Input.GetAxis("Vertical_P1"), 4096);
        Vector3 movement = transform.TransformDirection(new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime);

        if (lookVec.x != 0 && lookVec.y != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookVec, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
        }
    }
}
