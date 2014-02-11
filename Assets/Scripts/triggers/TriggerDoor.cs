/** Script attached to trigger that Player activates to open door **/
using UnityEngine;
using System.Collections;

public class TriggerDoor : MonoBehaviour {
	
	bool isOpen;
	public BoxCollider doorBoxCollider;
	public GameObject doorAnimation;

	// Use this for initialization
	void Start () {
		isOpen = false;
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
					openDoor();
			}
			
		}
		
	}
	
	void openDoor() {
		if(!isOpen) {
			//play open animation
			doorAnimation.animation.Play ("open");
			//remove collider
			doorBoxCollider.enabled = false;
			//set open to true
			isOpen = true;
		}
		else if(isOpen) {
			//play open animation
			doorAnimation.animation.Play ("close");
			//remove collider
			doorBoxCollider.enabled = true;
			//set open to true
			isOpen = false;
			
		}
	}
}
