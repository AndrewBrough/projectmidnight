using UnityEngine;
using System.Collections;

public class Light_Flicker : MonoBehaviour {

	private Light[] lights;
	private bool lightsOn;
	private Material defaultMaterial;
	private Material deadMaterial;

	public float variationOn = 1;
	public float variationOff = 0.05f;
	public bool flickerMaterial = true;

	//hold instantiated sparks so can be destroyed later
//	private ArrayList sparks = new ArrayList();

	// Use this for initialization
	void Start () {
		deadMaterial = Resources.Load("dead_light", typeof(Material)) as Material;

		//save default material
		if(flickerMaterial)
			defaultMaterial = renderer.material;

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

	IEnumerator Flickering(){
		//start flickering
		while(true){
			int random1 = Random.Range(0, 5);
			for(int i = 0; i< random1; i++){
				flickerOff();
				yield return new WaitForSeconds(Random.Range(0.0f, variationOff));
				flickerOn();
				yield return new WaitForSeconds(Random.Range(0.0f, variationOn));
			}
		}
	}

	void flickerOn(){
		for(int i = 0; i < lights.Length; i++){
			lights[i].GetComponent<Light>().enabled = true;
			if(flickerMaterial)
				renderer.material = defaultMaterial;
			lightsOn = true;
		}
	}

	void flickerOff(){
		for(int i = 0; i < lights.Length; i++){
			lights[i].GetComponent<Light>().enabled = false;
			if(flickerMaterial)
				renderer.material = deadMaterial;
			lightsOn = false;
		}
	}

}