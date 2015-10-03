using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int playerScore;
	public static int enemyScore;

	Text playerScoreText;
	Text enemyScoreText;
	
	void Awake () {

		playerScore = 0;
		playerScoreText = GetComponent<Text> ();
		playerScoreText.text = "" + playerScore;

		enemyScore = 0;
		enemyScoreText = GetComponent<Text> ();
		enemyScoreText.text = "" + enemyScore;
	}
	

	void Update () {
		playerScoreText.text = "" + playerScore;
		enemyScoreText.text = "" + enemyScore;
	}

	// If the enemy scores on the player, increment enemy score
	void OnEnemyScore() {
		enemyScore++;
		enemyScoreText.text = "" + enemyScore;
	}

	// If the player scores on the enemy, increment player score
	void OnPlayerScore() {
		playerScore++;
		playerScoreText.text = "" + playerScore;
	}

}
