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
		float xPos = transform.position.x;
		float ballXPos = ball.transform.position.x;	
		if (ballIsTooClose () && ball.isMovingTowardEnemy ()) {
			if (xPos < ballXPos)
				xPos += paddleSpeed * 0.1f;
			if (xPos > ballXPos)
				xPos -= paddleSpeed * 0.1f;
		} else {
			if (xPos < 0)
				xPos += paddleSpeed * 0.1f;
			if (xPos > 0)
				xPos -= paddleSpeed * 0.1f;
		}
		transform.position = new Vector3(Mathf.Clamp (xPos, -12.5f, 12.5f), transform.position.y, transform.position.z);
	}

	bool ballIsTooClose(){
		float distToBall = Vector3.Distance (transform.position, ball.transform.position);
		return distToBall < tooClose;
	}
	
}
