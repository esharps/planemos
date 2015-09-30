using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float ballInitVel = 600f;
	public float startDelay = 2f;
	public GameConroller gc;
	public Vector3 startPos;
	public float zBound;
	public float xBound;
	public Vector3 eulerAngleVelocity;

	private Rigidbody thisRigidBody;
	private bool ballInPlay = false;
	private int volleyCount = 0;


	// Use this for initialization
	void Awake () {
		thisRigidBody = GetComponent<Rigidbody> ();
	}

//	void Start(){
//		GameObject gameControllerObj = GameObject.FindWithTag ("GameController");
//		if (gameControllerObj != null) {
//			gc = gameControllerObj.GetComponent<GameConroller> ();
//		} else {
//			Debug.Log ("Cannot find 'GameController' script.");
//		}
//	}

	void FixedUpdate(){
		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
		thisRigidBody.MoveRotation(thisRigidBody.rotation * deltaRotation);
	}

	// Update is called once per frame
	void Update () {
		if (!ballInPlay) {
			ballInPlay = true;
			StartCoroutine(startBall());
		}

		else {
			if( volleyCount > 3 ){
				volleyCount = 0;
				Vector3 currentVel = thisRigidBody.velocity;
				Vector3 newVel = new Vector3(currentVel.x + Mathf.Sign(currentVel.x) * 5.0f, 0, currentVel.z + Mathf.Sign(currentVel.z) * 5.0f);
				thisRigidBody.velocity = newVel;
			}
			if(transform.position.z < -zBound)
			{
//				gc.incPlayerScore();
				resetBall();
				ballInPlay = false;
			}
			if(transform.position.z > zBound)
			{
//				gc.incEnemyScore();
				resetBall();
				ballInPlay = false;
			}
		}
	}

	IEnumerator startBall(){
		yield return new WaitForSeconds(startDelay);
		eulerAngleVelocity = new Vector3(
			Random.Range (-200, 200), 
			Random.Range (-200, 200), 
			Random.Range (-200, 200)
			);
		float x = Random.Range (-0.5f, 0.5f);
		float z = Mathf.Sign(Random.Range (-1.0f, 1.0f));
		Vector3 direction = new Vector3(x, 0, z).normalized;
		direction = direction.normalized * ballInitVel;
		thisRigidBody.AddForce(direction);
	}

	void resetBall(){
		eulerAngleVelocity = Vector3.zero;
		thisRigidBody.velocity = Vector3.zero;
		transform.position = startPos;
		volleyCount = 0;
	}

	public bool isMovingTowardEnemy(){
		return thisRigidBody.velocity.z > 0;
	}

	void OnCollisionEnter( Collision coll ){
		if(coll.gameObject.CompareTag ("Paddle"))
			volleyCount++;
	}
}
