using UnityEngine;
using System.Collections;

public class Load_Logo_3D : MonoBehaviour {

	public GameObject logo;

	// Use this for initialization
	void Start () {
		logo.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(){
		logo.SetActive(true);
	}
}
