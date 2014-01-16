using UnityEngine;
using System.Collections;

public class TriggerLights : MonoBehaviour {
	
	bool isOn;
	public Light targetLight;
	
	// Use this for initialization
	void Start () {
		isOn = false;
	}
	
	void OnTriggerStay(Collider other) {
		//check if left mouse button is pressed
		if(Input.GetMouseButtonDown(0))
		{
			//check if collider is player, maybe not necessary?
			if(other.gameObject.CompareTag("Player")){
				//check to make sure player isn't holding something
				GameObject player = GameObject.FindWithTag("Player");	
				if(player.GetComponent<playerActions>().heldObject == null)
					turnOnLights();
			}
			
		}
		
	}
	
	void turnOnLights(){
		if(!isOn){
			//GameObject point_light_left = GameObject.Find("point_light_left");
			//point_light_left.light.enabled = true;
			targetLight.enabled = true;
			isOn = true;
		}
		else {
			//GameObject point_light_left = GameObject.Find("point_light_left");
			//point_light_left.light.enabled = false;
			targetLight.enabled = false;
			isOn = false;
		}
	}
}
