using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

	public void OnGUI(){
		GUI.Box (new Rect (0,10,60,90), "Move: " + Bubbles.move);
	}
}
