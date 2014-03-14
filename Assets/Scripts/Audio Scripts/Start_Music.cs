using UnityEngine;
using System.Collections;

public class Start_Music : GameBehaviour {

	public AudioSource music;

	// Use this for initialization
	void Start () {
		AudioSource[] playerAudio = world.player.GetComponents<AudioSource>();
		foreach(AudioSource a in playerAudio){
			print (a.clip.name);
			if(a.clip.name == "Shipping Container Room February 8 2014"){
				music = a;
				print ("found shipping container room");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(){
		if(!music.isPlaying)
			music.Play();
	}
}