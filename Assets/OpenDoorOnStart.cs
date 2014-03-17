using UnityEngine;
using System.Collections;

public class OpenDoorOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.animation.Play("Open");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
