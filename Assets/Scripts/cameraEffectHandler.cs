using UnityEngine;
using System.Collections;

public class cameraEffectHandler : GameBehaviour {
	
	public float lightLevel;
	public float vignette1_L;
	public float vignette2_L;

    void Awake ()
    {
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }
    
	void Update(){
		guiTexture.color = new Color(0,0,0,1-lightLevel);

		world.vignette1.color = new Color (0, 0, 0, 1 - vignette1_L);
		world.vignette2.color = new Color (0, 0, 0, 1 - vignette2_L);

	}

	public void changeFOV(float degree){
		world.camera.fieldOfView = degree;
	}
	
	public void changeAngle(float angle){
		world.camera.transform.Rotate(0, 0, angle);
	}
	
}
