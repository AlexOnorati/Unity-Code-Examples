using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon : Armor
{
    public WeaponRank rank;
    public WeaponType weaponType;
    public WeaponUsageType usageType;
    public bool twoHanded;
    public int rankPoints;

    public void Init(int setHealth, int setAttack, int setDefense, int setSpeed,
       int setMagicAttack, int setMagicDefense, int setMagicPower, int setTensionPower,
       ElementType setFirstElement, ElementType setSecondElement, string setName, Texture setImage, 
       int setSet, string setDescription, int setLuck, WeaponType setType, int setRankPoints, bool setTwoHanded, WeaponUsageType setUsageType, int setExperience)
    {
        base.Init(setHealth, setAttack, setDefense, setSpeed,
        setMagicAttack, setMagicDefense, setMagicPower, setTensionPower,
        setFirstElement, setSecondElement, setName, setImage, setSet, setDescription, setLuck, setExperience);
    }

    public static Weapon ConstructScriptableObject(int setHealth, int setAttack, int setDefense, int setSpeed,
        int setMagicAttack, int setMagicDefense, int setMagicPower, int setTensionPower,
        ElementType setFirstElement, ElementType setSecondElement, WeaponType setType, string setName, Texture setImage,
        int setSet, string setDescription, int setLuck, int setRankPoints, bool setTwoHanded, WeaponUsageType setUsageType, WeaponRank setRank, int setExperience)
    {
        Weapon instance = ScriptableObject.CreateInstance(typeof(Weapon)) as Weapon;
        instance.Init(setHealth, setAttack, setDefense, setSpeed,
        setMagicAttack, setMagicDefense, setMagicPower, setTensionPower,
        setFirstElement, setSecondElement, setName, setImage,
        setSet, setDescription, setLuck, setType, setRankPoints, setTwoHanded, setUsageType, setExperience);
        return instance;
    }
}
