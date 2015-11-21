using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	//For single player against AI
	public static int playerScore;
	public static int enemyScore;

	void Start() {
		playerScore = 0;
		enemyScore = 0;

	}

	void Update () {
		//Debug.Log ("PLAYER: " + playerScore);
		//Debug.Log ("ENEMY: " + enemyScore); 
	}

	public int GetPlayerScore () {
		return playerScore;
	}

	public int GetEnemyScore() {
		return enemyScore;
	}


}
