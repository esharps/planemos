using UnityEngine;
using System.Collections;

public class TestingMenu: MonoBehaviour {

	public void TopDownSelected(){
		Application.LoadLevel ("ContinuumTD");
	}

	public void FirstPersonSelected(){
		Application.LoadLevel ("Continuum");
	}
}
