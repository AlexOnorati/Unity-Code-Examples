using UnityEngine;

[System.Serializable]
public class Item : BaseStat {
    public UsageType type;

    public void Init(int setHealth, int setAttack, int setDefense, int setSpeed,
        int setMagicAttack, int setMagicDefense, int setMagicPower, int setTensionPower,
        UsageType setType, string setName, Texture setImage, string setDescription)
    {
        health = setHealth;
        attack = setAttack;
        defense = setDefense;
        speed = setSpeed;
        magicAttack = setAttack;
        magicDefense = setDefense;
        magicPower = setMagicPower;
        tensionPower = setTensionPower;
        type = setType;
        name = setName;
        image = setImage;
        description = setDescription;
    }
    public static Item ConstructScriptableObject(
    int setHealth, int setAttack, int setDefense, 
    int setSpeed, int setMagicAttack, int setMagicDefense, 
    int setMagicPower, int setTensionPower, UsageType setType, 
    string setName, Texture setImage, string setDescription)
    {
        Item instance = ScriptableObject.CreateInstance(typeof(Item)) as Item;
        instance.Init(setHealth, setAttack, setDefense, setSpeed,
        setMagicAttack, setMagicDefense, setMagicPower, setTensionPower,
        setType, setName, setImage,
        setDescription);
        return instance;
    }
}