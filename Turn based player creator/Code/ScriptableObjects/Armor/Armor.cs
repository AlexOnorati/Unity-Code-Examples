using UnityEngine;

[System.Serializable]
public class Armor : BaseStat
{
    public ElementType firstElement;
    public ElementType secondElement;
    public int set;

    public void Init(int setHealth, int setAttack, int setDefense, int setSpeed, 
        int setMagicAttack, int setMagicDefense, int setMagicPower, int setTensionPower, 
        ElementType setFirstElement, ElementType setSecondElement, string setName, Texture setImage, int setSet, string setDescription, int setLuck, int setExperience)
    {
        base.Init(setHealth, setAttack, setDefense, setSpeed,
        setMagicAttack, setMagicDefense, setMagicPower, setTensionPower,
        setName, setImage, setLuck, setDescription, setExperience);
        firstElement = setFirstElement;
        secondElement = setSecondElement;
        set = setSet;
    }
        public static Armor ConstructScriptableObject(int setHealth, int setAttack, int setDefense, int setSpeed,
        int setMagicAttack, int setMagicDefense, int setMagicPower, int setTensionPower,
        ElementType setFirstElement, ElementType setSecondElement, ArmorType setType, string setName, Texture setImage,
        int setSet, string setDescription, int setLuck, int setExperience) {
        Armor instance = ScriptableObject.CreateInstance(typeof(Armor)) as Armor;
        instance.Init(setHealth, setAttack, setDefense, setSpeed,
        setMagicAttack, setMagicDefense, setMagicPower, setTensionPower,
        setFirstElement, setSecondElement, setName, setImage,
        setSet, setDescription, setLuck, setExperience);
        return instance;
    }
}