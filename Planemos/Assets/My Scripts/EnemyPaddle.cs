using UnityEngine;
using System.Collections;

public class EnemyPaddle : MonoBehaviour {
	public GameObject 				ball;
	public UniversalBallController	ballController;
	public float 					paddleSpeed	= 1.0f;
	public float 					xBound 		= 12.5f;
	public float 					yBound 		= 8.0f;

	private Rigidbody 				rb;
	private bool 					inRange;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		inRange = false;
	}
	
	// Update is called once per frame
	void Update () {
		float xPos = transform.position.x;
		float yPos = transform.position.y;
		float ballXPos = ball.transform.position.x;	
		float ballYPos = ball.transform.position.y;
		if (inRange && ballController.isMovingToward(transform.position)) {
			if (xPos < ballXPos)
				xPos += paddleSpeed;
			if (xPos > ballXPos)
				xPos -= paddleSpeed;
			if(yPos < ballYPos)
				yPos += paddleSpeed;
			if(yPos > ballYPos){
				yPos -= paddleSpeed;
			}
		} else {
			if (xPos < 0)
				xPos += paddleSpeed;
			if (xPos > 0)
				xPos -= paddleSpeed;
			if(yPos > 0)
				yPos -= paddleSpeed;
			if(yPos < 0)
				yPos += paddleSpeed;
		}
		rb.MovePosition(new Vector3(Mathf.Clamp (xPos, -xBound, xBound), Mathf.Clamp(yPos, -yBound, yBound), transform.position.z));
	}

	public void SetInRange(bool r){
		inRange = r;
	}

//	bool inRange(){
//		float distToBall = Vector3.Distance (transform.position, ball.transform.position);
//		return distToBall < reactionRange;
//	}
	
}
