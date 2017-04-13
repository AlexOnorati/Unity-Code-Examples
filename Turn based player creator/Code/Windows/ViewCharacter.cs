using UnityEngine;
using UnityEditor;

public class ViewCharacter : EditorWindow
{
    private static Character character;
    private static BaseStat current;

    public static void Init(Character currentCharacter)
    {
        ViewCharacter window = (ViewCharacter)EditorWindow.GetWindow(typeof(ViewCharacter));
        character = currentCharacter;
        character.setStats();
        current = character.finalStats;
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Name: " + current.name);
        EditorGUILayout.LabelField("Nickname: " + character.nickname);
        EditorGUILayout.LabelField("Description: " + current.description);
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
        EditorGUILayout.LabelField("First Element: " + character.firstElement);
        EditorGUILayout.LabelField("Second Element: " + character.secondElement);
        EditorGUILayout.EndHorizontal();
    }
}