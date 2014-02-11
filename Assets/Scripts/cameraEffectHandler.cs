using UnityEngine;
using System.Collections;

public class cameraEffectHandler : GameBehaviour {
	
	public float lightLevel;
	
    void Awake ()
    {
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }
    
	void Update(){
		guiTexture.color = new Color(0,0,0,1-lightLevel);
	}
	
	public void changeFOV(float degree){
		world.camera.fov = degree;
	}
	
	public void changeAngle(float angle){
		world.camera.transform.Rotate(0, 0, angle);
	}
	
}
