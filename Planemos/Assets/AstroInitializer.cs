using UnityEngine;
using System.Collections;

public class AstroInitializer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find("MapController").GetComponent<LevelSetup>().InitializeMap();
	}
}
