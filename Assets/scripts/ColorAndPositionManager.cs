using UnityEngine;
using System.Collections;

public class ColorAndPositionManager {
	
	public static Color DefineColor(Color sourceColor, Color targetColor){
		if (sourceColor.Equals (targetColor)) return sourceColor;
		if (sourceColor.Equals (Color.white) || sourceColor.Equals (Color.black)) return targetColor;
		if (targetColor.Equals (Color.white) || targetColor.Equals (Color.black)) return sourceColor;
		if (sourceColor.Equals (Color.red) && targetColor.Equals(Color.green)) return Color.yellow;
		if (targetColor.Equals (Color.red) && sourceColor.Equals(Color.green)) return Color.yellow;
		if (sourceColor.Equals (Color.red) && targetColor.Equals(Color.blue)) return Color.magenta;
		if (targetColor.Equals (Color.red) && sourceColor.Equals(Color.blue)) return Color.magenta;		
		if (sourceColor.Equals (Color.red) && targetColor.Equals(Color.cyan)) return Color.white;
		if (targetColor.Equals (Color.red) && sourceColor.Equals(Color.cyan)) return Color.white;
		if (sourceColor.Equals (Color.red) && targetColor.Equals(Color.magenta)) return Color.blue;
		if (targetColor.Equals (Color.red) && sourceColor.Equals(Color.magenta)) return Color.blue;
		if (sourceColor.Equals (Color.red) && targetColor.Equals(Color.yellow)) return Color.green;
		if (targetColor.Equals (Color.red) && sourceColor.Equals(Color.yellow)) return Color.green;
		if (sourceColor.Equals (Color.green) && targetColor.Equals(Color.blue)) return Color.cyan;
		if (targetColor.Equals (Color.green) && sourceColor.Equals(Color.blue)) return Color.cyan;
		if (sourceColor.Equals (Color.green) && targetColor.Equals(Color.cyan)) return Color.blue;
		if (targetColor.Equals (Color.green) && sourceColor.Equals(Color.cyan)) return Color.blue;
		if (sourceColor.Equals (Color.green) && targetColor.Equals(Color.yellow)) return Color.red;
		if (targetColor.Equals (Color.green) && sourceColor.Equals(Color.yellow)) return Color.red;
		if (sourceColor.Equals (Color.blue) && targetColor.Equals(Color.cyan)) return Color.green;
		if (targetColor.Equals (Color.blue) && sourceColor.Equals(Color.cyan)) return Color.green;
		if (sourceColor.Equals (Color.blue) && targetColor.Equals(Color.magenta))return Color.red;
		if (targetColor.Equals (Color.blue) && sourceColor.Equals(Color.magenta))return Color.red;
		if (sourceColor.Equals (Color.blue) && targetColor.Equals(Color.yellow)) return Color.white;
		if (targetColor.Equals (Color.blue) && sourceColor.Equals(Color.yellow)) return Color.white;
		return Color.black;
	}

	public static bool EqualsColor(Color resultColor, Color color){
		return resultColor != Color.white && resultColor.Equals (color);
	}

	public static bool TwoAlreadyExist(int vertSize, int targetPos, Color resultColor){
		int uPos = targetPos - 1;
		int uuPos = targetPos - 2;
		int bPos = targetPos + 1;
		int bbPos = targetPos + 2;
		int lPos = targetPos + 10;
		int llPos = targetPos + 20;
		int rPos = targetPos - 10;
		int rrPos = targetPos - 20;
		Color uColor = Color.white;
		Color uuColor = Color.white;
		Color bColor = Color.white;
		Color bbColor = Color.white;
		Color lColor = Color.white;
		Color llColor = Color.white;
		Color rColor = Color.white;
		Color rrColor = Color.white;
		
		if (InField (uPos, vertSize)) uColor = GetColorByPosition (uPos);
		if (InField (uuPos, vertSize)) uuColor = GetColorByPosition (uuPos);
		if (InField (bPos, vertSize)) bColor = GetColorByPosition (bPos);
		if (InField (bbPos, vertSize)) bbColor = GetColorByPosition (bbPos);
		if (InField (lPos, vertSize)) lColor = GetColorByPosition (lPos);
		if (InField (llPos, vertSize)) llColor = GetColorByPosition (llPos);
		if (InField (rPos, vertSize)) rColor = GetColorByPosition (rPos);
		if (InField (rrPos, vertSize))	rrColor = GetColorByPosition (rrPos);
		
		return EqualsColor (resultColor, uColor) && EqualsColor (resultColor, uuColor)
			|| EqualsColor (resultColor, bColor) && EqualsColor (resultColor, bbColor)
			|| EqualsColor (resultColor, uColor) && EqualsColor (resultColor, bColor)
			|| EqualsColor (resultColor, lColor) && EqualsColor (resultColor, llColor)
			|| EqualsColor (resultColor, rColor) && EqualsColor (resultColor, rrColor)
			|| EqualsColor (resultColor, lColor) && EqualsColor (resultColor, rColor);
	}

	private static Color GetColorByPosition(int pos){
		if (pos <= 9)
			return GameObject.Find ("Bubble" + 0 + pos).GetComponent<Renderer> ().material.color;	
		return GameObject.Find ("Bubble" + pos).GetComponent<Renderer> ().material.color;	
	}

	static bool IsNeighbor(int soursePos, int targetPos){

		return soursePos.Equals (targetPos + 1) 
			|| soursePos.Equals (targetPos - 1) 
			|| soursePos.Equals (targetPos + 10)
			|| soursePos.Equals (targetPos - 10);
	}
	
	public static bool InField(int pos, int vertSize){
		return pos / 10 >= 0 && pos / 10 < vertSize && pos % 10 >=0 && pos % 10 <vertSize;
	}
	
	
	public static bool ShouldChangeColor(int vertSize, Color firstColor, Color secondColor, int firstPosition, int secondPosition, int position){
		return !firstColor.Equals (secondColor)
			&& !firstColor.Equals (Color.white)
			&& !(firstColor.Equals (Color.black) || secondColor.Equals (Color.black))
			&& IsNeighbor (firstPosition, secondPosition) 
			&& !TwoAlreadyExist (vertSize, position, DefineColor (firstColor, secondColor));
	}

	public static Color GetColorByName(string colorStr){
		switch (colorStr) {
		case "red": return Color.red;
			case "green": return Color.green;
			case "blue": return Color.blue;
			case "cyan": return Color.cyan;
			case "magenta": return Color.magenta;
			case "yellow": return Color.yellow;
			case "black": return Color.black;
			case "white": return Color.white;
			default :return Color.black;
		}
	}
}