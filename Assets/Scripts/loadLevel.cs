using UnityEngine;
using System.Collections;

public class loadLevel : MonoBehaviour {

	public enum Levels {
		Level_02_A = 0,
		Level_02_B = 1,
		Level_02_C = 2,
		Level_02_D = 3,
		Title = 4
	};

	public Levels LevelToLoad;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			Application.LoadLevel(LevelToLoad.ToString());
		}
	}
}
