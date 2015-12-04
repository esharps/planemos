using UnityEngine;
using System.Collections;

public class GameplaySelectMenu: MonoBehaviour {
	
	public void TopDownSelected(){
		Application.LoadLevel ("Top Down 2D iPad TF2");
	}
	
	public void FirstPersonSelected(){
		Application.LoadLevel ("Continuum iPad TF2.1");
	}
}
