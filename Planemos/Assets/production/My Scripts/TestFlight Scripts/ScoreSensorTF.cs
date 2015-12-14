using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreSensorTF : MonoBehaviour {
	
	public  Text scoreText;
	public UniversalBallController bc;
	private int score;
	
	public void Start(){

		score = 0;
		scoreText.text = "0";
	}
	
	void OnCollisionEnter(Collision c){
		if (c.gameObject.CompareTag ("Ball")) {
			
			if(scoreText.CompareTag("PlayerScoring"))
				ScoreManager.playerScore++;
				Debug.Log ("Player Scored");

			if(scoreText.CompareTag("EnemyScoring"))
				ScoreManager.enemyScore++;
				Debug.Log ("Enemy Scored");

			score++;
			scoreText.text = "" + score;

			bc.resetBall ();
		}
	}
}
