//LOL EVA WAS HERE
using UnityEngine;
using System.Collections;

public class playerActions : MonoBehaviour {
	
	public GameObject heldObject;
	public heldObjectProperties heldObjectProp;

	private GameObject monster;
	
	// Use this for initialization
	void Start () {
		monster = GameObject.FindGameObjectWithTag ("Monster");
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
			Vector3 moveToPos = Vector3.MoveTowards(heldObject.transform.position, newPos, 0.5f);
			heldObject.transform.position = moveToPos;
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
					GameObject hitObject = hit.collider.gameObject.transform.parent.gameObject;
					print("Hit " + hitObject.name);
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

	//Check player field of view
	//return game object if it exists, otherwise return null

}
