using UnityEngine;
using System.Collections;

public class playerActions : GameBehaviour {
	
	public GameObject heldObject;
	public heldObjectProperties heldObjectProp;
	
	public bool crouched = false;
	public bool running = false;
	public float defaultSpeed;
	private float runSpeed = 12.0f;
	private float crouchSpeed = 4.0f;
	private int forwardCount = 0;//number of button taps for running
	private float forwardCooldown = 0.5f; //time to check for a second tap to run
	
	// Use this for initialization
	void Start () {
		CharacterMotorC c = (CharacterMotorC) world.player.GetComponent("CharacterMotorC");
		defaultSpeed = c.movement.maxForwardSpeed;
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
			Quaternion q = this.transform.rotation;
			q.y += 1.0f;
			heldObject.transform.rotation = q;
//			heldObject.transform.rotation = this.transform.rotation;
		}
		
		if(Input.GetMouseButtonDown(0))
		{
			if(heldObject != null)
			{
//				print ("Dropped: " + heldObject.transform.name);
				heldObjectProp.held = false;
				if(!heldObject.rigidbody.isKinematic){
					heldObject.rigidbody.velocity = Vector3.zero;
					heldObject.rigidbody.AddForce(transform.forward*30 + Vector3.up*30);
				}
				heldObject = null;
				heldObjectProp = null;
			} else {
				RaycastHit hit = new RaycastHit();
				Physics.Raycast(world.camera.transform.position, world.camera.transform.forward, out hit);
				if(hit.collider != null){
					if(hit.collider.transform.CompareTag("lantern")){
						heldObject = hit.collider.gameObject;
						heldObjectProp = (heldObjectProperties) heldObject.GetComponent(typeof(heldObjectProperties));
						heldObjectProp.held = true;
					}
					else if(hit.collider.transform.CompareTag("powerCell")){
						heldObject = hit.collider.gameObject;
						heldObjectProp = (heldObjectProperties) heldObject.GetComponent(typeof(heldObjectProperties));
						heldObjectProp.held = true;
					}
				}
			}
		}

		//input for crouching
		if(Input.GetKeyDown(KeyCode.LeftShift) && !crouched){
			MakeCrouch();
		}
		if(!Input.GetKey(KeyCode.LeftShift) && crouched){
			//check if anything above player, then stand if able
			RaycastHit hit = new RaycastHit();
			Physics.Raycast(world.camera.transform.position, world.camera.transform.up, out hit, 1f);
			if(hit.collider==null)
				StopCrouch();
		}
		//new running input
		//run when player presses forward twice quickly, like in Minecraft
		if(Input.GetKeyDown(KeyCode.W)){
			if ( forwardCooldown > 0 && forwardCount == 1){
				//Has double tapped
				MakeRun();
			}else{
				StopRun();
				forwardCooldown = 0.5f; 
				forwardCount += 1 ;
			}
		}
		if(forwardCooldown > 0)
			forwardCooldown -= 1 * Time.deltaTime ;
		else{
			forwardCount = 0 ;
		}
	}
	//crouch and uncrouch
	private void MakeCrouch(){
		float scaleY = 0.5f;
		world.player.transform.localScale = new Vector3(1,scaleY,1);
		CharacterMotorC c = (CharacterMotorC) world.player.GetComponent("CharacterMotorC");
		c.movement.maxForwardSpeed = crouchSpeed;
		c.movement.maxSidewaysSpeed = crouchSpeed;
		crouched = true;
	}
	private void StopCrouch(){
		float scaleY = 1.0f;
		world.player.transform.localScale = new Vector3(1,scaleY,1);
		Vector3 reset = world.player.transform.position; //player falls through floor if scaled through the floor... so move it up
		reset.y+=0.5f;
		world.player.transform.position = reset;
		CharacterMotorC c = (CharacterMotorC) world.player.GetComponent("CharacterMotorC");
		c.movement.maxForwardSpeed = defaultSpeed;
		c.movement.maxSidewaysSpeed = defaultSpeed;
		crouched = false;
	}
	private void MakeRun(){
		CharacterMotorC c = (CharacterMotorC) world.player.GetComponent("CharacterMotorC");
		c.movement.maxForwardSpeed = runSpeed;
		c.movement.maxSidewaysSpeed = runSpeed;
		//world.camera.fieldOfView += 10;
		running = true;
	}
	private void StopRun(){
		CharacterMotorC c = (CharacterMotorC) world.player.GetComponent("CharacterMotorC");
		c.movement.maxForwardSpeed = defaultSpeed;
		c.movement.maxSidewaysSpeed = defaultSpeed;
		//world.camera.fieldOfView -= 10;
		running = false;
	}
	
	//Check player field of view
	//return game object if it exists, otherwise return null
	
}
