using UnityEngine;
using System.Collections;

public class IIC_Trigger : MonoBehaviour {

	public GameObject sound;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter() {
		sound.audio.Play ();

	}
}
