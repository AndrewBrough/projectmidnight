using UnityEngine;
using System.Collections;

public class fadeInOnStart : MonoBehaviour {

	private GUIText title;
	private Color fade = new Color(0,0,0,0);
	// Use this for initialization
	void Start () {
		title = this.GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		fade.a += 0.01f;
		title.material.color = fade;
//		print (title.color);
	}
}