using UnityEngine;
using System.Collections;

public class playSoundOnCollision : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		PlayCollisionSound(other);
	}
	void OnCollisionStay(Collision other){
		PlayCollisionSound(other);
	}
	void PlayCollisionSound(Collision other){
		//check magniture of relative velocity of rigidbody, if more than 0.5 then play sound
		if(other.relativeVelocity.magnitude > 2 && !audio.isPlaying){
			audio.volume = other.relativeVelocity.magnitude-2;
			this.audio.Play();
		}
	}
}