using UnityEngine;
using System.Collections;

public class IIIA_Trigger : MonoBehaviour {

	public GameObject door;
	public BoxCollider doorBoxCollider;

	void OnTriggerEnter(){
		//play open animation
		door.animation.Play ("close");
		//remove collider
		doorBoxCollider.enabled = true;
		//disable trigger
		this.enabled = false;
	}
}
