/** Triggering door opening sequences, using a power cell dropped on a pedastal
 * NOTE: every component of the power cell MUST be tagger power cell to work **/

using UnityEngine;
using System.Collections;

public class TriggerIslandPowerCell : GameBehaviour {

	public islandManager iMan;
	public int switchNumber;

	void Start() {
		
	}


	void OnTriggerStay(Collider other)
	{
		//Double if instead of && so that we don't try to check for a heldObjectProperties that isn't there
		if (other.tag == "powerCell") {
			if (other.GetComponent<heldObjectProperties>().held == false && other.GetComponent<heldObjectProperties>().isOnTrigger == false){
				other.GetComponent<heldObjectProperties>().isOnTrigger = true;
				other.transform.rotation = new Quaternion(0,0,0,0);
				other.transform.position = this.transform.position;
				other.rigidbody.velocity = Vector3.zero;

				switch(switchNumber){
				case 1:
					iMan.switch1 = true;
					break;
				case 2:
					iMan.switch2 = true;
					break;
				case 3:
					iMan.switch3 = true;
					break;
				case 4:
					iMan.switch4 = true;
					break;
				}

			}
			if (other.GetComponent<heldObjectProperties>().held == true){
				other.GetComponent<heldObjectProperties>().isOnTrigger = false;
				switch(switchNumber){
				case 1:
					iMan.switch1 = false;
					break;
				case 2:
					iMan.switch2 = false;
					break;
				case 3:
					iMan.switch3 = false;
					break;
				case 4:
					iMan.switch4 = false;
					break;
				}
			}



		}


		
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "powerCell") {
			other.GetComponent<heldObjectProperties>().isOnTrigger = false;


			switch(switchNumber){
			case 1:
				iMan.switch1 = false;
				break;
			case 2:
				iMan.switch2 = false;
				break;
			case 3:
				iMan.switch3 = false;
				break;
			case 4:
				iMan.switch4 = false;
				break;
			}

		}


	}


}
