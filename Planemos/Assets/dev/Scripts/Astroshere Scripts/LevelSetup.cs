using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSetup : MonoBehaviour {

	public AstroBallController 	ballController;
	public int					numPlayers;
	public float 				mapRadius;
	public GameObject			separatorPrefab;
	public GameObject			enemyPrefab;
	public GameObject			playerPrefab;

	Bounds sepBounds;
	Bounds paddleBounds;
	float paddleHalf;
	float sepHalf;
	float paddleSepOffset;
	float separation;
	float offset;
	float movementOffset;
	float movementRange;
	bool transitioning;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}

	public void InitializeMap(){
		calculateOffsets();	
		GameObject firstSep = Instantiate(separatorPrefab);
		PolarCalculator firstSepPc = firstSep.GetComponent<PolarCalculator>();
		firstSepPc.radius = mapRadius;
		firstSepPc.startAngle = offset;
		firstSepPc.Initialize( mapRadius, offset, movementRange);
		firstSepPc.MoveToStart();
		
		GameObject player = Instantiate(playerPrefab);
		PolarCalculator playerPc = player.GetComponent<PolarCalculator> ();
		AstroScoreListener playerScoreListener = player.GetComponent<AstroScoreListener>();
		playerPc.Initialize( mapRadius, 0, movementRange);
		playerPc.MoveToStart();
		playerScoreListener.SetScoreAreaRange(offset);
		
		for (int i = 1; i < numPlayers; i++) {
			GameObject nextSep = Instantiate (separatorPrefab);
			PolarCalculator sepPc = nextSep.GetComponent<PolarCalculator>();
			sepPc.Initialize(mapRadius, i * separation + offset, 0);
			sepPc.MoveToStart();
			
			GameObject enemy = Instantiate(enemyPrefab);
			PolarCalculator enemyPc = enemy.GetComponent<PolarCalculator>();
			AstroScoreListener enemyScoreListener = enemy.GetComponent<AstroScoreListener>();
			SeparatorController separatorController = enemy.GetComponent<SeparatorController>();
			separatorController.associatedSeparator = nextSep;
			enemyPc.Initialize(mapRadius, i * separation, movementRange);
			enemyPc.MoveToStart();
			enemyScoreListener.SetScoreAreaRange(offset);
		}
	}

	public void calculateOffsets(){

		sepBounds = separatorPrefab.GetComponent<Renderer> ().bounds;
		sepHalf = sepBounds.size.x / 2;
		paddleBounds = playerPrefab.GetComponent<Renderer> ().bounds;
		paddleHalf = paddleBounds.size.x/2;
		paddleSepOffset = paddleHalf + sepHalf;
		movementOffset = ((paddleSepOffset / mapRadius) * (180 / Mathf.PI)) * 2;
		separation = 360 / numPlayers;
		offset = separation / 2;
		movementRange = separation/2 - movementOffset;
	
	}

	public void ReconfigureMap(){
		numPlayers --;
		Application.LoadLevel(Application.loadedLevel);
	}
}
