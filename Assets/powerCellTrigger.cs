using UnityEngine;
using System.Collections;

public class powerCellTrigger : MonoBehaviour {


	public bool isTriggered = false;
	public int index = 0;

	private GameObject powercell;

	void Update(){
		if(powercell!=null){
			if(powercell.GetComponent<heldObjectProperties>().held){
				isTriggered = false;
			}
		}
	}
	void OnTriggerEnter(Collider other){
		if(other.CompareTag("powerCell") && other.gameObject.GetComponent<heldObjectProperties>().index == index){
			other.collider.transform.position = transform.position;
			other.collider.transform.rotation = transform.rotation;
			other.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			powercell = other.collider.gameObject;
			if(!isTriggered)
				powercell.audio.Play();
			isTriggered = true;
			powercell.GetComponent<heldObjectProperties>().isOnTrigger = true;
		}
	}
	void OnTriggerExit(Collider other){
		if(other.CompareTag("powerCell")){
			isTriggered = false;
			other.rigidbody.constraints = RigidbodyConstraints.None;
			powercell.GetComponent<heldObjectProperties>().isOnTrigger = false;
		}
	}
}
