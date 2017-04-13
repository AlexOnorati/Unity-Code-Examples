using UnityEngine;
using System.Collections;
using UnityEditor;

public class ViewWeapon : EditorWindow
{
    private static Weapon current;

    public static void Init(Weapon currentWeapon)
    {
        ViewWeapon armorWindow = (ViewWeapon)EditorWindow.GetWindow(typeof(ViewWeapon));
        current = currentWeapon;
        armorWindow.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Name: " + current.name);
        EditorGUILayout.LabelField("Description: " + current.description);
        EditorGUILayout.LabelField("Armor Set: " + current.set);
        EditorGUILayout.EndVertical();
        GUILayout.Box(current.image, GUILayout.Width(64), GUILayout.Height(64));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Health: " + current.health);
        EditorGUILayout.LabelField("Speed: " + current.speed);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Attack: " + current.attack);
        EditorGUILayout.LabelField("Defense: " + current.defense);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Magic Attack: " + current.magicAttack);
        EditorGUILayout.LabelField("Magic Defense: " + current.magicDefense);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Magic Power: " + current.magicPower);
        EditorGUILayout.LabelField("Tension Power: " + current.tensionPower);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("First Element: " + current.firstElement);
        EditorGUILayout.LabelField("Second Element: " + current.secondElement);
        EditorGUILayout.EndHorizontal();
    }
}
