using UnityEngine;
using System.Collections;

public class TriggerVisible : GameBehaviour {

	void OnTriggerEnter(Collider other) {
		//if(other == world.player)
		if(world.player.GetComponent<VisibleZones>().visible == false)
			world.player.GetComponent<VisibleZones>().visible = true;
		else 
			world.player.GetComponent<VisibleZones>().visible = false;


	}

}
