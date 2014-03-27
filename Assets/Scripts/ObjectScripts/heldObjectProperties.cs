using UnityEngine;
using System.Collections;

public class heldObjectProperties : GameBehaviour {
	
	public bool held;
	public bool targetted;
	public bool isOnTrigger;
	public float DtoPlayer;
	public int index = 0;
	private Vector3 startPosition;
	public Material[] startMaterials;

	// Use this for initialization
	void Start () {
		held = false;
		targetted = false;
		isOnTrigger = false;
		startPosition = transform.position;
		startMaterials = new Material[renderer.materials.Length];
		startMaterials = renderer.materials;
	}
	
	// Update is called once per frame
	void Update () {
		if(!held){
			getDistanceToPlayer();
			rigidbody.isKinematic = false;
			collider.enabled = true;
		}
		//disable collisions when held so as not to send player flying
		if(held){
			rigidbody.isKinematic = true;
			collider.enabled = false;
		}
		//catch if it fell through ground...
		if(this.transform.position.y <= -50){
//			Vector3 reset = world.player.transform.position;
			this.transform.position = startPosition;
			this.rigidbody.velocity = Vector3.zero;
		}
		//change material to default
		if(!targetted){
			renderer.materials = startMaterials;
//			renderer.material = startMaterial;
		}
		targetted = false;
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
