﻿using UnityEngine;
using System.Collections;

public class waypointTrigger : GameBehaviour {

	public bool triggered = false;
	public int index = 0;
	public enum triggerType {
		collision=0,
		click=1,
		powercell = 2
	};
	public triggerType type = triggerType.collision;

	void OnTriggerStay (Collider other){
		if (other.CompareTag("Player")){
			print ("Waypoint Reached");
			if (type == triggerType.click){
				if (Input.GetMouseButton(0)){
					triggered = true;
				}
			}
			else if (type == triggerType.collision){
				triggered = true;
			}
		}
		else if (other.transform.CompareTag("powerCell")){
			if (type == triggerType.powercell){
				triggered = true;
			}
		}
	}
}