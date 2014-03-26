﻿using UnityEngine;
using System.Collections;

public class IVB_trigger : GameBehaviour {

	public GameObject monster;
	public GameObject crate1;
	public GameObject crate2;
	public GameObject crate3;
	public GameObject[] smallCrates;
	public GameObject force_location;

	private bool complete = false;

	public enum triggerType {
		collision=0,
		heldObject=1
	};

	public triggerType type = triggerType.heldObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(complete){
			monster.transform.LookAt( new Vector3(world.player.transform.position.x, 0, world.player.transform.position.z));
			if(Vector3.Distance(monster.transform.position, world.player.transform.position) > 2){
				Vector3 target = new Vector3(world.player.transform.position.x, monster.transform.position.y, world.player.transform.position.z);
				monster.transform.position = Vector3.MoveTowards(monster.transform.position, target, 0.04f);
			}
		}
	}

	void OnTriggerStay(Collider other){
		if(type == triggerType.heldObject){
			if(world.player.GetComponent<playerActions>().heldObject != null && !complete){
				StartCoroutine(MoveObjects());
				world.camera.GetComponent<cameraShake>().Shake();
			}
		}
		
		if(type == triggerType.collision){
			if(other.collider.CompareTag("Player") && !complete){
				StartCoroutine(MoveObjects());
				world.camera.GetComponent<cameraShake>().Shake();
				complete = true;
			}
		}
	}

	IEnumerator MoveObjects(){
		//move crates
		crate1.rigidbody.AddExplosionForce(2000.0f, force_location.transform.position, 100);
		crate2.rigidbody.AddExplosionForce(1000.0f, force_location.transform.position, 100);
		crate1.audio.Play();
		crate2.audio.Play();
//		yield return new WaitForSeconds(0.5f);
//		monster.transform.Translate(monster.transform.forward*-3);
		monster.animation.Play("run");
		yield return new WaitForSeconds(0.5f);
		//play roar animation and sfx
		monster.animation.Play("idle");
		monster.audio.Play ();
		yield return new WaitForSeconds(2);
		monster.animation.Play("run");
		complete = true;
	}
}
