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
	public Light[] lights;
	public GameObject player;
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
		
	}

	void Update(){
		if(Input.){

		}
	}
	
	
	
}