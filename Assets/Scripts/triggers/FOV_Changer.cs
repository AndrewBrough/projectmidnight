using UnityEngine;
using System.Collections;

public class FOV_Changer : GameBehaviour {


	private float targetFOV = 60.0f;
	public bool isTriggered = false;
	public bool FOVisChanging = false;
	public float FOVChangeSpeed = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(world.camera.fieldOfView < targetFOV && FOVisChanging){
			world.camera.fieldOfView += FOVChangeSpeed;
		}

		if(world.camera.fieldOfView > targetFOV && FOVisChanging){
			world.camera.fieldOfView -= FOVChangeSpeed;
		}

		if(world.camera.fieldOfView == targetFOV){
			FOVisChanging = false;
		}
	}

	
	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			targetFOV = 110.0f;
			isTriggered = true;
			FOVisChanging = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.CompareTag("Player")){
			targetFOV = 60.0f;
			isTriggered = false;
			FOVisChanging = true;
		}
	}
}
