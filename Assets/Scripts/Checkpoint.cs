using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	public GameObject checkpoint;
	void OnTriggerStay(Collider other) {
		if(other.gameObject.CompareTag("Player")){
			Debug.Log("Checkpoint!");
			playerStatus player = (playerStatus)other.gameObject.GetComponent(typeof(playerStatus));
			player.spawnPoint = checkpoint.transform.position;
			Destroy(checkpoint);
		}	
	}
	
}


