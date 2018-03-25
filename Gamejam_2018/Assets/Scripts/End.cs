using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {

	private Animator anim;

	void Start() {
		anim = GetComponent<Animator> ();
	}

	IEnumerator WaitForIt(float waitTime) {
		yield return new WaitForSeconds (waitTime);
		Application.LoadLevel ("start"); //load first scene again (Restart the Game)
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Player_1" || other.gameObject.tag == "Player_2" || other.gameObject.tag == "Player_3" || other.gameObject.tag == "Player_4") 
		{
			Destroy(other.gameObject);
			anim.SetTrigger ("fade");
			StartCoroutine(WaitForIt(4.0F));
		}
	}
}