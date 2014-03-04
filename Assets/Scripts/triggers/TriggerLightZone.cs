using UnityEngine;
using System.Collections;

public class TriggerLightZone : GameBehaviour {
	
	public BoxCollider zoneCollider;

	void Start() {
		
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")){
			print ("Entered a light zone");
			world.darknessDisable = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.CompareTag("Player")){
			print ("Left a light zone");
			world.darknessDisable = false;
		}
	}

}
