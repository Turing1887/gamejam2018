using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float offset = 16f;
    public float smoothTime = 1f;

    private Vector3 oldPos;
    private Vector3 velocity = Vector3.zero;
    private bool move = false;
	public GameController controller;

    // Use this for initialization
    void Start () {
		controller = GameObject.Find ("GameManager").GetComponent<GameController> ();
        oldPos = gameObject.transform.position;
    }


    private void LateUpdate()
    {
        if (move)
        {
            float newY = oldPos.y - offset;
            Vector3 targetPos = new Vector3(oldPos.x, newY, oldPos.z);
            gameObject.transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
//				controller.Spawn ();
                move = false;
                oldPos = gameObject.transform.position;
            }
        }
  
    }

    public void enableCam()
    {
        move = true;
    }
}
