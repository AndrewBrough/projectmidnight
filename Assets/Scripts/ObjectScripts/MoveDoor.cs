using UnityEngine;
using System.Collections;

public class MoveDoor : GameBehaviour {

	private GameObject door;
	private bool active = false;
	private Vector3 startpoint;
	private Vector3 endpoint;
	private float starttime = 0;

	// Use this for initialization
	void Start () {
		door = transform.GetChild(0).gameObject;
		startpoint = transform.position;
		endpoint = new Vector3( transform.position.x-3, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if(active){
			print (door.transform.position);
			door.transform.position = new Vector3( door.transform.position.x-0.1f, door.transform.position.y, door.transform.position.z);
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			starttime = Time.time;
			active = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.CompareTag("Player")){
			active = false;
		}
	}
}