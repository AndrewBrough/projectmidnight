using UnityEngine;
using System.Collections;

public class randomMovement : MonoBehaviour {
	
	float DtoPlayer;
	Vector3 targetPosition;
	//float lastTime;
	// Use this for initialization
	void Start () {
		targetPosition = this.transform.position;
		//lastTime = Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		print(Random.onUnitSphere);
		//check if object is held
		heldObjectProperties hop = (heldObjectProperties)this.GetComponent(typeof(heldObjectProperties));
		
		//use distance to player to allow movement, scale it
		getDistanceToPlayer();
		//print(Time.deltaTime);
		
		if(hop != null && !hop.held && DtoPlayer > 6){
			targetPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
			targetPosition = Vector3.MoveTowards(targetPosition, Random.onUnitSphere,  (float)Mathf.Pow((float)(DtoPlayer*Time.deltaTime),1.1f));
			this.transform.position = targetPosition;
		}
	}
	
	void getDistanceToPlayer(){
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		
		DtoPlayer = Vector3.Distance( players[0].transform.position, this.transform.position );
	}
}
