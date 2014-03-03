using UnityEngine;
using System.Collections;

public class IIIB_Trigger : MonoBehaviour {

	public GameObject door;
	public BoxCollider doorBoxCollider;
	public GameObject powerCell;

	// Use this for initialization
	void Start () {

	
	}

	void OnTriggerStay(Collider other)
	{
//		print (other.tag);
		if (other.tag == "powerCell" && powerCell.GetComponent<heldObjectProperties>().held == false) {
			//play open animation
			door.animation.Play ("open");
			//remove collider
			doorBoxCollider.enabled = false;
			//delete trigger
			UnityEngine.Object.DestroyObject (transform.collider);
		}

	}
	


}
