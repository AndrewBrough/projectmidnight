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
			powercell = other.collider.gameObject;
			if(!isTriggered)
				audio.Play();
			isTriggered = true;
		}
	}
	void OnTriggerExit(Collider other){
		if(other.CompareTag("powerCell"))
		   isTriggered = false;
	}
}
