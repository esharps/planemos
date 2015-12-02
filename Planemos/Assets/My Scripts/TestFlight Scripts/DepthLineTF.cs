using UnityEngine;
using System.Collections;

public class DepthLineTF : MonoBehaviour {

	public static float zPosition;

	// Use this for initialization
	void Start () {
		zPosition = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (transform.position.z);
	}
}
