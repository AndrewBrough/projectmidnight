using UnityEngine;
using System.Collections;

public class IIB_Trigger : MonoBehaviour {

	private GameObject player;
	public GameObject monster;
	bool monster_triggered; 

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (monster_triggered)
			if (26 > monster.transform.position.z)
				monster.transform.Translate (0, 0, Time.deltaTime * 8, Space.World);
		else {
			//this section is messy and I'm aware of it, basically, delete the instance of the monster
			//then destroy the trigger
			UnityEngine.Object.DestroyObject (monster);
			UnityEngine.Object.DestroyObject (transform.collider);
		}
	}

	void OnTriggerStay() {
		if (!monster_triggered) {
			if (Vector3.Angle (player.transform.forward, monster.transform.position - player.transform.position) < 30) 
				monster_triggered = true;
		}
	}
}
