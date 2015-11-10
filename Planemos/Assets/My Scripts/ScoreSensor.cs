using UnityEngine;
using System.Collections;

public class ScoreSensor : MonoBehaviour {

	public GUIText scoreText;
	public UniversalBallController bc;
	private int score;

	public void Start(){
		score = 0;
		scoreText.text = "0";
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.CompareTag ("Ball")) {
			score++;
			scoreText.text = score.ToString ();
			bc.resetBall ();
		}
	}
}
