﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerStatus : GameBehaviour {
	
	public float health;
	public float maxHealth = 50;
	public Vector3 spawnPoint;
	
	public float lightLevel;
	public float lightThreshold = 0.35f;

	
	void Awake(){
		//Debug.Log("playerStatus awake");
		
	}
	
	void Start(){
		//Debug.Log("playerStatus spawned");
		health = maxHealth;
		spawnPoint = world.player.transform.position;
		
		world.camEffects.lightLevel = 1f;
	}
	
	void FixedUpdate(){
		//Some light detection
		int layerMask = 1 << 2;
		layerMask = ~layerMask;
		lightLevel = 0;
		foreach(Light l in world.lights){
			float dist = Vector3.Distance(world.player.transform.position, l.transform.position);
			float intensity = (l.intensity / 8);
			float effectiveRange = (l.range/2) * intensity;
			
			
			RaycastHit hit;
			if (Physics.Linecast(world.player.transform.position, l.transform.position, out hit, layerMask)){
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
		
		
		if (lightLevel >= lightThreshold){
			if (world.camEffects.lightLevel <1){
				world.camEffects.lightLevel+= 0.5f;
			}
			health += 0.5f;
		}else{
			world.camEffects.lightLevel-= 0.01f;
			health -= 0.5f;
		}

		
		health = Mathf.Clamp(health, 0, maxHealth);
		
		if (health <= 0){
			//Call player death
			Die();
		}
		
	}
	
	void Die(){
		//Call camera fall-over event. After that, call respawn upon player input.
		//Respawn needs to move player to checkpoint, kill cam effects, and then call Start(); again.
		world.player.transform.position = spawnPoint;
		Start();
	}
}
