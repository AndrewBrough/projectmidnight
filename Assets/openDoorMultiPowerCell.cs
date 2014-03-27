using UnityEngine;
using System.Collections;

public class openDoorMultiPowerCell : MonoBehaviour {

	public GameObject trigger1;
	public GameObject trigger2;
	public GameObject trigger3;
	public GameObject trigger4;

	private powerCellTrigger t1;
	private powerCellTrigger t2;
	private powerCellTrigger t3;
	private powerCellTrigger t4;
	private bool active1 = false;
	private bool active2 = false;
	private bool active3 = false;
	private bool active4 = false;

	private bool open = false;
	public int count = 0;
	public int RequiredPowerCells = 1;

	// Use this for initialization
	void Start () {
		t1 = trigger1.GetComponent<powerCellTrigger>();
		if(t2!=null)
			t2 = trigger2.GetComponent<powerCellTrigger>();
		if(t3!=null)
			t3 = trigger3.GetComponent<powerCellTrigger>();
		if(t4!=null)
			t4 = trigger4.GetComponent<powerCellTrigger>();
	}
	
	// Update is called once per frame
	void Update () {

		//count up
		if(t1.isTriggered && !active1){
			active1 = true;
			count++;
		}
		if(t2!=null && t2.isTriggered && !active2){
			active2 = true;
			count++;
		}
		if(t3!=null && t3.isTriggered && !active3){
			active3 = true;
			count++;
		}
		if(t4!=null && t4.isTriggered && !active4){
			active4 = true;
			count++;
		}

		//count down
		if(!t1.isTriggered && active1){
			active1 = false;
			count--;
		}
		if(t2!=null && !t2.isTriggered && active2){
			active2 = false;
			count--;
		}
		if(t3!=null && !t3.isTriggered && active3){
			active3 = false;
			count--;
		}
		if(t4!=null && !t4.isTriggered && active4){
			active4 = false;
			count--;
		}


		if(count == RequiredPowerCells && !open){
			open = true;
			animation.Play("open");
		}else if(count != RequiredPowerCells && open){
			open = false;
			animation.Play("close");
		}
	}
}