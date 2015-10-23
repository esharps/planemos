using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameConroller : MonoBehaviour {

//	public int playerScore;
//	public int enemyScore;
	public GameObject player;
	public GameObject ball;
//	public GUIText playerScoreText;
//	public GUIText enemyScoreText;


	void Awake(){
//		player.GetComponent<PlayerNetworkSetup> ().enabled = false;
//		player.GetComponent<PlayerSyncPosition> ().enabled = false;
//		player.GetComponent<PaddleControls> ().enabled = true;
//		player.GetComponent<MeshCollider> ().enabled = true;
//		player.GetComponent<NetworkTransform> ().enabled = false;
//		player.GetComponent<NetworkIdentity> ().enabled = false;
	}
	// Use this for initialization
	void Start () {
		ball.SetActive (true);
		ball.GetComponent<BallController> ().enabled = true;
		player.SetActive (true);
		
//		playerScore = 0;
//		enemyScore = 0;
//		UpdateScore ();
	}

	// Update is called once per frame
	void UpdateScore () {
//		playerScoreText.text = "" + playerScore;
//		enemyScoreText.text = "" + enemyScore; 
	}


//	public void incPlayerScore(){
//		playerScore++;
//		UpdateScore ();
//	}
//
//	public void incEnemyScore(){
//		enemyScore++;
//		UpdateScore ();
//	}
}
