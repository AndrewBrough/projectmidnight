using UnityEngine;
using System.Collections;

public class playerCameraController : MonoBehaviour {
	
	public GameObject player;
	
	public Vector3 targetPosition;
	public float speed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		moveCamera();
		
	}
	
	void moveCamera()
	{
		if(Input.GetKey(KeyCode.W))
		{
			targetPosition.z+=speed;
		}
		if(Input.GetKey(KeyCode.S))
		{
			targetPosition.z-=speed;
		}
		if(Input.GetKey(KeyCode.A))
		{
			targetPosition.x-=speed;
		}
		if(Input.GetKey(KeyCode.D))
		{
			targetPosition.x+=speed;
		}
		transform.position = targetPosition;
	}
}
