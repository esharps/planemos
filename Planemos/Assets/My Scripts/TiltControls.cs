using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TiltControls : MonoBehaviour {

	public float paddleSpeed = 1.0f;
	public float xBound;
	public float yBound;
	private Vector3 playerPos;

//	public Text accelText;
//	public Text paddlePos;

	// Update is called once per frame
	void Update () {
		float xPos = transform.position.x + Input.acceleration.x * paddleSpeed;
		float yPos = transform.position.y + Input.acceleration.y * paddleSpeed;
		playerPos = new Vector3 (Mathf.Clamp (xPos, -xBound, xBound), Mathf.Clamp(yPos, -yBound, yBound), transform.position.z);
		transform.position = playerPos;

//		accelText.text = "" + Input.acceleration.x + ", " + Input.acceleration.y + ", " + Input.acceleration.z;
//		paddlePos.text = "Paddle:  " + transform.position.x + ", " + transform.position.y + ", " + transform.position.z;

	}

}
