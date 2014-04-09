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

	private bool roared;
	private float chaseDelay = 6f;
	private float delay = 2f;
	private float roarTimer;
	private float chaseTimer;
	private bool chasing;
	public AudioClip monsterSound;

	public enum triggerType {
		collision=0,
		heldObject=1
	};

	public triggerType type = triggerType.heldObject;

	// Use this for initialization
	void Start () {
		monster.SetActive(false);
		roared = false;
		chasing = false;
		monster.animation["run"].speed = 1.3f;
	}
	
	// Update is called once per frame
	void Update () {
		if(complete){
			monster.transform.LookAt( new Vector3(world.player.transform.position.x, 0, world.player.transform.position.z));
//			if(Vector3.Distance(monster.transform.position, world.player.transform.position) > 2){
//				Vector3 target = new Vector3(world.player.transform.position.x, monster.transform.position.y, world.player.transform.position.z);
//				monster.transform.position = Vector3.MoveTowards(monster.transform.position, target, monsterSpeed);
//			}
		
		
			if(Time.time > roarTimer && !roared)
			{
				monster.animation.CrossFade("roar");
				roared = true;
			}
			else if(roared)
			{
				//if (monster.animation["roar"].enabled == false)
					monster.animation.CrossFadeQueued ("idle");
			}

			if(Time.time > chaseTimer && !chasing)
			{
				monster.animation.CrossFade("run");
				chasing = true;

			}
			else if(chasing)
			{
				Vector3 target = new Vector3(world.player.transform.position.x, monster.transform.position.y, world.player.transform.position.z);
				monster.transform.position = Vector3.MoveTowards(monster.transform.position, target, monsterSpeed);
				if(Vector3.Distance(monster.transform.position, world.player.transform.position) < 4)
				{
					monster.animation.CrossFade("bite");
					monster.animation.CrossFadeQueued("run");

				}
			}
		}

		/*else if(complete && monster.activeInHierarchy)
		{


		}*/
	}

	void OnTriggerStay(Collider other){
		if(other.collider.CompareTag("Player")){
			if(type == triggerType.heldObject){
				if(world.player.GetComponent<playerActions>().heldObject != null && world.player.GetComponent<playerActions>().heldObject.CompareTag("powerCell") && !complete){
					StartCoroutine(MoveObjects());
					monster.audio.PlayOneShot(monsterSound);
	//				world.camera.GetComponent<cameraShake>().Shake();
					complete = true;
				}
			}
			
			if(type == triggerType.collision){
				if(!complete){
					StartCoroutine(MoveObjects());
					monster.audio.PlayOneShot(monsterSound);
	//				world.camera.GetComponent<cameraShake>().Shake();
					complete = true;
				}
			}
		}
	}

	IEnumerator MoveObjects(){
		//reactivate monster
		monster.SetActive(true);

		monster.animation.Play("idle");

		roarTimer = Time.time + delay;
		chaseTimer = Time.time + chaseDelay;

		//move crates
		crate1.rigidbody.AddExplosionForce(2000.0f, force_location.transform.position, 100);
		crate2.rigidbody.AddExplosionForce(1000.0f, force_location.transform.position, 100);
		crate3.rigidbody.AddExplosionForce(3000.0f, force_location.transform.position, 100);

		crate1.audio.Play();
		crate2.audio.Play();

		//ANIMATIONS NOT WORKING!!??
		//monster.animation["run"].wrapMode = WrapMode.Loop;

		yield return new WaitForSeconds (1);

		//monster.audio.Play();
		//monster.animation.Play("roar");

		yield return new WaitForSeconds(10);
		//play roar animation and sfx
		monster.animation.Play("idle");

		yield return new WaitForSeconds(20);
		monster.animation.Play("run");
		complete = true;
	}

}
