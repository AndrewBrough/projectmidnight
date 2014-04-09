using UnityEngine;
using System.Collections;

public class closeDoor : MonoBehaviour {

	public GameObject door;
	public int count = 1;

	public int type = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if( type == 0 && other.tag == "Player" && count > 0){
			count--;
			door.animation.Play("close");
		}
		if( type == 1 && other.tag == "Player" && count > 0){
			count--;
			door.animation.Play("open");
		}
	}
}
