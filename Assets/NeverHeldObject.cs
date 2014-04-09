using UnityEngine;
using System.Collections;

public class NeverHeldObject : GameBehaviour {

	private heldObjectProperties heldobjprop;

	// Use this for initialization
	void Start () {
		heldobjprop = GetComponent<heldObjectProperties>();
	}
	
	// Update is called once per frame
	void Update () {
		if(world.player.GetComponent<playerActions>().heldObject == this){
			world.player.GetComponent<playerActions>().heldObject = null;
		}
	}
}