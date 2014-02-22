using UnityEngine;
using System.Collections;

public class worldManager : MonoBehaviour 
{
	public static worldManager instance {get;private set;}
	
	
	
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
	
	
	
}