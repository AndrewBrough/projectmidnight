using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	public float patrolSpeed = 2f;
	public float chaseSpeed = 5f;
	public float chaseWaitTime = 8f;
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

	void Awake()
	{
		enemySight = GetComponent<EnemySight> ();
		nav = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update()
	{
		if (enemySight.lastSighting != enemySight.resetPosition)
						Chasing ();
				else
						Patrolling ();
	}

	void Chasing()
	{

		print ("Chasing");
		Vector3 sightingDeltaPos = enemySight.lastSighting - transform.position;
		if (sightingDeltaPos.sqrMagnitude > 4f)
						nav.destination = enemySight.lastSighting;
		nav.speed = chaseSpeed;

		if (nav.remainingDistance < nav.stoppingDistance) {
						chaseTimer += Time.deltaTime;
						if (chaseTimer > chaseWaitTime) {
								enemySight.lastSighting = enemySight.resetPosition;
								chaseTimer = 0f;
								print ("End chase");
						}
				} else {
						chaseTimer = 0f;
						print ("End chase");

				}
	}

	void Patrolling() 
	{
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
