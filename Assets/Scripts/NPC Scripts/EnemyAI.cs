using UnityEngine;
using System.Collections;

public class EnemyAI : GameBehaviour
{
	public float patrolSpeed = 3f;
	public float chaseSpeed = 6f;
	public float chaseWaitTime = 6f;
	public float patrolWaitTime = 1f;
	public Transform[] patrolWayPoints;
	public AudioClip slow;
	public AudioClip fast;

	private EnemySight enemySight;
	private NavMeshAgent nav;
	private Transform player;
	private float chaseTimer;
	private float patrolTimer;
	private int wayPointIndex;
	private bool roared;
	private float delay = 2f;
	private float roarTimer;
	public AudioClip roar;

	void Awake()
	{
		enemySight = GetComponent<EnemySight> ();
		nav = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		roared = true;

		animation["run"].speed = 1.3f;
		animation["walk"].speed = 1.3f;
	}

	void Update()
	{
		if (enemySight.lastSighting != enemySight.resetPosition) {

		
						Chasing ();
				if(Vector3.Distance(this.transform.position, world.player.transform.position) < 4)
				{
					animation.CrossFade("bite");
					animation.CrossFadeQueued("run");
					
				}
		}
		else
						Patrolling ();


	}

	void Chasing()
	{
		print("Chasing");
		Vector3 sightingDeltaPos = enemySight.lastSighting - transform.position;
		if (sightingDeltaPos.sqrMagnitude > 4f)
						nav.destination = enemySight.lastSighting;
		nav.speed = chaseSpeed;

		if (nav.remainingDistance < nav.stoppingDistance) {
						chaseTimer += Time.deltaTime;
			if (chaseTimer > chaseWaitTime) {
								enemySight.lastSighting = enemySight.resetPosition;
								chaseTimer = 0f;
								animation.CrossFade("roar");
								audio.PlayOneShot(roar);
								print ("End chase with roar");
						}
				} 
		else if(world.player.GetComponent<VisibleZones>().visible == false)
		{
			enemySight.lastSighting = enemySight.resetPosition;
			animation.CrossFade("roar");
			audio.PlayOneShot(roar);
			chaseTimer = 0f;
		}
		else {
						chaseTimer = 0f;

				}
	}

	void Patrolling() 
	{
		if(animation["roar"].enabled){
			nav.speed = 0f;
			animation.CrossFadeQueued("walk");
		}
		else
			nav.speed = patrolSpeed;

		if (nav.destination == enemySight.resetPosition || nav.remainingDistance < nav.stoppingDistance) {
						patrolTimer += Time.deltaTime;

						if (patrolTimer >= patrolWaitTime) {
								if (wayPointIndex == patrolWayPoints.Length - 1)
										wayPointIndex = 0;
								else 
										wayPointIndex++;

								patrolTimer = 0;
						}
				} else
						patrolTimer = 0;

		nav.destination = patrolWayPoints [wayPointIndex].position;
	}
}
