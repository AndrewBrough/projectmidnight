using UnityEngine;
using System.Collections;

public class Monster_Collision : GameBehaviour {
	private GameObject player;

	void OnTriggerEnter(Collider other) {
		if(other.collider.CompareTag("Player")){
			world.player.GetComponent<playerStatus> ().Die ();
		}
	}
	void OnTriggerStay(Collider other) {
		if(other.collider.CompareTag("Player")){
			world.player.GetComponent<playerStatus> ().Die ();
		}
	}
}