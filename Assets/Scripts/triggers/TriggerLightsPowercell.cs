using UnityEngine;
using System.Collections;

public class TriggerLightsPowercell : MonoBehaviour {
	
	public bool isOn;
	public Light targetLight;
	
	// Use this for initialization
	void Start () {
		isOn = false;
	}
	
	void OnTriggerEnter(Collider other) {
		//check if left mouse button is pressed
		if(other.gameObject.CompareTag("powerCell") || other.gameObject.CompareTag("lantern"))
		{
			//print ("power cell on pedastel");
			turnOnLights();
			isOn = true;
		}
	}
	
	void OnTriggerExit(Collider other){
		if(other.gameObject.CompareTag("powerCell") || other.gameObject.CompareTag("lantern"))
		{
			//print ("power cell taken off of pedastel");
			turnOnLights();
			isOn = false;
		}
	}
	
	void turnOnLights(){
		if(!isOn){
			targetLight.enabled = true;
		}
		else {
			targetLight.enabled = false;
		}
	}
}
