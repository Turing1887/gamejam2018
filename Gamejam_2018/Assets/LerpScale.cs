using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpScale : MonoBehaviour {

    public float bubbleSpeed = 3f;
    public Vector3 size = new Vector3(5f, 5f, 1f);
    public float timeToDest = 3f;

    private float t;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.up * bubbleSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime / timeToDest;
        transform.localScale = Vector3.Lerp(transform.localScale, size, t);
	}
}
