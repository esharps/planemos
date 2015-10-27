using UnityEngine;
using System.Collections;

public class TitleRotate : MonoBehaviour {

    float rot_speed = 4;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, rot_speed * Time.deltaTime, 0);
	}
}
