using UnityEngine;
using System.Collections;

public class IIC_Trigger : MonoBehaviour {

	public GameObject sound;
	public bool soundPlayed;


	// Use this for initialization
	void Start () {
		soundPlayed = false;
	}
	
	void OnTriggerEnter() {
		if (!soundPlayed) {
						sound.audio.Play ();
						soundPlayed = true;
				}

	}
}
