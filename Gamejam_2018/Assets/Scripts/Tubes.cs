using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubes : MonoBehaviour {

	string tube;
	public bool isLocked = false;

	// Use this for initialization
	void Start () {
		tube = gameObject.tag;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "Player" && !isLocked){
			coll.gameObject.SetActive (false);
			isLocked = true;
		}
	}

}
