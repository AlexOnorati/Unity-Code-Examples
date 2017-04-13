using UnityEngine;
using UnityEditor;

public class CreateItem : EditorWindow
{
    private int health;
    private int attack;
    private int defense;
    private int speed;
    private int magicAttack;
    private int magicDefense;
    private int magicPower;
    private int tensionPower;
    private UsageType type = UsageType.NONE;
    private new string name;
    private Texture image;
    private int set;
    private string description;

    [MenuItem("Tools/Create Item")]
    static void Init()
    {
        CreateItem armorWindow = (CreateItem)EditorWindow.GetWindow(typeof(CreateItem));
        armorWindow.Show();
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
        EditorGUILayout.LabelField("Usage Type");
        type = (UsageType)EditorGUILayout.EnumMaskField(type);
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
        EditorGUILayout.LabelField("Tension Power");
        tensionPower = EditorGUILayout.IntField(tensionPower);
        EditorGUILayout.EndHorizontal();

        if (name != null && name.Length > 0 && description != null && description.Length > 0 && image != null && GUILayout.Button("create"))
        {
            string assetPathAndName =
           AssetDatabase.GenerateUniqueAssetPath("Assets/Item/"+name+".asset");

            Item asset = Item.ConstructScriptableObject(
                health, attack, defense, speed, magicAttack,
                magicDefense, magicPower, tensionPower, type, 
                name, image, description);
            AssetDatabase.CreateAsset(asset, assetPathAndName);
       

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Close();
        }
        EditorGUILayout.EndVertical();
    }
}