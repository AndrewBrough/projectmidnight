using UnityEngine;
using System.Collections;

public class playerSight : MonoBehaviour {

	private GameObject monster;
	private SphereCollider col;

	// Use this for initialization
	void Awake () {
		monster = GameObject.FindGameObjectWithTag ("Monster");
		print (monster);
		col = GetComponent<SphereCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		print (other.name + "," + monster.name);
		//print (monster.name);
		if (other.gameObject.name == monster.name) {
			print ("I see the monster");


				}

	}
}
