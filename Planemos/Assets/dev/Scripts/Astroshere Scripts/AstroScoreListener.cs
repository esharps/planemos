using UnityEngine;
using System.Collections;

public class AstroScoreListener : MonoBehaviour {
	
	int health;
	float scoreAreaRange;
	float scoreAreaMax;
	float scoreAreaMin;

	void OnEnable(){
		AstroScoreEventManager.OnScore += HandleOnScore;
	}

	void OnDisable(){
		AstroScoreEventManager.OnScore -= HandleOnScore;
	}

	void HandleOnScore (float angle)
	{
		if(inScoreArea(angle)){
			health--;
			Debug.Log( health );
		}
	}

	// Use this for initialization
	void Start () {
		float startAngle = GetComponent<PolarCalculator>().startAngle;
		health = 2;
		scoreAreaMax = startAngle + scoreAreaRange;
		scoreAreaMin = startAngle - scoreAreaRange;
	}

	bool inScoreArea(float angle){
		return scoreAreaMax > angle && scoreAreaMin < angle;
	}

	public void SetScoreAreaRange(float range){
		scoreAreaRange = range;
	}

	void Update(){
		if(health <= 0){
			GameObject.Find("MapController").GetComponent<LevelSetup>().ReconfigureMap();
		}
	}
}

