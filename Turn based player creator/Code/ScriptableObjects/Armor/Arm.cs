using UnityEngine;
using System.Collections;

[System.Serializable]
public class Arm : Armor
{
    public static Arm ConstructScriptableObject(int setHealth, int setAttack, int setDefense, int setSpeed,
       int setMagicAttack, int setMagicDefense, int setMagicPower, int setTensionPower,
       ElementType setFirstElement, ElementType setSecondElement, string setName, Texture setImage,
       int setSet, string setDescription, int setLuck, int setExperience)
    {
        Arm instance = ScriptableObject.CreateInstance(typeof(Arm)) as Arm;
        instance.Init(setHealth, setAttack, setDefense, setSpeed,
        setMagicAttack, setMagicDefense, setMagicPower, setTensionPower,
        setFirstElement, setSecondElement, setName, setImage, setSet, setDescription, setLuck, setExperience);
        return instance;
    }
}
