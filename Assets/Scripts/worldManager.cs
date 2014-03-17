using UnityEngine;
using System.Collections;

public class worldManager : MonoBehaviour 
{
	public static worldManager instance {get;private set;}
	
	//global variables
	//choices
	public enum FearChoice {
		spiders = 0,
		fire = 0,
		heights = 0,
		claustrophobia = 0
	};
	public bool paused = false;

//	public static FearChoice Choices;

	//Semantic variables
	public Light[] floorlights;
	public Light[] ceilingLights;
	public Light[] lights;
	public GameObject player;
	public bool darknessDisable
	{
		get{ return playerStatus.disableDarkness; }
		set{ playerStatus.disableDarkness = value; }
	}
	public bool forceDarkness
	{
		get{ return playerStatus.forceDarkness;	}
		set{playerStatus.forceDarkness = value;	}
	}
	
	private playerStatus playerStatus;

	public Camera camera;
	public cameraEffectHandler camEffects;
	public GUITexture camFaderTexture;
	public GameObject monster;
	public GameObject OptionsMenu;
	
	/*
	private bool zoom = false;
	private float angle = 0;
	*/
	void Awake(){
		//HIDE CURSOR
		Screen.showCursor = false;

		instance = this;
		lights = FindObjectsOfType(typeof(Light)) as Light[];
//		camera = player.GetComponentInChildren<Camera>();
		camEffects = (cameraEffectHandler)camFaderTexture.GetComponent(typeof(cameraEffectHandler));
		playerStatus = (playerStatus)player.GetComponent(typeof(playerStatus));

		OptionsMenu.SetActive(false);
	}

	private int frame = 0;

	void Update(){
		frame++;
		//SCREEN CAP
		if(Input.GetKey(KeyCode.Keypad0)){
			Application.CaptureScreenshot("Screenshot_" + frame + ".png", 5);
		}

		if (Input.GetKey(KeyCode.Escape)){
			paused = true;
			Pause ();
		}
		if (Input.GetMouseButton(0)){
			paused = false;
			Pause ();
		}
	}

	void Pause(){
		if (paused){
			Time.timeScale = 0;
			OptionsMenu.SetActive(true);
		}
		if (!paused){
			Time.timeScale = 1;
			OptionsMenu.SetActive(false);
		}
	}

}