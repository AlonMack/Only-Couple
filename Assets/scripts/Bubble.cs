using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class Bubble : MonoBehaviour {
	private Animator animator;
	private Animation animation;
	private GameObject go;
	
	void Start () {
		animation = GetComponent<Animation> ();
		animator = GetComponent<Animator> ();
		Vector3 scale = animation.transform.localScale;
		animator.SetInteger ("FieldSize", Convert.ToInt32(Bubbles.verticalSize));
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit  = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider != null)
			{
				go = GameObject.Find(hit.collider.gameObject.name);
				animator = go.GetComponent<Animator>();
				animator.speed=10;
			}
		}
		
		if (Input.GetMouseButtonUp (0)) {
			animator.speed=1;
		}
	}
}
