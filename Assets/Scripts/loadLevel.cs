using UnityEngine;
using System.Collections;

public class loadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//print (Application.loadedLevelName);
	}

	void onTriggerEnter(){
		if (Application.loadedLevelName == "Level_01_Loading_Bay")
			Application.LoadLevel ("Level_01_Choice");
		if (Application.loadedLevelName == "Level_01_Choice")
			Application.LoadLevel ("Level_02_A");

	}
}