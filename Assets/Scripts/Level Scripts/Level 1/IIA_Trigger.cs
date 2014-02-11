/** Trigger for event 2A
 When player enters the trigger area, move crate to block off the path **/
using UnityEngine;
using System.Collections;

public class IIA_Trigger : MonoBehaviour {

	public GameObject crate;


	bool triggered; 
	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		targetPosition.z = crate.transform.position.z - 6;


	}
	
	// Update is called once per frame
	void Update () {
		if (triggered) {
			if(targetPosition.z < crate.transform.position.z)
				crate.transform.Translate(0,0, -1, Space.World);
				}
	}

	void OnTriggerEnter() {
		if (!triggered) 
			triggered = true; 
	}
}
