using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float ballInitVel = 600f;
	public float startDelay = 10f;
	public GameConroller gc;
	public Vector3 startPos;
	public float xBound;
	public float yBound;

	private Rigidbody rb;
	private bool ballInPlay;


	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}

	void Start(){
		GameObject gameControllerObj = GameObject.FindWithTag ("GameController");
		if (gameControllerObj != null) {
			gc = gameControllerObj.GetComponent<GameConroller> ();
		} else {
			Debug.Log ("Cannot find 'GameController' script.");
		}
	}
	// 36000 = x2 + y2
	// Update is called once per frame
	void Update () {
		if (!ballInPlay) {
			ballInPlay = true;
			StartCoroutine(startBall());
		}

		else {
			if(transform.position.y > yBound)
				transform.position = new Vector3(transform.position.x, -yBound, 0);
			if(transform.position.y < -yBound)
				transform.position = new Vector3(transform.position.x, yBound, 0);
			if(transform.position.x < -xBound)
			{
				gc.incPlayerScore();
				resetBall();
				ballInPlay = false;
			}
			if(transform.position.x > xBound)
			{
				gc.incEnemyScore();
				resetBall();
				ballInPlay = false;
			}
		}
	}

	IEnumerator startBall(){
		yield return new WaitForSeconds(startDelay);
		float x = Random.Range (-1.0f, 1.0f);
		float y = Random.Range (-1.0f, 1.0f);
		Vector3 direction = new Vector3(x, y, 0);
		direction = direction.normalized * ballInitVel;
		rb.AddForce(direction);
	}

	void resetBall(){
		rb.velocity = new Vector3(0,0,0);
		transform.position = startPos;
	}

	public bool isMovingTowardEnemy(){
		return rb.velocity.x < 0;
	}
}
