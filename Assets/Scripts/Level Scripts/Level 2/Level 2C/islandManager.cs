using UnityEngine;
using System.Linq;
using System.Collections;

public class islandManager : GameBehaviour {

	//global variables
	//choices
	public GameObject island1;
	public GameObject island2;
	public GameObject island3;
	public GameObject island4;
	public GameObject island5;
	public GameObject island6;
	public GameObject island7;
	public GameObject island8;
	public GameObject island9;
	public GameObject pedestal1Mesh;
	public GameObject pedestal2Mesh;
	public GameObject pedestal3Mesh;
	public GameObject pedestal4Mesh;


	GameObject[] islands = new GameObject[9];
	Light[] islandLights = new Light[9];

	public bool switch1 = false;
	public bool switch2 = false;
	public bool switch3 = false;
	public bool switch4 = false;

	public Material onMat;
	public Material offMat;


	private ArrayList lights1 = new ArrayList();
	private ArrayList lights2 = new ArrayList();
	private ArrayList lights3 = new ArrayList();
	private ArrayList lights4 = new ArrayList();

	private Material[] pedestalMatsOff;
	private Material[] pedestalMatsOn;


	void Start () {
		pedestalMatsOff = pedestal1Mesh.renderer.materials;
		pedestalMatsOn = pedestal1Mesh.renderer.materials;
		pedestalMatsOn [1] = onMat;

		islands [0] = island1;
		islands [1] = island2;
		islands [2] = island3;
		islands [3] = island4;
		islands [4] = island5;
		islands [5] = island6;
		islands [6] = island7;
		islands [7] = island8;
		islands [8] = island9;

		for(int i=0; i<9; i++){
			islandLights[i] = (Light)islands[i].GetComponentInChildren(typeof(Light));
			islandLights[i].enabled = !islandLights[i].enabled;
		}

		lights1.Add (islandLights [0]);
		lights1.Add (islandLights [1]);
		lights1.Add (islandLights [3]);
		lights1.Add (islandLights [4]);

		lights2.Add (islandLights [1]);
		lights2.Add (islandLights [2]);
		lights2.Add (islandLights [4]);
		lights2.Add (islandLights [5]);

		lights3.Add (islandLights [3]);
		lights3.Add (islandLights [4]);
		lights3.Add (islandLights [6]);
		lights3.Add (islandLights [7]);

		lights4.Add (islandLights [4]);
		lights4.Add (islandLights [5]);
		lights4.Add (islandLights [7]);
		lights4.Add (islandLights [8]);

	}
	

	public void Update() {

		//Reset our variables
		for (int i=0; i<9; i++) {
			islandLights[i].enabled = false;
		}



		pedestal1Mesh.renderer.materials = pedestalMatsOff;
		pedestal2Mesh.renderer.materials = pedestalMatsOff;
		pedestal3Mesh.renderer.materials = pedestalMatsOff;
		pedestal4Mesh.renderer.materials = pedestalMatsOff;





		if (switch1) {
			foreach (Light light in lights1){
				light.enabled = !light.enabled;
			}
			pedestal1Mesh.renderer.materials = pedestalMatsOn;
		}
		if (switch2) {
			foreach (Light light in lights2){
				light.enabled = !light.enabled;
			}
			pedestal2Mesh.renderer.materials = pedestalMatsOn;
		}
		if (switch3) {
			foreach (Light light in lights3){
				light.enabled = !light.enabled;
			}
			pedestal3Mesh.renderer.materials = pedestalMatsOn;
		}
		if (switch4) {
			foreach (Light light in lights4){
				light.enabled = !light.enabled;
			}
			pedestal4Mesh.renderer.materials = pedestalMatsOn;
		}






		//For each island light
		for (int i=0; i<9; i++) {
			//Get a list of all of the bar lights by tag
			ArrayList barLights = new ArrayList();

			foreach (Transform child in islands[i].transform){
				if (child.tag == "pillar_light"){
					barLights.Add(child);
				}
			}



			//If the light is on
			if (islandLights[i].enabled){


				//Swap material to on
				foreach(Transform barLight in barLights){
					barLight.renderer.material = onMat;
				}
				islands[i].transform.position = Vector3.Lerp(
					islands[i].transform.position, 
					new Vector3(
					islands[i].transform.position.x,
					-1.5f,
					islands[i].transform.position.z),
					0.1f);


			}else{
				//Swap material to off
				foreach(Transform barLight in barLights){
					barLight.renderer.material = offMat;
				}
				islands[i].transform.position = Vector3.Lerp(
					islands[i].transform.position, 
					new Vector3(
					islands[i].transform.position.x,
				    10f,
					islands[i].transform.position.z),
					0.1f);

			}
		}

	}
}
