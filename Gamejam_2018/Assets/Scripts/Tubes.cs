using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubes : MonoBehaviour {

	string tube;
	public bool isLocked = false;
	public string lockedPlayer;

	// Use this for initialization
	void Start () {
		tube = gameObject.tag;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(!isLocked){
			coll.gameObject.SetActive (false);
			lockedPlayer = coll.gameObject.tag;
			isLocked = true;
		}
	}

}
