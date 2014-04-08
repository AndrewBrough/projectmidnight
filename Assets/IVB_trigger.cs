using UnityEngine;
using System.Collections;

public class IVB_trigger : GameBehaviour {

	public GameObject monster;
	public GameObject crate1;
	public GameObject crate2;
	public GameObject crate3;
	public GameObject force_location;
	public float monsterSpeed = 0.005f;
	private bool complete = false;

	public enum triggerType {
		collision=0,
		heldObject=1
	};

	public triggerType type = triggerType.heldObject;

	// Use this for initialization
	void Start () {
		monster.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(complete){
			monster.transform.LookAt( new Vector3(world.player.transform.position.x, 0, world.player.transform.position.z));
//			if(Vector3.Distance(monster.transform.position, world.player.transform.position) > 2){
//				Vector3 target = new Vector3(world.player.transform.position.x, monster.transform.position.y, world.player.transform.position.z);
//				monster.transform.position = Vector3.MoveTowards(monster.transform.position, target, monsterSpeed);
//			}
		}
	}

	void OnTriggerStay(Collider other){
		if(other.collider.CompareTag("Player")){
			if(type == triggerType.heldObject){
				if(world.player.GetComponent<playerActions>().heldObject != null && world.player.GetComponent<playerActions>().heldObject.CompareTag("powerCell") && !complete){
					StartCoroutine(MoveObjects());
	//				world.camera.GetComponent<cameraShake>().Shake();
					complete = true;
				}
			}
			
			if(type == triggerType.collision){
				if(!complete){
					StartCoroutine(MoveObjects());
	//				world.camera.GetComponent<cameraShake>().Shake();
					complete = true;
				}
			}
		}
	}

	IEnumerator MoveObjects(){
		//reactivate monster
		monster.SetActive(true);
		//move crates
		crate1.rigidbody.AddExplosionForce(2000.0f, force_location.transform.position, 100);
		crate2.rigidbody.AddExplosionForce(1000.0f, force_location.transform.position, 100);
		crate3.rigidbody.AddExplosionForce(3000.0f, force_location.transform.position, 100);

		crate1.audio.Play();
		crate2.audio.Play();

		//ANIMATIONS NOT WORKING!!??
		monster.animation["run"].wrapMode = WrapMode.Loop;
		monster.animation.Play("run");

		yield return new WaitForSeconds(0.5f);
		//play roar animation and sfx
		monster.animation.Play("idle");
		monster.audio.Play ();
		yield return new WaitForSeconds(2);
		monster.animation.Play("run");
		complete = true;
	}

}
