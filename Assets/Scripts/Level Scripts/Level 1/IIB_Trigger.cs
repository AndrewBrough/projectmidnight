using UnityEngine;
using System.Collections;

public class IIB_Trigger : MonoBehaviour {

	private GameObject player;
	//required game objects
	public GameObject monster;
	public GameObject growlSource;
	//sounds
	public AudioClip sighting;
	public AudioClip growl;

	bool monster_triggered; 

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		monster.animation.Play ("idle");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (monster_triggered && monster != null)
				if (40 > monster.transform.position.z) {
						monster.transform.Translate (0, 0, Time.deltaTime * 5, Space.World);
				}
		else {
			//this section is messy and I'm aware of it, basically, delete the instance of the monster
			//then destroy the trigger
			UnityEngine.Object.DestroyObject (monster);
			UnityEngine.Object.DestroyObject (transform.collider);
			growlSource.audio.PlayOneShot(growl);
		}
	}

	void OnTriggerStay(Collider other) {
		if (!monster_triggered && other.CompareTag("Player")) {
			if (Vector3.Angle (player.transform.forward, monster.transform.position - player.transform.position) < 40) 
				monster_triggered = true;
				monster.audio.PlayOneShot(sighting);
				monster.animation.CrossFade("run");
		}
	}
}
