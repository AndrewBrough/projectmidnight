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
		UnityEngine.Object.DestroyObject (transform.collider);
		//transform.collider.isTrigger = false;
	}
}
