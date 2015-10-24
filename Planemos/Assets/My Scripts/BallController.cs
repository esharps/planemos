using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	public bool move3d;
	public float ballInitVel = 600f;
	public float startDelay = 2f;
	public float zBound;
	public float xBound;

	public Text ballPosText;//EMILY

	/*
	public int playerScore;
	public int enemyScore;

	public Text playerScoreText;
	public Text enemyScoreText;*/

	//	public GameConroller gc;
	public Vector3 startPos;
	public Vector3 eulerAngleVelocity;
	
	private Rigidbody thisRigidBody;
	private bool ballInPlay = false;
	private int volleyCount = 0;
	
	
	// Use this for initialization
	void Awake () {
		thisRigidBody = GetComponent<Rigidbody> ();
		if (!move3d) {
			thisRigidBody.constraints = RigidbodyConstraints.FreezePositionY;
		}
	}

	void Start() {
		//playerScoreText = GetComponent<Text> ();
		//playerScore = 0;

		//enemyScoreText = GetComponent<Text> ();
		//enemyScore = 0;

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
		if(coll.gameObject.CompareTag ("Paddle"))
			volleyCount++;
	}
}
