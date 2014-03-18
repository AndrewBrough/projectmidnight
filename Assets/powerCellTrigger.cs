using UnityEngine;
using System.Collections;

public class powerCellTrigger : MonoBehaviour {


	public bool isTriggered = false;
	public int index = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other){
		if(other.CompareTag("powerCell") && other.gameObject.GetComponent<heldObjectProperties>().index == index){
			isTriggered = true;
		}
	}
	void OnTriggerExit(Collider other){
		if(other.CompareTag("powerCell")){
			isTriggered = false;
		}
	}
}
