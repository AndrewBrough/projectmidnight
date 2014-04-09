using UnityEngine;
using System.Collections;

public class FinaleEvent : GameBehaviour {

	public GameObject lightToClone;
	private GameObject newLight;
	public GameObject targetLook;
	private bool opened = false;
	private Vector3 vacuumSpeed = new Vector3(0,0,-0.2f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(animation.isPlaying){
			opened = true;
		}

		if(opened && !animation.isPlaying){
			//suck player out of door into space

			world.player.transform.position += vacuumSpeed;
			world.player.GetComponent<CharacterMotorC>().enabled = false;
			world.player.GetComponent<MouseLook>().enabled = false;
			world.player.GetComponentInChildren<Camera>().GetComponent<MouseLook>().enabled = false;
			world.player.GetComponentInChildren<Camera>().transform.LookAt(targetLook.transform);

			if(newLight == null){
				newLight = Instantiate(lightToClone) as GameObject;
				world.lights[0] = newLight.GetComponent<Light>();
				newLight.transform.position = world.player.transform.position;
				newLight.transform.parent = world.player.transform;
			}
		}
	}
}