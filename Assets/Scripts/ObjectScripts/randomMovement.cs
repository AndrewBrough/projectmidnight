using UnityEngine;
using System.Collections;

public class randomMovement : MonoBehaviour {
	
	public float DtoPlayer;
	Vector3 targetPosition;
	
	void Start () {
		targetPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//check if object is held
		heldObjectProperties hop = (heldObjectProperties)this.GetComponent(typeof(heldObjectProperties));
		
		//use distance to player to allow movement, scale it
		getDistanceToPlayer();
		//print(Time.deltaTime);
		
		if(DtoPlayer > 6){
			print(this.transform.position == targetPosition);
			if(this.transform.position == targetPosition)
				targetPosition = Random.onUnitSphere;
			
			//this.rigidbody.isKinematic = true;
			moveObject();
		}else{
			//this.rigidbody.isKinematic = false;
			targetPosition = Random.onUnitSphere;
		}
	}
	
	void getDistanceToPlayer(){
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		
		DtoPlayer = Vector3.Distance( players[0].transform.position, this.transform.position );
	}
	
	void moveObject(){
		this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, 0.1f);
		//(float)Mathf.Pow((float)(DtoPlayer*Time.deltaTime),1.1f)
	}
}
