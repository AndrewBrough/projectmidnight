using UnityEngine;
using System.Collections;

public class heldObjectProperties : GameBehaviour {
	
	public bool held;
	public bool isOnTrigger;
	public float DtoPlayer;
	public int index = 0;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		held = false;
		isOnTrigger = false;
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!held){
			getDistanceToPlayer();
			rigidbody.isKinematic = false;
		}
		//disable collisions when held so as not to send player flying
		if(held){
			rigidbody.isKinematic = true;
		}
		if(this.transform.position.y <= -50){
//			Vector3 reset = world.player.transform.position;
			this.transform.position = startPosition;
			this.rigidbody.velocity = Vector3.zero;
		}
	}

	void OnTriggerStay(){
//		if(!held)
//			this.rigidbody.isKinematic = true;
//		this.transform.rotation = Quaternion.identity;
	}
	void OnTriggerExit(){
//		this.rigidbody.isKinematic = false;
	}

	void getDistanceToPlayer(){
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		
		DtoPlayer = Vector3.Distance( players[0].transform.position, this.transform.position );
	}
}
