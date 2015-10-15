using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Joystick2DTestControls : MonoBehaviour {

	Rigidbody2D myBody;
	public float moveForce = 5;

	void Start () {
	
		myBody = this.GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		Vector2 moveVec = new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
		myBody.MovePosition (moveVec);
	}
}
