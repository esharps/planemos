using UnityEngine;
using System.Collections;

public class DepthLineTF : MonoBehaviour {

	Vector3 currLinePos;
	public float xLinePos = 0;
	public float yLinePos = -13;

	//public static float zPosition;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		currLinePos = new Vector3 (xLinePos, yLinePos, BallPositionTrackerTF.ballPosZ);
		transform.position = currLinePos;
	}
}
