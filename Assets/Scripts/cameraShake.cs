/** from http://www.mikedoesweb.com/2012/camera-shake-in-unity/ **/

using UnityEngine;
using System.Collections;

public class cameraShake : MonoBehaviour {
	private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay;
	public float shake_intensity;
	public GameObject fps;
	bool isShaking;
	
	/*void OnGUI (){
		if (GUI.Button (new Rect (20,40,80,20), "Shake")){
			Shake ();
		}
	}*/
	
	void Update (){
		if (isShaking) {
						if (shake_intensity > 0) {
								fps.transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
								fps.transform.rotation = new Quaternion (
				originRotation.x + Random.Range (-shake_intensity, shake_intensity) * .2f,
				originRotation.y + Random.Range (-shake_intensity, shake_intensity) * .2f,
				originRotation.z + Random.Range (-shake_intensity, shake_intensity) * .2f,
				originRotation.w + Random.Range (-shake_intensity, shake_intensity) * .2f);
						
								shake_intensity -= shake_decay;
						} else {
								fps.transform.position = originPosition;// new Vector3(originPosition.x, 1.0f, originPosition.z);
								fps.transform.rotation = originRotation;
								isShaking = false;
								print (fps.transform.position);
						}
				}
	}
	
	public void Shake(){
		originPosition = fps.transform.position;
		originRotation = fps.transform.rotation;
		shake_intensity = .3f;
		shake_decay = 0.008f;
		isShaking = true;
	}
}