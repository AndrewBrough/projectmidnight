using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerStatus : GameBehaviour {
	
	public float health;
	public float maxHealth = 50;
	public Vector3 spawnPoint;
	
	public float lightLevel;
	public float lightThreshold = 0.35f;

	//necessary for field of view changing trigger
	public float targetFOV = 60.0f;
	public int FOVisChanging = 0;
	public float FOVChangeSpeed = 0.5f;

	//NOTE:
	//Technically, the player can be both in disabledarkness and forcedarkness at the same time
	//since disableDarkness cancels the darkness mechanic altogether, it takes priority
	//try not to space LightZones and DarkZones too close together

	public bool disableDarkness = false;
	public bool forceDarkness = false;
	
	void Awake(){
		//Debug.Log("playerStatus awake");
		
	}
	
	void Start(){
		//Debug.Log("playerStatus spawned");
		health = maxHealth;
		spawnPoint = world.player.transform.position;
		
		world.camEffects.lightLevel = 1f;
	}

	void Update(){
		//for FOV changing
		if(world.camera.fieldOfView < 110.0f && FOVisChanging != 0){
			world.camera.fieldOfView += FOVChangeSpeed;
		}
		
		if(world.camera.fieldOfView > 60.0f && FOVisChanging == 0){
			world.camera.fieldOfView -= FOVChangeSpeed+0.25f;
		}

		//if there's nothing below the player, change FOV
		RaycastHit hit = new RaycastHit();
		Physics.Raycast(world.player.transform.position, Vector3.down, out hit, 10.0f);
//		print (hit);
	}

	void FixedUpdate(){

		//necessary checks to see if inside a full-lit zone, or a full-dark zone


		if (disableDarkness){

			if (world.camEffects.lightLevel <1){
				world.camEffects.lightLevel+= 0.5f;
			}

			health += 0.5f;
			health = Mathf.Clamp(health, 0, maxHealth);	
			return;
		}

		//Some light detection
		lightLevel = 0;
		
		if (!forceDarkness){
			int layerMask = 1 << 2;
			layerMask = ~layerMask;

			foreach(Light l in world.lights){
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
		Application.LoadLevel (Application.loadedLevelName);
		Start();
	}
}
