using UnityEngine;
using System.Collections;

public class II_Trigger : MonoBehaviour {

	public GameObject crate;
	private GameObject player;

	bool crate_triggered; 
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
			else
				UnityEngine.Object.DestroyObject (transform.collider);
		}
	}

	void OnTriggerEnter() {
		crate_triggered = true;
	}
}
