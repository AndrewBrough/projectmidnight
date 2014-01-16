using UnityEngine;
using System.Collections;

public class heldObjectProperties : MonoBehaviour {
	
	public bool held;
	public float DtoPlayer;
	
	// Use this for initialization
	void Start () {
		held = false;
	}
	
	// Update is called once per frame
	void Update () {
		//print (this.transform.position);
		
		if(!held) getDistanceToPlayer();
	}
	
	void getDistanceToPlayer(){
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		
		DtoPlayer = Vector3.Distance( players[0].transform.position, this.transform.position );
	}
}
