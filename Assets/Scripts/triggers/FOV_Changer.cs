using UnityEngine;
using System.Collections;

public class FOV_Changer : GameBehaviour {


	private float targetFOV = 60.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(world.camera.fieldOfView < targetFOV)
			world.camera.fieldOfView += 1.5f;

		if(world.camera.fieldOfView > targetFOV)
			world.camera.fieldOfView -= 1.5f;
	}

	void OnTriggerEnter(){
		targetFOV = 110.0f;
	}

	void OnTriggerExit(){
		targetFOV = 60.0f;
	}
}
