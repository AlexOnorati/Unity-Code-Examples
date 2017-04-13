using UnityEngine;
using System.Collections;

[System.Serializable]
public class Head : Armor
{
    public static Head ConstructScriptableObject(int setHealth, int setAttack, int setDefense, int setSpeed,
            int setMagicAttack, int setMagicDefense, int setMagicPower, int setTensionPower,
            ElementType setFirstElement, ElementType setSecondElement, string setName, Texture setImage,
            int setSet, string setDescription, int setLuck, int setExperience)
    {
        Head instance = ScriptableObject.CreateInstance(typeof(Head)) as Head;
        instance.Init(setHealth, setAttack, setDefense, setSpeed,
        setMagicAttack, setMagicDefense, setMagicPower, setTensionPower,
        setFirstElement, setSecondElement, setName, setImage, setSet, setDescription, setLuck, setExperience);
        return instance;
    }
}