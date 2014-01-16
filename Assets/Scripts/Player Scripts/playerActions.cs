using UnityEngine;
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
				print ("LANTERN");
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
				//print (mainCamera.transform.forward);
				RaycastHit hit = new RaycastHit();
				Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit);
				//print (hit.collider.gameObject.name);
				//print (GameObject.Find( hit.collider.gameObject.name ).transform.gameObject);
				GameObject hitObject = GameObject.Find( hit.collider.gameObject.name ).transform.gameObject;
				heldObjectProperties hitObjectProp = (heldObjectProperties) hitObject.GetComponent(typeof(heldObjectProperties));
				heldObject = (hitObject.tag == "powerCell" || hitObject.tag == "lantern" && hitObjectProp.DtoPlayer <= 3) ? hitObject : null;
				heldObjectProp = (heldObjectProperties) heldObject.GetComponent(typeof(heldObjectProperties));
				heldObjectProp.held = true;
			}
		}
		
		//held object
		/*
		if(heldObject != null){
			manipulateHeldObject();
			//print ("HELD OBJECT POS: " + heldObject.transform.position);
			//drop held object on click
			if (Input.GetMouseButtonDown(0)){
				print("DROPPED" + heldObject.transform.position);
				//heldObject.collider.enabled = true;
				heldObject = null;
			}
		} else {
			//player picks up object
			if (Input.GetMouseButtonDown(0)){
	            //print("left mouse button was pressed");
				GameObject[] powercells = GameObject.FindGameObjectsWithTag("powerCell");
				//check distance of power cells to player, allow pickup if close
				heldObject = (heldObject == null) ? powercells[0] : heldObject;
				//find smallest distance, set that obj to the heldObject
				for(int i = 0; i < 2; i++){
					heldObjectProperties gP = (heldObjectProperties) powercells[i].GetComponent(typeof(heldObjectProperties));
					heldObjectProperties lastGP = (heldObjectProperties) heldObject.GetComponent(typeof(heldObjectProperties));
					heldObject = (gP.DtoPlayer < lastGP.DtoPlayer) ? powercells[i] : heldObject;
					//heldObject.collider.enabled = false;
					
				}
				
				//heldObject.collider.enabled = false;
			}
		}
		*/
	}

}
