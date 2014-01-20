﻿using UnityEngine;
using System.Collections;

public class playerActions : MonoBehaviour {
	
	public GameObject heldObject;
	public heldObjectProperties heldObjectProp;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//print (this);
		if(heldObject != null){
			Camera mainCamera = transform.Find("Main Camera").camera;
			heldObject.transform.position = this.transform.position + mainCamera.transform.forward;
			Vector3 newPos = heldObject.transform.position;
			newPos.y += 1.0f;
			if(heldObject.tag == "lantern")
			{
				newPos.y -= 0.5f;
			}
			heldObject.transform.position = newPos;
			heldObject.transform.rotation = this.transform.rotation;
		}
		
		if(Input.GetMouseButtonDown(0))
		{
			if(heldObject != null)
			{
				print ("Dropped: " + heldObject.transform.name);
				heldObjectProp.held = false;
				heldObject = null;
				heldObjectProp = null;
			} else {
				Camera mainCamera = transform.Find("Main Camera").camera;
				RaycastHit hit = new RaycastHit();
				Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit);

				if(hit.collider != null){
					GameObject hitObject = GameObject.Find( hit.collider.gameObject.name ).transform.gameObject;
					heldObjectProperties hitObjectProp = (heldObjectProperties) hitObject.GetComponent(typeof(heldObjectProperties));
					heldObject = (hitObject.tag == "powerCell" || hitObject.tag == "lantern" && hitObjectProp.DtoPlayer <= 3) ? hitObject : null;
					if(heldObject != null){
						print ("picked up " + heldObject.name);
						heldObjectProp = (heldObjectProperties) heldObject.GetComponent(typeof(heldObjectProperties));
						heldObjectProp.held = true;
					}
				}
			}
		}
	}
}
