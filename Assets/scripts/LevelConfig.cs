using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelConfig{

	int number;
	int vertSize;
	int horSize;
	Dictionary<string,Color> bubbleMap = new Dictionary<string, Color> ();
	Dictionary<string,Color> cloudeMap;
	bool allField;
	int moveCount;

	public int GetFieldSize(){
		return Mathf.Max (vertSize, horSize);
	}

	public LevelConfig Get(){
		LevelConfig co = new LevelConfig();
		string encodedString = Dao.Loadlevel()[0].Config;
		JSONObject level = new JSONObject(encodedString);
		int num = (int)level.list[0].n;
		co.number = num;

		JSONObject size = level.list[1];
		int vertical = (int)size.list [0].n;
		int horizontal = (int)size.list [1].n;
		co.vertSize = vertical;
		co.horSize = horizontal;
		for (int y=0; y<co.vertSize; y++){
			for(int x=0; x<co.horSize; x++){
				bubbleMap.Add(y.ToString() + x, Color.white);
			}
		}
		co.bubbleMap = bubbleMap;

		List<JSONObject> bubble = level.list [2].list [0].list;
		for (int i = 0; i< bubble.Count; i++) {
			co.bubbleMap[bubble[i].keys[0]] = ColorAndPositionManager.GetColorByName(bubble[i].list[0].str);
		}

		return co;
	}

	public int Number {
		get {
			return this.number;
		}
		set {
			number = value;
		}
	}

	public int VertSize {
		get {
			return this.vertSize;
		}
		set {
			vertSize = value;
		}
	}

	public int HorSize {
		get {
			return this.horSize;
		}
		set {
			horSize = value;
		}
	}

	public Dictionary<string, Color> BubbleMap {
		get {
			return this.bubbleMap;
		}
		set {
			bubbleMap = value;
		}
	}

	public Dictionary<string, Color> CloudeMap {
		get {
			return this.cloudeMap;
		}
		set {
			cloudeMap = value;
		}
	}

	public bool AllField {
		get {
			return this.allField;
		}
		set {
			allField = value;
		}
	}
	public int MoveCount {
		get {
			return this.moveCount;
		}
		set {
			moveCount = value;
		}
	}
}