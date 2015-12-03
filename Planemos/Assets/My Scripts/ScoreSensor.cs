using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreSensor : MonoBehaviour {

	public  Text scoreText;
	public UniversalBallController bc;
	private int score;

	public void Start(){
		score = 0;
		scoreText.text = "0";
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.CompareTag ("Ball")) {


			Debug.Log ("Someone Scored");
			scoreText.text = score.ToString ();
			bc.resetBall ();
		}
	}
}
