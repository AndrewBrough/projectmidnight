using UnityEngine;
using System.Collections;

public class disableObject : GameBehaviour {

	public GameObject obj;

	void OnTriggerEnter(Collider other){
		if(other.collider.CompareTag("Player")){
			obj.SetActive(false);
		}
	}
}
