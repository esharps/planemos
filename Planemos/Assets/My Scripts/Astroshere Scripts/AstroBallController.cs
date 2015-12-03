using UnityEngine;
using System.Collections;

public class AstroBallController : MonoBehaviour {

	public float speed = 40.0f;
	public float delay = 2.0f;
	public Vector3 startPos;
	public Vector3 eulerAngleVelocity;
	
	Rigidbody rb;
	bool ballInPlay = false;
	int volleyCount = 0;

	void Start(){
	
		rb = GetComponent<Rigidbody> ();
	
	}

	void FixedUpdate(){
		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
		rb.MoveRotation(rb.rotation * deltaRotation);
		if (!ballInPlay) {
			ballInPlay = true;
			StartCoroutine(startBall());
		}
		
		else {
			if( volleyCount > 2 ){
				volleyCount = 0;
				speed += 10.0f;
			}
		}

		if (Vector3.Distance (transform.position, Vector3.zero) > 70) {
			resetBall();
		}
	}

	IEnumerator startBall(){
		yield return new WaitForSeconds(delay);
		randomlyRotate ();
		startMotion ();
	}

	void randomlyRotate(){
		eulerAngleVelocity = new Vector3(
			Random.Range (-200, 200), 
			Random.Range (-200, 200), 
			Random.Range (-200, 200)
			);
	}

	void startMotion(){
		Vector3 dir = Vector3.zero;
		float x = Random.Range (-1.0f, 1.0f);
		float z = Random.Range (-1.0f, 1.0f);
		dir = new Vector3(x, 0, z);
		dir = dir.normalized * speed;
		rb.velocity = dir;
	}

	public void resetBall(){
		ballInPlay = false;
		eulerAngleVelocity = Vector3.zero;
		rb.velocity = Vector3.zero;
		transform.position = startPos;
		volleyCount = 0;
	}
	
	void OnCollisionEnter( Collision coll ){
		if(coll.gameObject.CompareTag ("Enemy") || coll.gameObject.CompareTag("Player"))
			volleyCount++;
	}

	void OnCollisionExit(){
		rb.velocity = rb.velocity.normalized * speed;
	}
}
