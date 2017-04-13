using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseStat : ScriptableObject
{
    public new string name;
    public string description;
    public int health;
    public int attack;
    public int defense;
    public int speed;
    public int magicAttack;
    public int magicDefense;
    public int magicPower;
    public int tensionPower;
    public int luck;
    public int experience;
    public Texture image;

    public void Init(int setHealth, int setAttack, int setDefense, int setSpeed,
        int setMagicAttack, int setMagicDefense, int setMagicPower, int setTensionPower,
        string setName, Texture setImage, int setLuck, string setDescription, int setExperience)
    {
        health = setHealth;
        attack = setAttack;
        defense = setDefense;
        speed = setSpeed;
        magicAttack = setMagicAttack;
        magicDefense = setMagicDefense;
        magicPower = setMagicPower;
        tensionPower = setTensionPower;
        name = setName;
        image = setImage;
        description = setDescription;
        luck = setLuck;
        experience = setExperience;
    }
    public static BaseStat ConstructScriptableObject(
    int setHealth, int setAttack, int setDefense,
    int setSpeed, int setMagicAttack, int setMagicDefense,
    int setMagicPower, int setTensionPower,
    string setName, Texture setImage, int setLuck, string setDescription, int setExperience)
    {
        BaseStat instance = ScriptableObject.CreateInstance(typeof(BaseStat)) as BaseStat;
        instance.Init(setHealth, setAttack, setDefense, setSpeed,
        setMagicAttack, setMagicDefense, setMagicPower, setTensionPower,
        setName, setImage, setLuck, setDescription, setExperience);
        return instance;
    }

    public static BaseStat ConstructScriptableObject() {
        return ScriptableObject.CreateInstance(typeof(BaseStat)) as BaseStat;
    }

    public static BaseStat CombineStats(params BaseStat[] baseStats) {
        BaseStat finalStat = BaseStat.ConstructScriptableObject();
        for (int i = 0; i < baseStats.Length; i++) {
            if (baseStats[i] != null)
            {
                finalStat.attack += baseStats[i].attack;
                finalStat.defense += baseStats[i].defense;
                finalStat.health += baseStats[i].health;
                finalStat.magicAttack += baseStats[i].magicAttack;
                finalStat.magicDefense += baseStats[i].magicDefense;
                finalStat.magicPower += baseStats[i].magicPower;
                finalStat.tensionPower += baseStats[i].tensionPower;
                finalStat.luck += baseStats[i].luck;
                finalStat.speed += baseStats[i].speed;
                finalStat.experience += baseStats[i].experience;
            }
        }
       
        return finalStat;
    }
}