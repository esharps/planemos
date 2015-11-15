using UnityEngine;
using System.Collections;

public class EnemyPaddle : MonoBehaviour {
	public GameObject 				ball;
	public UniversalBallController	ballController;
	public MapContstraints			mapConstraints;
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
		if (inRange && ballIsMovingTowardMe()) {

			float ballXPos = ball.transform.position.x;
			if (xPos < ballXPos)
				xPos += paddleSpeed;
			if (xPos > ballXPos)
				xPos -= paddleSpeed;

			float ballYPos = ball.transform.position.y;
			if(yPos < ballYPos)
				yPos += paddleSpeed;
			if(yPos > ballYPos){
				yPos -= paddleSpeed;
			}
		} else {
			if (xPos < -paddleSpeed)
				xPos += paddleSpeed;
			else if (xPos > paddleSpeed)
				xPos -= paddleSpeed;
			if(yPos < -paddleSpeed)
				yPos += paddleSpeed;
			else if(yPos > paddleSpeed)
				yPos -= paddleSpeed;
		}
		rb.MovePosition(new Vector3(Mathf.Clamp (xPos, -xBound, xBound), Mathf.Clamp(yPos, -yBound, yBound), transform.position.z));
	}

	private bool ballIsMovingTowardMe(){
		if(mapConstraints.axisOfPlay == AxisOfPlay.Z){
			return ball.GetComponent<Rigidbody>().velocity.z > 0.0f;
		}
		return false;
	}
	public void SetInRange(bool r){
		inRange = r;
	}
}
