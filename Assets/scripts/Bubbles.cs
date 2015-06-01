using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bubbles : MonoBehaviour {

	private static int verticalSize;
	private int horizontalSize;
	private float bubbleSize;

	private Dictionary<string, GameObject> gameObjects = new Dictionary<string, GameObject> ();
	private Color firstColor;
	private int firstPosition;
	public static int move;
	
	void Start () {
		List<Level> level= Dao.Loadlevel ();
		LevelConfig config = new LevelConfig().Get ();

		verticalSize = config.VertSize;
		horizontalSize = config.HorSize;
		move = 50;//config.MoveCount;
		bubbleSize = 20f/Mathf.Max(verticalSize, horizontalSize);
		for (int y = 0; y < verticalSize; y++) {
			for (int x = 0; x < horizontalSize; x++) {
				GameObject prefab = (GameObject)Resources.Load("prefabs/bubble", typeof(GameObject));
				float xx = (float)-10f+0.5f*bubbleSize+x*bubbleSize;
				float yy = (float)10f-0.5f*bubbleSize-y*bubbleSize;
				GameObject bubble = Instantiate(prefab, new Vector3(xx, yy, 0), prefab.transform.rotation) as GameObject;
				Transform bubbles = (GameObject.Find("Bubbles")).transform;
				bubble.transform.parent = bubbles;
				bubble.transform.localScale = new Vector3(bubbleSize, bubbleSize, 0);
				bubble.name ="Bubble" + y + x;
				gameObjects.Add (y.ToString() + x, bubble);
			}
		}
		Dictionary<string, Color> colorMap = config.BubbleMap;
		foreach (string s in gameObjects.Keys) {
			if(colorMap[s] == null){
				gameObjects[s].GetComponent<Renderer>().material.color = Color.white;
			} else{
				gameObjects[s].GetComponent<Renderer>().material.color = colorMap[s];
			}
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
				Color resultColor = ColorAndPositionManager.DefineColor(secondColor, firstColor);
				if(ColorAndPositionManager.ShouldChangeColor(verticalSize, firstColor, secondColor, firstPosition, secondPosition, int.Parse(hit.collider.gameObject.name.Substring(6)))){
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
