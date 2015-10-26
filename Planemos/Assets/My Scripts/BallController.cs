using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	public bool move3d;
	public float ballInitVel = 100f;
	public float startDelay = 2f;
	public float zBound;
	public float xBound;

	public Text ballPosText;//EMILY

	public Vector3 startPos;
	public Vector3 eulerAngleVelocity;
	
	private Rigidbody thisRigidBody;
	private bool ballInPlay = false;
	private int volleyCount = 0;
	
	// Use this for initialization
	void Start () {
		thisRigidBody = GetComponent<Rigidbody> ();
		if (!move3d) {
			thisRigidBody.constraints = RigidbodyConstraints.FreezePositionY;
		}
	}

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
			if( volleyCount > 2 ){
				volleyCount = 0;
				Vector3 currentVel = thisRigidBody.velocity;
				Vector3 newVel = currentVel * 1.5f;
				thisRigidBody.velocity = newVel;
			}
			if(transform.position.z < -zBound)
			{
				ScoreManager.enemyScore++; //EMILY
				resetBall();
				ballInPlay = false;
			}
			if(transform.position.z > zBound)
			{
				ScoreManager.playerScore++;//EMILY
				resetBall();
				ballInPlay = false;
			}
		}

		ballPosText.text = "Ball z = " + transform.position.z;
	}
	
	IEnumerator startBall(){
		yield return new WaitForSeconds(startDelay);
		eulerAngleVelocity = new Vector3(
			Random.Range (-200, 200), 
			Random.Range (-200, 200), 
			Random.Range (-200, 200)
			);

		Vector3 direction = getDir ();
		direction = direction.normalized * ballInitVel;
		thisRigidBody.AddForce(direction);
	}

	Vector3 getDir(){
		Vector3 dir = Vector3.zero;
		float x = Random.Range (-0.5f, 0.5f);
		float z = Mathf.Sign(Random.Range (-1.0f, 1.0f));
		if (move3d) {
			float y = Random.Range (-0.5f, 0.5f);
			dir = new Vector3(x,y,z);
		} else {
			dir = new Vector3(x, 0, z);
		}
		dir = dir.normalized * ballInitVel;
		return dir;
	}
	
	void resetBall(){
		eulerAngleVelocity = Vector3.zero;
		thisRigidBody.velocity = Vector3.zero;
		transform.position = startPos;
		volleyCount = 0;
	}
	
	public bool isMovingToward(Vector3 pos){
		Vector3 ballToPos = pos - transform.position;
		return Vector3.Dot(thisRigidBody.velocity, ballToPos) > 0; 
	}
	
	void OnCollisionEnter( Collision coll ){
		if(coll.gameObject.CompareTag ("Enemy") || coll.gameObject.CompareTag("Player"))
			volleyCount++;
	}
}
