using UnityEngine;
using System.Collections;

public class waypointManager : MonoBehaviour {

	public int IndexToStartAt = 0;
	private GameObject[] waypointList;
	private GameObject activeWaypoint;
	private waypointTrigger activeTriggerScript;

	// Use this for initialization
	void Start () {
		waypointList = GameObject.FindGameObjectsWithTag("waypoint");
		foreach (GameObject g in waypointList){
//			print (g.name);
			waypointTrigger wpt =  g.GetComponent<waypointTrigger>();
			if(wpt.index == IndexToStartAt){
				activeWaypoint = g;
				activeWaypoint.SetActive(true);
				activeTriggerScript = activeWaypoint.GetComponent<waypointTrigger>();
			}
			else{
				g.SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (activeTriggerScript.triggered){
//			print (activeWaypoint.name);
			foreach (GameObject g in waypointList){
				waypointTrigger wpt =  g.GetComponent<waypointTrigger>();
				if(wpt.index == activeTriggerScript.index+1){
					activeWaypoint.SetActive(false);
					activeWaypoint = g;
					activeWaypoint.SetActive(true);
					activeTriggerScript = activeWaypoint.GetComponent<waypointTrigger>();
				}
			}
		}
	}
}