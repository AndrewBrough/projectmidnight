using UnityEngine;
using System.Collections;

public class RemoveWaypoint : MonoBehaviour {

	void OnTriggerEnter(){
		foreach(Transform child in transform){
			if(child.gameObject.tag == "waypoint"){
				Destroy(child.gameObject);
			}
		}
		print ("removed waypoint");
	}
}
