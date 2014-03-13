/** Triggering door opening sequences, using a power cell dropped on a pedastal
 * NOTE: every component of the power cell MUST be tagger power cell to work **/

using UnityEngine;
using System.Collections;

public class TriggerDoorPowerCell : MonoBehaviour {

	public GameObject door;
	public BoxCollider doorBoxCollider;
	public GameObject powerCell;

	public AudioClip open;
	public AudioClip close;

	void Start() {

	}

	void OnTriggerStay(Collider other)
	{
		print (other.tag);
		if (other.tag == "powerCell" && powerCell.GetComponent<heldObjectProperties>().held == false) {
			//play open animation
			door.animation.Play ("open");
			door.audio.PlayOneShot(open);
			//remove collider
			doorBoxCollider.enabled = false;
			//delete trigger
			UnityEngine.Object.DestroyObject (transform.collider);
		}
		
	}
}
