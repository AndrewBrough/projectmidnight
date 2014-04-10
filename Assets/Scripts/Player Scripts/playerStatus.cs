﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerStatus : GameBehaviour {
	
	public float health;
	public float maxHealth = 50;
	public Vector3 spawnPoint;
	
	public float lightLevel;
	public float lightThreshold = 0.35f;

	//necessary for field of view changing trigger
	public float targetFOV = 120.0f;
	public int FOVisChanging = 0;
	public float FOVChangeSpeed = 0.5f;
	private float defaultFOV;

	//NOTE:
	//Technically, the player can be both in disabledarkness and forcedarkness at the same time
	//since disableDarkness cancels the darkness mechanic altogether, it takes priority
	//try not to space LightZones and DarkZones too close together

	public bool disableDarkness = false;
	public bool forceDarkness = false;

	public AudioSource deathMusic;

	void Awake(){
		//Debug.Log("playerStatus awake");
		
	}
	
	void Start(){
		//Debug.Log("playerStatus spawned");
		health = maxHealth;
		spawnPoint = world.player.transform.position;
		defaultFOV = world.camera.fieldOfView;

		world.camEffects.lightLevel = 1f;
		world.camEffects.vignette1_L = 1f;
		world.camEffects.vignette2_L = 1f;

		AudioSource[] audiosources = world.player.GetComponents<AudioSource>();
		foreach(AudioSource thing in audiosources){
			if(thing.clip.name == "V - Death Theme")
				deathMusic = thing;
		}

	}

	void Update(){

		//for FOV changing
		if(world.camera.fieldOfView < targetFOV && FOVisChanging != 0){
			world.camera.fieldOfView += FOVChangeSpeed;
		}
		
		if(world.camera.fieldOfView > defaultFOV && FOVisChanging == 0){
			world.camera.fieldOfView -= FOVChangeSpeed;
		}

		//if there's nothing below the player, change FOV
		RaycastHit hit = new RaycastHit();
		Physics.Raycast(world.player.transform.position, Vector3.down, out hit, 10.0f);
//		print (hit);
	}

	void FixedUpdate(){
		//necessary checks to see if inside a full-lit zone, or a full-dark zone

		if (disableDarkness){
			darkRecover();
			health = Mathf.Clamp(health, 0, maxHealth);	
			return;
		}

		//Some light detection
		lightLevel = 0;
		
		if (!forceDarkness){
			int layerMask = 1 << 2;
			layerMask = ~layerMask;

			foreach(Light l in world.lights){

				//Ignore lights that are off
				if (!l.enabled){
					continue;
				}

				float dist = Vector3.Distance(world.player.transform.position, l.transform.position);
				float intensity = (l.intensity / 8);
				float effectiveRange = (l.range/2) * intensity;
				
				
				RaycastHit hit;
				if (Physics.Linecast(world.player.transform.position, l.transform.position, out hit, layerMask) && hit.transform.tag != "lantern"){
					//There is something between the light and the player


					Debug.DrawLine(world.player.transform.position, l.transform.position, Color.red);

				}else{
					Debug.DrawLine(world.player.transform.position, l.transform.position, Color.green);
					float localLightLevel;
					
					dist = Mathf.Clamp(dist, effectiveRange, l.range);
					//localLightLevel = map(dist, ER, R, 0, 1)
					localLightLevel = 1 - (dist - effectiveRange) / (l.range - effectiveRange);
					
					lightLevel += localLightLevel;

				}
			}
			
			
			lightLevel = Mathf.Clamp(lightLevel, 0, 1);
		}

		
		if (lightLevel >= lightThreshold){
			darkRecover();
		}else{
			darkDamage();
		}


		health = Mathf.Clamp(health, 0, maxHealth);
		world.camEffects.vignette1_L = Mathf.Clamp (world.camEffects.vignette1_L, 0, 1);
		world.camEffects.vignette2_L = Mathf.Clamp (world.camEffects.vignette2_L, 0, 1);



		if (health <= 0){
			//Call player death
			Die(false);
		}
		if( world.player.transform.position.y < -30 || world.player.transform.position.y > 20){
			Die (true);
		}
	}

	private void darkRecover(){
		if (world.camEffects.lightLevel <1){
			world.camEffects.lightLevel = 1;
		}

		world.camEffects.vignette1_L += 0.2f;
		world.camEffects.vignette2_L += 0.2f;
		health += 0.5f;


		//fade out then stop music
		deathMusic.volume -= 0.05f;
		if(deathMusic.volume == 0)
			deathMusic.Stop();
	}

	private void darkDamage(){
		world.camEffects.lightLevel-= 0.002f;
		world.camEffects.vignette1_L -= 0.1f;
		world.camEffects.vignette2_L -= 0.01f;
		health -= 2;

		if (!deathMusic.isPlaying) {
			deathMusic.volume = 1;
			deathMusic.Play ();
		}
	}
	
	public void Die(bool immediate){
		//Call camera fall-over event. After that, call respawn upon player input.
		//Respawn needs to move player to checkpoint, kill cam effects, and then call Start(); again.
		health = 0;
		if(immediate || deathMusic.time > 6.0f){
			//world.player.transform.position = spawnPoint;
			//Call a death menu?

			Application.LoadLevel (Application.loadedLevelName);
			Start();
		}
	}
}

