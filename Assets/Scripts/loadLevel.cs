using UnityEngine;
using System.Collections;

public class loadLevel : MonoBehaviour {

	public enum Levels {
		Level_02_A = 0,
		Level_02_B = 1,
		Level_02_C = 2,
		Level_02_D = 3,
		Title = 4,
		Level_01_Loading_Bay = 10
	};

	public Levels LevelToLoad;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//use number to load levels
		if(Input.GetKey(KeyCode.Keypad1)){
			LevelToLoad = Levels.Level_01_Loading_Bay;
			Application.LoadLevel(LevelToLoad.ToString());
		}
		if(Input.GetKey(KeyCode.Keypad2)){
			LevelToLoad = Levels.Level_02_C;
			Application.LoadLevel(LevelToLoad.ToString());
		}
		if(Input.GetKey(KeyCode.Keypad3)){
			LevelToLoad = Levels.Level_02_B;
			Application.LoadLevel(LevelToLoad.ToString());
		}
		if(Input.GetKey(KeyCode.Keypad4)){
			LevelToLoad = Levels.Level_02_D;
			Application.LoadLevel(LevelToLoad.ToString());
		}
		if(Input.GetKey(KeyCode.Keypad0)){
			LevelToLoad = Levels.Title;
			Application.LoadLevel(LevelToLoad.ToString());
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			Application.LoadLevel(LevelToLoad.ToString());
		}
	}
}
