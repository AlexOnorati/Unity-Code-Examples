using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;


[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Enemy scriptTarget = (Enemy)target;
        if (GUILayout.Button("Monster Stats"))
        {

            ViewEnemy.Init(scriptTarget);
        }
    }
}