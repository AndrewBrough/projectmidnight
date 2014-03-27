using UnityEngine;
using System.Collections;

public class waypointManager : MonoBehaviour {

	public GameObject startWaypoint;

	private GameObject[] waypointList;
	private GameObject activeWaypoint;
	private waypointTrigger activeTriggerScript;

	// Use this for initialization
	void Start () {
		waypointList = GameObject.FindGameObjectsWithTag("waypoint");
		foreach (GameObject g in waypointList){
			g.SetActive(false);
//			waypointTrigger wpt =  g.GetComponent<waypointTrigger>();
//			if(wpt.index == IndexToStartAt){
//				activeWaypoint = g;
//				activeWaypoint.SetActive(true);
//				activeTriggerScript = activeWaypoint.GetComponent<waypointTrigger>();
//			}
//			else{
//				g.SetActive(false);
//			}
		}
		activeWaypoint = startWaypoint;
		activeWaypoint.SetActive(true);
		activeTriggerScript = activeWaypoint.GetComponent<waypointTrigger>();
	}
	
	// Update is called once per frame
	void Update () {
		if (activeTriggerScript.triggered){
			//get next waypoint
			GameObject g = activeWaypoint.GetComponent<waypointTrigger>().nextWaypoint;
			if(g != null){
				activeWaypoint.SetActive(false);
				activeWaypoint = g;
				activeTriggerScript = activeWaypoint.GetComponent<waypointTrigger>();
				activeWaypoint.SetActive(true);
			}

//			print (activeWaypoint.name);
//			foreach (GameObject g in waypointList){
//				waypointTrigger wpt =  g.GetComponent<waypointTrigger>();
//				if(wpt.index == activeTriggerScript.index+1){
//					activeWaypoint.SetActive(false);
//					activeWaypoint = g;
//					activeWaypoint.SetActive(true);
//					activeTriggerScript = activeWaypoint.GetComponent<waypointTrigger>();
//				}
//			}
		}
	}
}