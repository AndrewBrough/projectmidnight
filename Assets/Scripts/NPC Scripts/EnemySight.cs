using UnityEngine;
using System.Collections;

public class EnemySight : GameBehaviour {
	public float fieldOfViewAngle = 50f;
	public bool playerInSight;
	public Vector3 lastSighting;
	public Vector3 resetPosition = new Vector3(1000f, 1000f, 1000f); 

	private NavMeshAgent nav;
	private SphereCollider col;
	//private Animator anim;
	private GameObject player;
	private Vector3 previousSighting;

	void Awake() {
		nav = GetComponent<NavMeshAgent> ();
		col = GetComponent<SphereCollider> ();
		//anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag ("Player");



		/*reset*/
		lastSighting = resetPosition;
		previousSighting = resetPosition;

	}

	void Update() {
		previousSighting = lastSighting;

	}

	void OnTriggerExit (Collider other)
	{
		//If the player leaves the trigger zone
		if (other.gameObject == player)
						playerInSight = false;

	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject == player && world.player.GetComponent<VisibleZones>().visible == true) {

			/*is the player in the field of view of the enemy?*/
			playerInSight = false;

			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);

			if(angle < fieldOfViewAngle * 0.5f)
			{
				if(!Physics.Linecast(this.transform.position, player.transform.position)){
				/*player is in FOV, check if player isn't obscured by anything*/
				/*NOTE: col.radius + 40 only temporary due to how scaling works
				 * will be changed once monster is properly implemented*/
				/*RaycastHit hit;
				if(Physics.Raycast(transform.position, direction.normalized, out hit, col.radius + 40))
				{
					if(hit.collider.gameObject == player)
					{*/
						playerInSight = true;
						lastSighting = player.transform.position;
						animation.CrossFade("run");

					/*}
				}*/
				}
			}
		}
	}



}
