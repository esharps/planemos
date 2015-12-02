using UnityEngine;
using System.Collections;

public class BallPositionTrackerTF : MonoBehaviour {

	Vector3 ballPosition;
	public static float ballPosX;
	public static float ballPosY;
	public static float ballPosZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ballPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		ballPosX = ballPosition.x;
		ballPosY = ballPosition.y;
		ballPosZ = ballPosition.z;

		Debug.Log (ballPosX);
	}
}
