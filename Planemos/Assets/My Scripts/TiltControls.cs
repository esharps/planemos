using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TiltControls : MonoBehaviour {

	public float paddleSpeed = 0.15f;
	public float xBound;
	public float yBound;

	// Are we tilting along the y axis?
	public bool topDownMotion = true;

	// Are we tilting in two degrees of freedom, x and y?
	public bool threeDMotion = false;

	float xPos;
	float yPos;
	private Vector3 playerPos;

	public Text accelText;
	public Text paddlePos;
	
	void Update () {

		// Only need to worry about one-degree of freedom
		// NOTE: Tilting iPad in y-direction moves paddle along x-axis
		if (topDownMotion && !threeDMotion) {

			// iPad is being tilted downward (- direction)
			if (Input.acceleration.y < 0) {
				xPos = transform.position.x - paddleSpeed;
			} 
			// iPad is being tilted to the right (+ direction)
			else {
				xPos = transform.position.x + paddleSpeed;
			}
		}

		// Worry about two-degrees of freedom along x and y axis
		if (threeDMotion && !topDownMotion) {

			// iPad is being tilted to the left (- direction)
			if (Input.acceleration.x < 0) {
				xPos = transform.position.x - paddleSpeed;
			} 
			// iPad is being tilted to the right (+ direction)
			else {
				xPos = transform.position.x + paddleSpeed;
			}

			// iPad is tilted downward (- direction)
			if(Input.acceleration.y < 0) {
				yPos = transform.position.y - paddleSpeed;
			}
			// iPad is tilted upward (+ direction)
			else {
				yPos = transform.position.y + paddleSpeed;
			}

		}

		//float xPos = transform.position.x + Input.acceleration.x * paddleSpeed;
		//float yPos = transform.position.y + Input.acceleration.y * paddleSpeed;
		playerPos = new Vector3 (Mathf.Clamp (xPos, -xBound, xBound), Mathf.Clamp(yPos, -yBound, yBound), transform.position.z);
		transform.position = playerPos;

		accelText.text = "" + Input.acceleration.x + ", " + Input.acceleration.y + ", " + Input.acceleration.z;
		paddlePos.text = "Paddle:  " + transform.position.x + ", " + transform.position.y + ", " + transform.position.z;

	}

}
