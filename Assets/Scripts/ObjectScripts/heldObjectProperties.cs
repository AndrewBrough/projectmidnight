using UnityEngine;
using System.Collections;

public class heldObjectProperties : GameBehaviour {
	
	public bool held;
	public bool isOnTrigger;
	public float DtoPlayer;
	
	// Use this for initialization
	void Start () {
		held = false;
		isOnTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!held) getDistanceToPlayer();
		
		//if on a trigger, don't move the object with physics
		if(isOnTrigger)
			this.rigidbody.isKinematic = true;
		else if(!isOnTrigger)
			this.rigidbody.isKinematic = false;

		if(this.transform.position.y <= -50){
			Vector3 reset = world.player.transform.position;
			this.transform.position = reset;
		}
	}
	
	void getDistanceToPlayer(){
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		
		DtoPlayer = Vector3.Distance( players[0].transform.position, this.transform.position );
	}
}
