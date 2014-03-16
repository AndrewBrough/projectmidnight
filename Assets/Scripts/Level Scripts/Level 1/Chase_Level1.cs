//what is even going on here

using UnityEngine;
using System.Collections;

public class Chase_Level1 : MonoBehaviour {

	public GameObject monster;
	public GameObject powerCell;
	public bool monsterTriggered;
	public GameObject door;
	public AudioClip growl;
	public AudioClip steps;
	public AudioClip doorClose;
	public AudioClip smash;
	public GameObject smashSource;
	private GameObject mainCamera;

	// Use this for initialization
	void Start () {
		monster.SetActive (false);
		monsterTriggered = false;
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		smashSource.audio.clip = smash;
	}
	
	// Update is called once per frame
	void Update () {
		if (powerCell.GetComponent<heldObjectProperties> ().held == true && !monster.activeInHierarchy) {
			monster.SetActive (true);
			monster.animation.Play("idle");
			monster.audio.clip = growl;
			monster.audio.Play();
		}

		if (monster.activeInHierarchy && monsterTriggered == false && !monster.audio.isPlaying) {
			monsterTriggered = true;
			monster.audio.clip = steps;
			monster.audio.Play();
			monster.animation.Play("run");
		}

		if (monsterTriggered == true && monster.activeInHierarchy) {
			monster.transform.Translate (0, 0, Time.deltaTime * -5, Space.World);
			if(!monster.audio.isPlaying)
				monster.audio.Play();
			monster.audio.loop = true;

		}

	}

	void OnTriggerEnter () {
		monster.SetActive (false);
		door.animation.Play ("close");
		door.audio.PlayOneShot (doorClose);
	}

	void OnTriggerExit() {
				mainCamera.GetComponent<cameraShake>().Shake ();
				smashSource.audio.Play();
		UnityEngine.Object.DestroyObject (transform.collider);
	}

	
}
