using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class Bubble : MonoBehaviour {
	private Animator animator;
	private GameObject go;

	void Start () {
		animator = GetComponent<Animator> ();
		animator.SetInteger ("FieldSize", 5);
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit  = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider != null)
			{
				go = GameObject.Find(hit.collider.gameObject.name);
				animator = go.GetComponent<Animator>();
				animator.speed=0;
			}
		}
		
		if (Input.GetMouseButtonUp (0)) {
			animator.speed=3;
		}
	}
}
