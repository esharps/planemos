using UnityEngine;
using System.Collections;

public class EnemyPaddle : MonoBehaviour {
	public Ball ball;
	public float tooClose = 50;
	public float paddleSpeed = 1;


	// Use this for initialization
	void Start () {
		GameObject ballObject = GameObject.FindWithTag ("Ball");
		if (ballObject != null) {
			ball = ballObject.GetComponent<Ball>();	
		}
	}
	
	// Update is called once per frame
	void Update () {
		float yPos = transform.position.y;
		float ballYPos = ball.transform.position.y;
		float ballXPos = ball.transform.position.x;
		if (ballIsTooClose () && ball.isMovingTowardEnemy ()) {
			if (yPos < ballYPos)
				yPos += paddleSpeed * 0.1f;
			if (yPos > ballYPos)
				yPos -= paddleSpeed * 0.1f;
		} else {
			if (yPos < 0)
				yPos += paddleSpeed * 0.1f;
			if (yPos > 0)
				yPos -= paddleSpeed * 0.1f;
		}
		transform.position = new Vector3(-20, yPos, 0);
	}

	bool ballIsTooClose(){
		float distToBall = Vector3.Distance (transform.position, ball.transform.position);
		return distToBall < tooClose;
	}
	
}
