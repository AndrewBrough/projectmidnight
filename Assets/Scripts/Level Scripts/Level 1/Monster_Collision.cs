using UnityEngine;
using System.Collections;

public class Monster_Collision : MonoBehaviour {
	private GameObject player;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	void OnTriggerEnter(Collider other) {	
						player.GetComponent<playerStatus> ().Die ();
	}
}
