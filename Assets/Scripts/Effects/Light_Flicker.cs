using UnityEngine;
using System.Collections;

public class Light_Flicker : MonoBehaviour {

	private Light[] lights;
	private bool lightsOn;
	private Color defaultColour;

	public float variation = 0;
	public bool flickerMaterial = true;

	//hold instantiated sparks so can be destroyed later
//	private ArrayList sparks = new ArrayList();

	// Use this for initialization
	void Start () {
		//save default material
		if(flickerMaterial)
			defaultColour = renderer.material.color;

		//flicker stuff
		lights = this.GetComponentsInChildren<Light>();

		if(lights.Length == 0)
			lights = this.GetComponents<Light>();

		for(int i = 0; i < lights.Length; i++){
			lights[i].GetComponent<Light>().enabled = false;
			lightsOn = false;
		}
		StartCoroutine(Flickering());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator Flickering(){
		//start flickering
		while(true){
			int random1 = Random.Range(0, 5);
			for(int i = 0; i< random1; i++){
				flickerOn();
				yield return new WaitForSeconds(Random.Range(0.0f, 0.05f + variation));
				flickerOff();
				yield return new WaitForSeconds(Random.Range(0.0f, 0.05f + variation));
			}
			flickerOff();
			yield return new WaitForSeconds(Random.Range(0.0f, 1.0f + variation*10));
		}
	}

	void flickerOn(){
		for(int i = 0; i < lights.Length; i++){
			lights[i].GetComponent<Light>().enabled = true;
			if(flickerMaterial)
				renderer.material.color = defaultColour;
			lightsOn = true;
		}
	}

	void flickerOff(){
		for(int i = 0; i < lights.Length; i++){
			lights[i].GetComponent<Light>().enabled = false;
			if(flickerMaterial)
				renderer.material.color = Color.black;
			lightsOn = false;
		}
	}

}