using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bubbles : MonoBehaviour {

	public static int verticalSize;
	private int horizontalSize;
	private float bubbleSize;

	List<GameObject> gameObjects = new List<GameObject> ();
	public Color firstColor;
	public int firstPosition;
	public static int move;
	
	void Start () {
		int r = Random.Range (5, 11);
		verticalSize = 5;//r;
		horizontalSize = 5;//r;
		move = 50;
		bubbleSize = 20f/Mathf.Max(verticalSize, horizontalSize);
		for (int y = 0; y < verticalSize; y++) {
			for (int x = 0; x < horizontalSize; x++) {
				GameObject prefab = (GameObject)Resources.Load("prefabs/bubble", typeof(GameObject));
				float xx = (float)-10f+0.5f*bubbleSize+x*bubbleSize;
				float yy = (float)10f-0.5f*bubbleSize-y*bubbleSize;
				GameObject bubble = Instantiate(prefab, new Vector3(xx, yy, 0), Quaternion.identity) as GameObject;
				Transform bubbles = (GameObject.Find("Bubbles")).transform;
				bubble.transform.parent = bubbles;
				bubble.transform.localScale = new Vector3(bubbleSize, bubbleSize, 0);
				bubble.name ="Bubble" + y + x;
				if(Random.Range(1,10) <= 2){
					gameObjects.Add (bubble);
				}
			}
		}
		foreach (GameObject go in gameObjects){
			if(go == null) return;
			int rand = Random.Range (1, 4);
			switch (rand){
			case 1:
				firstColor = Color.red;
				break;
			case 2:
				firstColor = Color.green;
				break;
			case 3:
				firstColor = Color.blue;
				break;
			default:
				firstColor = Color.black;
				break;
			}
			go.GetComponent<Renderer>().material.color = firstColor;
		}
	}
	
	void Update () {

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit  = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider != null)
			{
				GameObject go = GameObject.Find(hit.collider.gameObject.name);
				firstColor = go.GetComponent<Renderer>().material.color;
				firstPosition = int.Parse(hit.collider.gameObject.name.Substring(6));

			}
		}
		
		if (Input.GetMouseButtonUp(0))
		{
			RaycastHit2D hit  = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider != null){
				GameObject go = GameObject.Find(hit.collider.gameObject.name);
				int secondPosition = int.Parse(hit.collider.gameObject.name.Substring(6));
				Color secondColor = go.GetComponent<Renderer>().material.color;
				Color resultColor = ColorManager.DefineColor(secondColor, firstColor);
				if(ColorManager.ShouldChangeColor(verticalSize, firstColor, secondColor, firstPosition, secondPosition, int.Parse(hit.collider.gameObject.name.Substring(6)))){
					go.GetComponent<Renderer>().material.color = resultColor;
					move--;
				}
			}
		}
		if (move <= 0) {
			Application.LoadLevel("EndLevel");
		}
	}
}
