using UnityEngine;
using System.Collections;

public class GameConroller : MonoBehaviour {

	public int playerScore;
	public int enemyScore;
	public GUIText playerScoreText;
	public GUIText enemyScoreText;



	// Use this for initialization
	void Start () {
		playerScore = 0;
		enemyScore = 0;
		UpdateScore ();
	}

	// Update is called once per frame
	void UpdateScore () {
		playerScoreText.text = "" + playerScore;
		enemyScoreText.text = "" + enemyScore; 
	}


	public void incPlayerScore(){
		playerScore++;
		UpdateScore ();
	}

	public void incEnemyScore(){
		enemyScore++;
		UpdateScore ();
	}
	

}
