using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSetup : MonoBehaviour {

	public int numPlayers;
	public float mapRadius;
	public GameObject sepPrefab;
	public GameObject enemyPrefab;
	public GameObject playerPrefab;
	private Bounds sepBounds;
	private Bounds paddleBounds;
//	private List<GameObject> separators;

	// Use this for initialization
	void Start () {

		float separation = 360 / numPlayers;
		float offset = separation / 2;
		for (int i = 0; i < numPlayers; i++) {
			GameObject sep = Instantiate (sepPrefab) as GameObject;
			PolarCalculator sepPc = sep.GetComponent<PolarCalculator>();
			sepPc.radius = mapRadius;
			sepPc.startAngle = i * separation + offset;
			sepPc.InitializePosition();
		}

		sepBounds = sepPrefab.GetComponent<Renderer> ().bounds;
		paddleBounds = playerPrefab.GetComponent<Renderer> ().bounds;
//		float circumference = 2 * Mathf.PI * mapRadius;
		float paddleHalf = paddleBounds.size.x/2;
		float sepHalf = sepBounds.size.x / 2;
		float paddleSepOffset = paddleHalf + sepHalf;
		float movementOffset = ((paddleSepOffset / mapRadius) * (180 / Mathf.PI)) * 2;
		float movementRange = separation/2 - movementOffset;
		GameObject player = Instantiate(playerPrefab) as GameObject;
		PolarCalculator playerPc = player.GetComponent<PolarCalculator> ();
		playerPc.radius = mapRadius;
		playerPc.startAngle = 0;
		playerPc.movementRange = movementRange;
		playerPc.InitializePosition ();

		for (int i = 1; i < numPlayers; i++) {
			GameObject enemy = Instantiate(enemyPrefab) as GameObject;
			PolarCalculator enemyPc = enemy.GetComponent<PolarCalculator>();
			enemyPc.radius = mapRadius;
			enemyPc.startAngle = i * separation;
			enemyPc.movementRange = movementRange;
			enemyPc.InitializePosition();
		}

	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}
}
