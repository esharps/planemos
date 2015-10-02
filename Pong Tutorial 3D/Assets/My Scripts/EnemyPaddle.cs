using UnityEngine;
using System.Collections;

public class EnemyPaddle : MonoBehaviour {
	public GameObject ball;
	public BallController ballController;
	public float tooClose = 50;
	public float paddleSpeed = 1;
	public float xBound;
	public float yBound;


//	// Use this for initialization
//	void Start () {
//		ball = GameObject.FindWithTag ("Ball");
//		if (ball) {
//			ballController = ball.GetComponent<BallController>();
//		}
//	}
	
	// Update is called once per frame
	void Update () {
		float xPos = transform.position.x;
		float yPos = transform.position.y;
		float ballXPos = ball.transform.position.x;	
		float ballYPos = ball.transform.position.y;
		if (ballIsTooClose () && ballController.isMovingTowardEnemy ()) {
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
		transform.position = new Vector3(Mathf.Clamp (xPos, -xBound, xBound), Mathf.Clamp(yPos, -yBound, yBound), transform.position.z);
	}

	bool ballIsTooClose(){
		float distToBall = Vector3.Distance (transform.position, ball.transform.position);
		return distToBall < tooClose;
	}
	
}
