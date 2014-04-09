using UnityEngine;
using System.Collections;

public class Monster_Collision : GameBehaviour {
	private GameObject player;

	void Update(){
		float DtoPlayer = Vector3.Distance(world.player.transform.position, transform.position);
		if(DtoPlayer<2.3f){
			world.player.GetComponent<playerStatus> ().Die (true);
		}
	}

//	void OnTriggerEnter(Collider other) {
//		if(other.collider.CompareTag("Player")){
//			world.player.GetComponent<playerStatus> ().Die ();
//		}
//	}
//	void OnTriggerStay(Collider other) {
//		if(other.collider.CompareTag("Player")){
//			world.player.GetComponent<playerStatus> ().Die ();
//		}
//	}
}