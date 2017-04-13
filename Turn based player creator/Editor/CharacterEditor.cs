using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;


[CustomEditor(typeof(Character))]
public class CharterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
      
        Character scriptTarget = (Character)target;
        EditorGUILayout.LabelField("Level: " + scriptTarget.Level);
        if(GUILayout.Button("Charater Stat")){
           
            ViewCharacter.Init(scriptTarget);

        }
    }
}
