using UnityEngine;
using System.Collections;

public class TriggerDarkZone : GameBehaviour {
	
	public BoxCollider zoneCollider;
	
	void Start() {
		
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")){
			world.forceDarkness = true;
			
		}
	}
	
	void OnTriggerExit(Collider other){
		if(other.gameObject.CompareTag("Player")){
			world.forceDarkness = false;
		}
	}
	
}
