using UnityEngine;
using System.Collections;

public class FootstepsPlay : MonoBehaviour {

	public AudioSource audio;

	// Use this for initialization
	void Start () {
		audio.Stop ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKey ("w") || Input.GetKey ("d") || Input.GetKey ("a") || Input.GetKey ("s")) && !audio.isPlaying) {
			if(audio.mute)
				audio.mute = false;
			audio.Play();
			if(!audio.loop)
				audio.loop = true;


		} else if (Input.GetKeyUp ("w") || Input.GetKeyUp ("d") || Input.GetKeyUp ("a") || Input.GetKeyUp ("s")) {
					audio.loop = false;
				}
	}
}
