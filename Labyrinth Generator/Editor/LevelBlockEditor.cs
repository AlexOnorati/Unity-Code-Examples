using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LevelBlock))]
public class LevelBlockEditor : Editor {
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
		LevelBlock LevelBlockRefence = (LevelBlock)target;
		if(GUILayout.Button("Remove Block"))
		{
			LevelBlockRefence.RemoveBlock();
		}
		if(GUILayout.Button("SetAsPlayerStart")){
			LevelBlockRefence.SetAsPlayerStart();
		}
	}


}
