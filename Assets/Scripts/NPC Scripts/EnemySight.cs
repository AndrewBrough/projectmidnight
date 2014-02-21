using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {
	public float fieldOfViewAngle = 110f;
	public bool playerInSight;
	public Vector3 lastSighting;

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
		lastSighting = new Vector3();
		previousSighting = new Vector3();

	}

	void Update() {
		previousSighting = lastSighting;

	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject == player) {

			/*is the player in the field of view of the enemy?*/
			playerInSight = false;

			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);

			if(angle < fieldOfViewAngle * 0.5f)
			{
				/*player is in FOV, check if player isn't obscured by anything*/
				/*NOTE: col.radius + 40 only temporary due to how scaling works
				 * will be changed once monster is properly implemented*/
				RaycastHit hit;
				if(Physics.Raycast(transform.position, direction.normalized, out hit, col.radius + 40))
				{
					if(hit.collider.gameObject == player)
					{
						playerInSight = true;
						lastSighting = player.transform.position;

					}
				}

			}
		}
	}



}
