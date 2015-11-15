using UnityEngine;
using System.Collections;

public class ResponsiveCamera : MonoBehaviour {
	const float EPSILON = 0.001f;

	public MapContstraints mc;

	void Awake () {
		transform.position = mc.CamPositionDefault;
		transform.eulerAngles = mc.CamRotationDefault;
		Debug.Log ("16:9: " + 16.0f/9.0f);
		Debug.Log ("4:3: " + 4.0f/3.0f);
		Debug.Log ("Aspect: " + Camera.main.aspect);

		if (System.Math.Abs (Camera.main.aspect - 16.0f / 9.0f) < EPSILON){
			transform.position = mc.CamPosition_16_9;
			transform.eulerAngles = mc.CamRotation_16_9;

		}
		else if (System.Math.Abs (Camera.main.aspect - 4.0f / 3.0f) < EPSILON){
			transform.position = mc.CamPosition_4_3;
			transform.eulerAngles = mc.CamRotation_4_3;
			Debug.Log("4:3");
		} else {
			Debug.Log("Default");
		}
	}
}
