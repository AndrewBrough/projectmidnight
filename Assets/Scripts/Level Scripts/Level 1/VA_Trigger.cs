using UnityEngine;
using System.Collections;

public class VA_Trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
		//find all the office lights
		foreach(GameObject lightObj in GameObject.FindGameObjectsWithTag("TriggerLight"))
		{
			if(lightObj.name == "5A_Standard_Light"){
				if(!lightObj.transform.light.enabled)
					lightObj.transform.light.enabled = true;
				else
					lightObj.transform.light.enabled = false;
			}
		}
	}
}
