using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubes : MonoBehaviour {

	string tube;
	public bool isLocked = false;
	public string lockedPlayer;
	public GameController contr;

	// Use this for initialization
	void Start () {
		tube = gameObject.tag;
		contr = GameObject.Find ("GameManager").GetComponent<GameController>();
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(!isLocked){
//			coll.gameObject.SetActive (false);
			Destroy(coll.gameObject);
			lockedPlayer = coll.gameObject.tag;
			if (tube == "Tube_1") {
				contr.tubes [0] = lockedPlayer;
			}else if(tube == "Tube_2"){
				contr.tubes [1] = lockedPlayer;
			}else if(tube == "Tube_3"){
				contr.tubes [2] = lockedPlayer;
			}else if(tube == "Tube_4"){
				contr.tubes [3] = lockedPlayer;
			}
			isLocked = true;
		}
	}

}
