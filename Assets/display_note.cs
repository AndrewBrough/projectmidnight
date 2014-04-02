using UnityEngine;
using System.Collections;


public class display_note : GameBehaviour {

	private heldObjectProperties heldObjProp;
	public GUIText noteHUD;
	private Color noteColor;

	void Start(){
		heldObjProp = transform.GetComponent<heldObjectProperties>();
		noteHUD = Instantiate(noteHUD) as GUIText;
		noteHUD.enabled = false;
		noteColor = noteHUD.color;
		noteColor.a = 0;
	}

	void Update(){
		if(heldObjProp.held && noteColor.a<1){
			noteHUD.enabled = true;
			noteColor.a+=0.01f;
			noteHUD.color = noteColor;
		} else if(noteColor.a>0){
			noteColor.a -= 0.01f;
			noteHUD.color = noteColor;
			if(noteColor.a ==0)
				noteHUD.enabled = false;
		}
	}

}