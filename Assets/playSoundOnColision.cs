using UnityEngine;
using System.Collections;

public class playSoundOnColision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		PlayCollisionSound(other.gameObject);
	}

	void PlayCollisionSound(GameObject other){

	}
}
