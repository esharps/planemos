using UnityEngine;
using System.Collections;

public class ResponsiveCamera : MonoBehaviour {
	const float EPSILON = 0.001f;

	public MapContstraints mapContstraints;

	void Awake () {
		transform.position = mapContstraints.CamPositionDefault;
		transform.eulerAngles = mapContstraints.CamRotationDefault;

		if (System.Math.Abs (Camera.main.aspect - 16.0f / 9.0f) < EPSILON){
			transform.position = mapContstraints.CamPosition_16_9;
			transform.eulerAngles = mapContstraints.CamRotation_16_9;

		}
		else if (System.Math.Abs (Camera.main.aspect - 4.0f / 3.0f) < EPSILON){
			transform.position = mapContstraints.CamPosition_4_3;
			transform.eulerAngles = mapContstraints.CamRotation_4_3;
		}
	}
}
