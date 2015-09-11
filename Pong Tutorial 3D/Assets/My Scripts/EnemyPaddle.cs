using UnityEngine;
using System.Collections;

public class EnemyPaddle : MonoBehaviour {
	public Ball ball;

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
		if (ball.isMovingTowardEnemy()) {
			if (yPos < ballYPos)
				yPos += .2f;
			if (yPos > ballYPos)
				yPos -= .2f;
		}
		transform.position = new Vector3(-20, yPos, 0);
	}
}
