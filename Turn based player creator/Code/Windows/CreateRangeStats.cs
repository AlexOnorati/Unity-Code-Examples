using UnityEngine;
using UnityEditor;
using System.Collections;

public class CreateRangeStats : EditorWindow
{

    private new string name = "";
    private int health;
    private int attack;
    private int defense;
    private int speed;
    private int magicAttack;
    private int magicDefense;
    private int magicPower;
    private int luck;

    public int endHealth;
    public int endAttack;
    public int endDefense;
    public int endSpeed;
    public int endMagicAttack;
    public int endMagicDefense;
    public int endMagicPower;
    public int endLuck;

    [MenuItem("Tools/Create Range Stat")]
    static void Init()
    {
        CreateRangeStats window = (CreateRangeStats)EditorWindow.GetWindow(typeof(CreateRangeStats));
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Name");
        name = EditorGUILayout.TextField(name, GUILayout.Width(100));
        EditorGUILayout.LabelField("Health");
        EditorGUILayout.BeginHorizontal(GUILayout.Width(10));
        health = EditorGUILayout.IntField(health, GUILayout.Width(20));
        EditorGUILayout.LabelField("-", GUILayout.Width(10));
        endHealth = EditorGUILayout.IntField(endHealth, GUILayout.Width(20));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.LabelField("Attack");
        EditorGUILayout.BeginHorizontal(GUILayout.Width(10));
        attack = EditorGUILayout.IntField(attack, GUILayout.Width(20)); 
        EditorGUILayout.LabelField("-", GUILayout.Width(10)); 
        endAttack = EditorGUILayout.IntField(endAttack, GUILayout.Width(20));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.LabelField("Defense");
        EditorGUILayout.BeginHorizontal(GUILayout.Width(10));
        defense = EditorGUILayout.IntField(defense, GUILayout.Width(20));
        EditorGUILayout.LabelField("-", GUILayout.Width(10));
        endDefense = EditorGUILayout.IntField(endDefense, GUILayout.Width(20));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.LabelField("Magic Attack");
        EditorGUILayout.BeginHorizontal(GUILayout.Width(10));
        magicAttack = EditorGUILayout.IntField(magicAttack, GUILayout.Width(20));
        EditorGUILayout.LabelField("-", GUILayout.Width(10));
        endMagicAttack = EditorGUILayout.IntField(endMagicAttack, GUILayout.Width(20));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.LabelField("Magic Defense");
        EditorGUILayout.BeginHorizontal(GUILayout.Width(10));
        magicDefense = EditorGUILayout.IntField(magicDefense, GUILayout.Width(20));
        EditorGUILayout.LabelField("-", GUILayout.Width(10));
        endMagicDefense = EditorGUILayout.IntField(endMagicDefense, GUILayout.Width(20));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.LabelField("Magic Power");
        EditorGUILayout.BeginHorizontal(GUILayout.Width(10));
        magicPower = EditorGUILayout.IntField(magicPower, GUILayout.Width(20));
        EditorGUILayout.LabelField("-", GUILayout.Width(10));
        endMagicPower = EditorGUILayout.IntField(endMagicPower, GUILayout.Width(20));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.LabelField("Speed");
        EditorGUILayout.BeginHorizontal(GUILayout.Width(10));
        speed = EditorGUILayout.IntField(speed, GUILayout.Width(20));
        EditorGUILayout.LabelField("-", GUILayout.Width(10));
        endSpeed = EditorGUILayout.IntField(endSpeed, GUILayout.Width(20));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.LabelField("Luck");
        EditorGUILayout.BeginHorizontal(GUILayout.Width(10));
        luck = EditorGUILayout.IntField(luck, GUILayout.Width(20));    
        EditorGUILayout.LabelField("-", GUILayout.Width(10));
        endLuck = EditorGUILayout.IntField(endLuck, GUILayout.Width(20));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        if (name.Length > 0 && GUILayout.Button("Create Rate Stat")) {
            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath("Assets/StatRange/" + name + ".asset");
            RangeStats asset = RangeStats.ConstructScriptableObject();
            asset.Init(health, attack, defense, speed, magicAttack, magicDefense, magicPower, name, luck, endHealth, endAttack, endDefense, endSpeed, endMagicAttack, endMagicDefense, endMagicPower, endLuck);
            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Close();
        }
    }
}