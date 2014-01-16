using UnityEngine;
using System.Collections;

public class TriggerLightsPowercell : MonoBehaviour {
	
	public Light targetLight;
	
	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerEnter(Collider other) {
		//check if left mouse button is pressed
		if(other.gameObject.CompareTag("powerCell") || other.gameObject.CompareTag("lantern"))
		{
			//print ("power cell on pedastel");
			turnOnLights();
		}
	}
	
	void OnTriggerExit(Collider other){
		if(other.gameObject.CompareTag("powerCell") || other.gameObject.CompareTag("lantern"))
		{
			//print ("power cell taken off of pedastel");
			turnOnLights();
		}
	}
	
	void turnOnLights(){
		if(!targetLight.enabled){
			targetLight.enabled = true;
		}
		else {
			targetLight.enabled = false;
		}
	}
}
