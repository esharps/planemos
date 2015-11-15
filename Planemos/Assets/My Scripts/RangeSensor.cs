using UnityEngine;
using System.Collections;

public class RangeSensor : MonoBehaviour {

	public EnemyPaddle Paddle;

	void OnTriggerEnter(Component c){
		if (c.gameObject.CompareTag ("Ball"))
			Paddle.SetInRange (true);
	}

	void OnTriggerExit(Component c){
		if (c.gameObject.CompareTag ("Ball"))
			Paddle.SetInRange (false);
	}
}
