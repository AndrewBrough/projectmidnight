using UnityEngine;
using System.Collections;

public class heldObjectProperties : GameBehaviour {
	
	public bool held;
	public bool isOnTrigger;
	public float DtoPlayer;
	public int index = 0;

	// Use this for initialization
	void Start () {
		held = false;
		isOnTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!held) getDistanceToPlayer();

		if(this.transform.position.y <= -50){
			Vector3 reset = world.player.transform.position;
			this.transform.position = reset;
		}
	}

	void OnTriggerStay(){
		if(!held)
			this.rigidbody.isKinematic = true;
//		this.transform.rotation = Quaternion.identity;
	}
	void OnTriggerExit(){
		this.rigidbody.isKinematic = false;
	}

	void getDistanceToPlayer(){
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		
		DtoPlayer = Vector3.Distance( players[0].transform.position, this.transform.position );
	}
}
