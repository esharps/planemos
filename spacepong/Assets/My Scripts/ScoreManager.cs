using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	//For single player against AI
	public static int playerScore;
	public static int enemyScore;
	public Text playerScoreText;
	public Text enemyScoreText;

	//For multiplayer games
	public static int p1Score;
	public static int p2Score;
	public static int p3Score;
	public static int p4Score;

	void Awake () {

		playerScore = 0;
		//playerScoreText = GetComponent<Text> ();
		playerScoreText.text = "" + playerScore;

		enemyScore = 0;
		//enemyScoreText = GetComponent<Text> ();
		enemyScoreText.text = "" + enemyScore;
	}
	

	void Update () {
		playerScoreText.text = "" + playerScore;
		enemyScoreText.text = "" + enemyScore;
	}


}
