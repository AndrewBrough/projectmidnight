﻿using UnityEngine;
using System.Collections;

public class EscToQuit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Application.LoadLevel("Level_01_Loading_Bay");
		}
		//EXIT GAME
		if(Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}
	}
}
