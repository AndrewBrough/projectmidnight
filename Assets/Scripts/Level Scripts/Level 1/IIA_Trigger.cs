/** Trigger for event 2A
 When player enters the trigger area, move crate to block off the path **/
using UnityEngine;
using System.Collections;

public class IIA_Trigger : MonoBehaviour {

	public GameObject crate;
	private GameObject player;
	public GameObject monster;


	bool crate_triggered; 
	bool monster_triggered; 
	private Vector3 targetPosition;



	// Use this for initialization
	void Start () {
		targetPosition.z = crate.transform.position.z - 6;
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		if (crate_triggered) {
						if (targetPosition.z < crate.transform.position.z)
								crate.transform.Translate (0, 0, -1, Space.World);
				}
		if (monster_triggered && monster != null)
				if (-22 > monster.transform.position.x)
						monster.transform.Translate (Time.deltaTime *  8, 0, 0, Space.World);
				else {
						//this section is messy and I'm aware of it, basically, delete the instance of the monster
						//then disable the trigger
						UnityEngine.Object.DestroyObject (monster);
						UnityEngine.Object.DestroyObject (transform.collider);
				}
	}


	void OnTriggerStay() {
		if (!monster_triggered) {
						if (Vector3.Angle (player.transform.forward, monster.transform.position - player.transform.position) < 40) {
								//trigger monster
								monster_triggered = true;
								crate_triggered = true;
						}
				}
	}
}
