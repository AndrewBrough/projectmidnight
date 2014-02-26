
using UnityEngine;
using System.Collections;

public class playerActions : GameBehaviour {
	
	public GameObject heldObject;
	public heldObjectProperties heldObjectProp;
	
	private bool crouched = false;
	private float crouchCamHeight = 0.4f;
	
	private int forwardCount = 0;//number of button taps for running
	private float forwardCooldown = 0.5f; //time to check for a second tap to run
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//print (this);
		if(heldObject != null){
			heldObject.transform.position = world.camera.transform.position + world.camera.transform.forward;
			Vector3 newPos = heldObject.transform.position;
			newPos.y += 0.0f;
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
				RaycastHit hit = new RaycastHit();
				Physics.Raycast(world.camera.transform.position, world.camera.transform.forward, out hit);
				if(hit.collider != null){
					GameObject g = hit.collider.gameObject;
					GameObject hitObject = null;
					if(hit.collider.gameObject.CompareTag("lantern")){
						hitObject = hit.collider.gameObject;
					}
					else if(hit.collider.gameObject.transform.parent.CompareTag("powerCell")){
						hitObject = hit.collider.gameObject.transform.parent.gameObject;
					}
					//print("Hit " + hitObject.name);
					if(hitObject != null){
						heldObjectProperties hitObjectProp = (heldObjectProperties) hitObject.GetComponent(typeof(heldObjectProperties));
						heldObject = (hitObject.tag == "powerCell" || hitObject.tag == "lantern" && hitObjectProp.DtoPlayer <= 3) ? hitObject : null;
						if(heldObject != null){
							//print ("picked up " + heldObject.name);
							heldObjectProp = (heldObjectProperties) heldObject.GetComponent(typeof(heldObjectProperties));
							heldObjectProp.held = true;
						}
					}
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.LeftControl) && !crouched){
			Crouch();
		}
		if(!Input.GetKey(KeyCode.LeftControl) && crouched){
			//check if anything above player, then stand if able
			RaycastHit hit = new RaycastHit();
			Physics.Raycast(world.camera.transform.position, world.camera.transform.up, out hit, 2);
			if(hit.collider==null)
				UnCrouch();
		}
		/* RUNNING STUFF
		 * can't do because default player controller would need to be re written in C#. Will implement running in new js script
		if(Input.GetKeyDown(KeyCode.W)){
			if ( forwardCooldown > 0 && forwardCount == 1){
				//Has double tapped
				Run();
			}else{
				ButtonCooler = 0.5 ; 
				ButtonCount += 1 ;
			}
		}
		if(forwardCooldown > 0)
			forwardCooldown -= 1 * Time.deltaTime ;
		else
			forwardCount = 0 ;
		//stop running
		if(!Input.GetKey(KeyCode.W)){
			StopRun();
		}
		*/
	}
	//crouch and uncrouch
	private void Crouch(){
		float scaleY = 0.5f;
		world.player.transform.localScale = new Vector3(1,scaleY,1);
		crouched = true;
	}
	private void UnCrouch(){
		float scaleY = 1.0f;
		world.player.transform.localScale = new Vector3(1,scaleY,1);
		Vector3 reset = world.player.transform.position; //player falls through floor if scaled through the floor... so move it up
		reset.y+=0.5f;
		world.player.transform.position = reset;
		crouched = false;
	}
	
	//Check player field of view
	//return game object if it exists, otherwise return null
	
}
