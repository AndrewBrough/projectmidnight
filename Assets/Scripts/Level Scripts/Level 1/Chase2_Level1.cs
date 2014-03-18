using UnityEngine;
using System.Collections;

public class Chase2_Level1 : MonoBehaviour {
	public GameObject smashSource;
	private GameObject mainCamera;

	void Start() {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		}

	void OnTriggerEnter () {
		mainCamera.GetComponent<cameraShake>().Shake ();
		smashSource.audio.Play();
		UnityEngine.Object.DestroyObject (transform.collider);
	}
}
