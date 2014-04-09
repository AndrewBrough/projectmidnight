﻿/** Trigger for event 2A
 When player enters the trigger area, move crate to block off the path **/
using UnityEngine;
using System.Collections;

public class IIA_Trigger : MonoBehaviour {

	public GameObject crate;
	private GameObject player;
	public GameObject monster;
	public AudioClip crash;
	public AudioClip sighting;
	private GameObject mainCamera;

	public GameObject lightToDisable;

	bool crate_triggered; 
	bool monster_triggered; 
	private Vector3 targetPosition;



	// Use this for initialization
	void Start () {
		targetPosition.z = crate.transform.position.z - 6;
		print (crate.transform.position.z);
		player = GameObject.FindGameObjectWithTag ("Player");
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");

		monster.animation["run"].speed = 1.3f;
		monster.animation["idle"].speed = 1.3f;
		monster.animation.Play ("idle");

		


	}
	
	// Update is called once per frame
	void Update () {
		if (monster != null) {
			if (monster.transform.position.x > -25 && !crate_triggered) {
					crate_triggered = true;
					mainCamera.GetComponent<cameraShake> ().Shake ();
					crate.audio.PlayOneShot (crash);
			}
			if (crate_triggered) {
				lightToDisable.SetActive(false);
				if (targetPosition.z < crate.transform.position.z)
					crate.transform.Translate (0, 0, -1, Space.World);
			}
			if (monster_triggered){
				if (-12 > monster.transform.position.x){
					monster.transform.Translate (Time.deltaTime * 5, 0, 0, Space.World);
				} else {
					//this section is messy and I'm aware of it, basically, delete the instance of the monster
					//then disable the trigger
					UnityEngine.Object.DestroyObject (monster);
					UnityEngine.Object.DestroyObject (transform.collider);
					print (crate.transform.position.z);
				}
			}
		}
	}



	void OnTriggerStay() {
		if (!monster_triggered) {
						if (Vector3.Angle (player.transform.forward, monster.transform.position - player.transform.position) < 50) {
								//trigger monster
								monster_triggered = true;
								monster.audio.PlayOneShot(sighting);
								monster.animation.CrossFade("run");
								
						}
				}
	}
}
