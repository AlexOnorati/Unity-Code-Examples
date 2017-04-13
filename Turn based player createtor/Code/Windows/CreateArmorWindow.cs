using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateArmorWindow : EditorWindow
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
    private ArmorType type = ArmorType.NONE;
    private new string name;
    private Texture image;
    private int set;
    private string description;
    private int luck;
    private int experience;

    //[MenuItem("Tools/Create Armor")]
    static void Init()
    {
        CreateArmorWindow armorWindow = (CreateArmorWindow)EditorWindow.GetWindow(typeof(CreateArmorWindow));
        armorWindow.Show();
    }
     
    void OnGUI()
    {
        EditorGUILayout.BeginVertical( GUILayout.Width(500), GUILayout.Height(750));
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
        EditorGUILayout.LabelField("Armor Type");
        type = (ArmorType)EditorGUILayout.EnumPopup(type);
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
        EditorGUILayout.LabelField("Luck");
        luck = EditorGUILayout.IntField(luck);
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
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("First Element");
        firstElement = (ElementType)EditorGUILayout.EnumPopup(firstElement);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Second Element");
        secondElement = (ElementType)EditorGUILayout.EnumPopup(secondElement);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Armor Set");
        set = EditorGUILayout.IntField(set);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Armor Set");
        set = EditorGUILayout.IntField(set);
        EditorGUILayout.EndHorizontal();


        if (name != null && name.Length > 0 && description != null && description.Length > 0 && image != null && GUILayout.Button("create")) {
            string assetPathAndName =
           AssetDatabase.GenerateUniqueAssetPath("Assets/Armor/" + name + ".asset");
            switch (type) {
                case ArmorType.HEAD:
                    assetPathAndName = AssetDatabase.GenerateUniqueAssetPath("Assets/Armor/Heads/" + name + ".asset");
                    Head headAsset = Head.ConstructScriptableObject(health, attack, defense, speed, magicAttack,
                magicDefense, magicPower, tensionPower, firstElement, secondElement, name, image,
                set, description, luck, experience);
                    AssetDatabase.CreateAsset(headAsset, assetPathAndName);
                    break;
                case ArmorType.CHEST:
                    assetPathAndName = AssetDatabase.GenerateUniqueAssetPath("Assets/Armor/Chests/" + name + ".asset");
                    Chest chestAsset = Chest.ConstructScriptableObject(health, attack, defense, speed, magicAttack,
                magicDefense, magicPower, tensionPower, firstElement, secondElement, name, image,
                set, description, luck, experience);
                    AssetDatabase.CreateAsset(chestAsset, assetPathAndName);
                    break;
                case ArmorType.ARMS:
                    assetPathAndName = AssetDatabase.GenerateUniqueAssetPath("Assets/Armor/Arms/" + name + ".asset");
                    Arm armAsset = Arm.ConstructScriptableObject(health, attack, defense, speed, magicAttack,
                magicDefense, magicPower, tensionPower, firstElement, secondElement, name, image,
                set, description, luck, experience);
                    AssetDatabase.CreateAsset(armAsset, assetPathAndName);
                    break;
                case ArmorType.LEGS:
                    assetPathAndName = AssetDatabase.GenerateUniqueAssetPath("Assets/Armor/Legs/" + name + ".asset");
                    Leg legAsset = Leg.ConstructScriptableObject(health, attack, defense, speed, magicAttack,
                magicDefense, magicPower, tensionPower, firstElement, secondElement, name, image,
                set, description, luck, experience);
                    AssetDatabase.CreateAsset(legAsset, assetPathAndName);
                    break;
                case ArmorType.BOOTS:
                    assetPathAndName = AssetDatabase.GenerateUniqueAssetPath("Assets/Armor/Boots/" + name + ".asset");
                    Boot bootAsset = Boot.ConstructScriptableObject(health, attack, defense, speed, magicAttack,
                   magicDefense, magicPower, tensionPower, firstElement, secondElement, name, image,
                set, description, luck, experience);
                    AssetDatabase.CreateAsset(bootAsset, assetPathAndName);
                    break;
            }



            if (type != ArmorType.NONE) {
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                Close();
            }
        }
        EditorGUILayout.EndVertical();
    }
    
}
