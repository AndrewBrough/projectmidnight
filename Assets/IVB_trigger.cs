using UnityEngine;
using System.Collections;

public class IVB_trigger : GameBehaviour {

	public GameObject monster;
	public GameObject crate1;
	public GameObject crate2;
	public GameObject crate3;
	public GameObject force_location;

	private bool complete = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(){
		if(world.player.GetComponent<playerActions>().heldObject != null && !complete){
			
			StartCoroutine(MoveObjects());
			monster.transform.LookAt(world.player.transform);
			world.camera.GetComponent<cameraShake>().Shake();

			complete = true;
			print (complete);
		}
	}

	IEnumerator MoveObjects(){
		//move crates
		crate2.rigidbody.AddExplosionForce(2000.0f, force_location.transform.position, 100);
		crate3.rigidbody.AddExplosionForce(2000.0f, force_location.transform.position, 100);
		crate2.audio.Play();
		crate3.audio.Play();
		yield return new WaitForSeconds(0.5f);
		monster.transform.Translate(new Vector3(0,0,0));
		monster.audio.Play ();
//		StopCoroutine("MoveObjects");
	}
}
