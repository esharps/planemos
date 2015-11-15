using UnityEngine;
using System.Collections;

public class ResponsiveCamera : MonoBehaviour {
	const float EPSILON = 0.001f;

	public MapContstraints mc;

	void Awake () {
		transform.position = mc.CamPositionDefault;
		transform.eulerAngles = mc.CamRotationDefault;

		if (System.Math.Abs (Camera.main.aspect - 16 / 9) < EPSILON){
			transform.position = mc.CamPosition_16_9;
			transform.eulerAngles = mc.CamRotation_16_9;
			Debug.Log ("16:9");
		}
		else if (System.Math.Abs (Camera.main.aspect - 4 / 3) < EPSILON){
			transform.position = mc.CamPosition_4_3;
			transform.eulerAngles = mc.CamRotation_4_3;
			Debug.Log("4:3");
		} else {
			Debug.Log("Default");
		}
	}
}
