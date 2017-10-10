using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class Equipment : MonoBehaviour {

    [SerializeField]//, HideInInspector]
    public Head head;
    [SerializeField]//, HideInInspector]
    public Arm leftArm;
    [SerializeField]//, HideInInspector]
    public Weapon leftHand;
    [SerializeField]//, HideInInspector]
    public Chest chest;
    [SerializeField]//, HideInInspector]
    public Arm rightArm;
    [SerializeField]//, HideInInspector]
    public Weapon rightHand;
    [SerializeField]//, HideInInspector]
    public Leg legs;
    [SerializeField]//, HideInInspector]
    public Boot boots;
    [SerializeField]//, HideInInspector]
    public BaseStat finalStats;

    public void setStats() {
        finalStats = BaseStat.CombineStats(head, leftArm, leftArm, leftHand, chest, rightArm, rightHand, legs, boots);
    }
}