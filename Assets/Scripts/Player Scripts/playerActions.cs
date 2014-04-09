using UnityEngine;
using System.Collections;

public class playerActions : GameBehaviour {
	
	public GameObject heldObject;
	public heldObjectProperties heldObjectProp;

	private float checkHitDistance = 3.0f;

	public bool crouched = false;
	public bool running = false;
	private float defaultFOV;
	public float defaultSpeed;
	private float runSpeed = 11.0f;
	private float crouchSpeed = 2.0f;
	private int forwardCount = 0;//number of button taps for running
	private float forwardCooldown = 0.5f; //time to check for a second tap to run

	private GameObject lookAtObject = null;

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
			newPos.y -= 0.2f;
			Quaternion q = this.transform.rotation;
			if(heldObject.name == "notepad"){
				q *= Quaternion.Euler(0,-90,0);
			}
			heldObject.transform.rotation = q;
			Vector3 moveToPos = Vector3.MoveTowards(heldObject.transform.position, newPos, 0.5f);
			heldObject.transform.position = moveToPos;
			//q.y += 1.0f;

//			heldObject.transform.rotation = this.transform.rotation;
		}
		//highlight looked at holdable
		if(heldObject == null){
			//get holdable object
			RaycastHit hit = new RaycastHit();
			Physics.Raycast(world.camera.transform.position, world.camera.transform.forward, out hit, checkHitDistance);
			if( hit.collider != null ){
				if(hit.collider.CompareTag("holdable") || hit.collider.CompareTag("powerCell") || hit.collider.CompareTag("lantern") || hit.collider.CompareTag("controlPanel")){
					hit.collider.gameObject.GetComponent<heldObjectProperties>().targetted = true;
					Material[] mats = new Material[3];
//					mats[0] = hit.transform.gameObject.GetComponent<heldObjectProperties>().startMaterial;
					mats[0] = Resources.Load("lightup_material", typeof(Material)) as Material;
					mats[1] = Resources.Load("lightup_material", typeof(Material)) as Material;
					mats[2] = Resources.Load("lightup_material", typeof(Material)) as Material;
					hit.transform.renderer.materials = mats;
//					hit.collider.gameObject.renderer.material = Resources.Load("lightup_material", typeof(Material)) as Material;
				}
			}
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
				Physics.Raycast(world.camera.transform.position, world.camera.transform.forward, out hit, checkHitDistance);
				if(hit.collider != null){
					if(hit.collider.CompareTag("holdable") || hit.collider.CompareTag("powerCell") || hit.collider.CompareTag("lantern")){
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
		if (Input.GetKeyUp(KeyCode.W)){
			StopRun();
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
		//c.movement.maxBackwardsSpeed = crouchSpeed;
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
		//c.movement.maxBackwardsSpeed = defaultSpeed;
		crouched = false;
	}
	private void MakeRun(){
		CharacterMotorC c = (CharacterMotorC) world.player.GetComponent("CharacterMotorC");
		c.movement.maxForwardSpeed = runSpeed;
		c.movement.maxSidewaysSpeed = runSpeed;
//		c.movement.maxBackwardsSpeed = runSpeed;
		running = true;
	}
	private void StopRun(){
		CharacterMotorC c = (CharacterMotorC) world.player.GetComponent("CharacterMotorC");
		c.movement.maxForwardSpeed = defaultSpeed;
		c.movement.maxSidewaysSpeed = defaultSpeed;
//		c.movement.maxBackwardsSpeed = defaultSpeed;
		running = false;
	}
	
	//Check player field of view
	//return game object if it exists, otherwise return null
	
}
