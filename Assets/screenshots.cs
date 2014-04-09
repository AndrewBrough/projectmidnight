using UnityEngine;
using System.Collections;

public class screenshots : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	private int frame = 0;

	// Update is called once per frame
	void Update () {
		frame++;
		//SCREEN CAP
		if(Input.GetKey(KeyCode.P)){
			Application.CaptureScreenshot("Screenshot_" + frame + ".png", 6);
		}
	}
}
