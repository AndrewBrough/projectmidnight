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
	/*
	private bool zoom = false;
	private float angle = 0;
	*/
	void Awake(){
		instance = this;
		lights = FindObjectsOfType(typeof(Light)) as Light[];
		camEffects = (cameraEffectHandler)camFaderTexture.GetComponent(typeof(cameraEffectHandler));
		playerStatus = (playerStatus)player.GetComponent(typeof(playerStatus));
	}

	void Update(){
		if(Input.){

		}
	}
	
	
	
}