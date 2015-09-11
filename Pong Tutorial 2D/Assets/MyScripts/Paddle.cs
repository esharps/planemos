using UnityEngine;
using System.Collections;

// Unity Script that dictates Pong Paddle behavior
public class Paddle : MonoBehaviour {

	public float speed = 30;
	public string axis = "Vertical";

	// Update function called over and over again, ROUGHLY 60 times/sec
	// FixedUpdate called over and over in a fixed time interval
	// = really good for physics stuff 
	void FixedUpdate () {

		float v = Input.GetAxisRaw (axis);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, v) * speed;
	}


}
