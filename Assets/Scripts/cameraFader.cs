using UnityEngine;
using System.Collections;

public class cameraFader : MonoBehaviour
{
	public float lightLevel;
	
    void Awake ()
    {
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }
    
	void Update(){
		guiTexture.color = new Color(0,0,0,1-lightLevel);
	}
}