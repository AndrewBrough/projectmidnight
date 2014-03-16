using UnityEngine;
using System.Collections;

public class FOV_Changer : GameBehaviour {
	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			world.player.GetComponent<playerStatus>().FOVisChanging ++;
			world.player.GetComponent<playerStatus>().targetFOV = 90.0f;
		}
	}
	void OnTriggerExit(Collider other){
		if(other.CompareTag("Player")){
			world.player.GetComponent<playerStatus>().FOVisChanging --;
			world.player.GetComponent<playerStatus>().targetFOV = 60.0f;
		}
	}
}
