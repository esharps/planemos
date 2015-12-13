using UnityEngine;
using System.Collections;

public class AstroScoreEventManager : MonoBehaviour {

	public delegate void ScoreHandler(float angle);
	public static event ScoreHandler OnScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter( Collision c ){
		if(c.gameObject.CompareTag("ScoreSensor")){
			float angle = Vector3.Angle( Vector3.right, transform.position );
			if( transform.position.z < 0 ){
				angle += 180 * Mathf.Deg2Rad;
			}
			if(OnScore != null){
				OnScore( angle );
			}
		}
	}
}
