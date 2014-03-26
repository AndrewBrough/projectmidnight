using UnityEngine;
using System.Collections;

public class Monster_Collision : GameBehaviour {
	private GameObject player;

	void Start() {
	}
	void OnTriggerEnter(Collider other) {
		if(other.collider.CompareTag("Player")){
			world.player.GetComponent<playerStatus> ().Die ();
		}
	}
}