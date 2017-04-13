using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateEnemy: EditorWindow
{
    private int health;
    private int attack;
    private int defense;
    private int speed;
    private int magicAttack;
    private int magicDefense;
    private int magicPower;
    private int tensionPower;
    private ElementType firstElement = ElementType.NONE;
    private ElementType secondElement = ElementType.NONE;
    private new string name;
    private Texture image;
    private int luck;
    private string description;
    private int experience;

    [MenuItem("Tools/Create Enemy")]
    static void Init()
    {
        CreateEnemy window = (CreateEnemy)EditorWindow.GetWindow(typeof(CreateEnemy));
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical(GUILayout.Width(500), GUILayout.Height(750));
        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Name");
        name = EditorGUILayout.TextField(name);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Description");
        description = EditorGUILayout.TextArea(description);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Image");
        image = (Texture)EditorGUILayout.ObjectField(image, typeof(Texture), false);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Health");
        health = EditorGUILayout.IntField(health);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Attack");
        attack = EditorGUILayout.IntField(attack);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Defense");
        defense = EditorGUILayout.IntField(defense);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Speed");
        speed = EditorGUILayout.IntField(speed);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Magic Attack");
        magicAttack = EditorGUILayout.IntField(magicAttack);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Magic Defense");
        magicDefense = EditorGUILayout.IntField(magicDefense);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Magic Power");
        magicPower = EditorGUILayout.IntField(magicPower);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Luck");
        luck = EditorGUILayout.IntField(luck);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Experience");
        experience = EditorGUILayout.IntField(experience);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Tension Power");
        tensionPower = EditorGUILayout.IntField(tensionPower); 
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("First Element");
        firstElement = (ElementType)EditorGUILayout.EnumPopup(firstElement);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Second Element");
        secondElement = (ElementType)EditorGUILayout.EnumPopup(secondElement);
        EditorGUILayout.EndHorizontal();

        if (name != null && name.Length > 0 && description != null && description.Length > 0 && image != null && GUILayout.Button("create"))
        {

            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath("Assets/ScriptableObject/Enemies/" + name + ".asset");
            BaseStat baseStats = BaseStat.ConstructScriptableObject(health, attack, defense, speed, magicAttack,
                 magicDefense, magicPower, tensionPower, name, image, luck, description, experience);
            GameObject enemy = new GameObject(name);
            enemy.AddComponent(typeof(Drops));
            enemy.AddComponent(typeof(Enemy));
          
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.baseStats = baseStats;
            enemyScript.firstElement = firstElement;
            enemyScript.secondElement = secondElement;

            AssetDatabase.CreateAsset(baseStats, assetPathAndName);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            PrefabUtility.CreatePrefab("Assets/Prefabs/Enemies/" + name + ".prefab", enemy);

            GameObject.DestroyImmediate(enemy);
            Close();
        }
        EditorGUILayout.EndVertical();
    }

}