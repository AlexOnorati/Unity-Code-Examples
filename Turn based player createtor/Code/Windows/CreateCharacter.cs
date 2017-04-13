using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateCharacter : EditorWindow
{
    private string nickname;
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

    [MenuItem("Tools/Create Character")]
    static void Init()
    {
        CreateCharacter window = (CreateCharacter)EditorWindow.GetWindow(typeof(CreateCharacter));
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
        EditorGUILayout.LabelField("Nickname");
        nickname = EditorGUILayout.TextField(nickname);
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

            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath("Assets/ScriptableObject/Characters/"+name+".asset");
           BaseStat baseStats = BaseStat.ConstructScriptableObject(health, attack, defense, speed, magicAttack,
                magicDefense, magicPower, tensionPower, name, image, luck, description, experience);
            GameObject character = new GameObject(name);
            character.AddComponent(typeof(Equipment));
            character.AddComponent(typeof(Character));
            Character characterScript = character.GetComponent<Character>();
            
            AssetDatabase.CreateAsset(baseStats, assetPathAndName);            
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            characterScript.firstElement = firstElement;
            characterScript.secondElement = secondElement;
            characterScript.nickname = nickname;
            characterScript.baseStats = baseStats;
            PrefabUtility.CreatePrefab("Assets/Prefabs/Characters/" + name + ".prefab", character);
          
            GameObject.DestroyImmediate(character);
            Close();
        }
        EditorGUILayout.EndVertical();
    }

}