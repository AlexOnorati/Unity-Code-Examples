using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateWeapon : EditorWindow
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
    private int set;
    private string description;
    private WeaponRank rank;
    private WeaponType type;
    private WeaponUsageType usageType;
    private int rankPoints;
    private int luck;
    private bool twoHanded;
    private int experience;

    [MenuItem("Tools/Create Weapon")]
    static void Init()
    {
        CreateWeapon armorWindow = (CreateWeapon)EditorWindow.GetWindow(typeof(CreateWeapon));
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
        EditorGUILayout.LabelField("Luck");
        luck = EditorGUILayout.IntField(luck);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Experience");
        experience = EditorGUILayout.IntField(experience);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal(GUILayout.Width(350));
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Two Handed");
        twoHanded = EditorGUILayout.Toggle(twoHanded);
        EditorGUILayout.LabelField("Weapon Rank");
        rank = (WeaponRank)EditorGUILayout.EnumPopup(rank, GUILayout.Width(25));
        rankPoints = EditorGUILayout.IntField(rankPoints);

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Weapon Type");
        type = (WeaponType)EditorGUILayout.EnumPopup(type, GUILayout.Width(150));
        EditorGUILayout.LabelField("");
        usageType = (WeaponUsageType)EditorGUILayout.EnumMaskField(usageType, GUILayout.Width(100));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();


        if (name != null && name.Length > 0 && description != null && description.Length > 0 && image != null && GUILayout.Button("create"))
        {
          
            
                    string assetPathAndName =
           AssetDatabase.GenerateUniqueAssetPath("Assets/Weapons/" + name + ".asset");
                    Weapon weaponAsset = Weapon.ConstructScriptableObject(health, attack, defense, 
                        speed, magicAttack, magicDefense, magicPower, tensionPower, firstElement, 
                        secondElement, type, name, image, set, description, luck, rankPoints, twoHanded, usageType,
                        rank, experience);
                    AssetDatabase.CreateAsset(weaponAsset, assetPathAndName);
                  



           
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                Close();
          
        }
        EditorGUILayout.EndVertical();
    }

}
