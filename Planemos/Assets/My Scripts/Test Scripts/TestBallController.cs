using UnityEngine;
using System.Collections;

public class TestBallController : MonoBehaviour {

	public float speed;
	public float delay;
	public Vector3 startDirection;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		StartCoroutine(startBall());
	}
	
	IEnumerator startBall(){
		yield return new WaitForSeconds(delay);
		Vector3 velocityVector = startDirection * speed;
		rb.velocity = velocityVector;
	}
}
