using UnityEngine;
using System.Collections;

public class OpenDoorOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(){
		animation.Play("Open");
	}
}
