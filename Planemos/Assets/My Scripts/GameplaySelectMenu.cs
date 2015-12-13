using UnityEngine;
using System.Collections;

public class GameplaySelectMenu: MonoBehaviour {
	
	public void TopDownSelectediPhone(){
		Application.LoadLevel ("Top Down 2D iPhone Master");
	}
	
	public void FirstPersonSelectediPhone(){
		Application.LoadLevel ("Continuum iPhone Master");
	}

	public void TopDownSelectediPad(){
		Application.LoadLevel ("Top Down 2D iPad Master");
	}
	
	public void FirstPersonSelectediPad(){
		Application.LoadLevel ("Continuum iPad Master");
	}

	public void QuitSelected() {
		Application.Quit ();
	}
}
