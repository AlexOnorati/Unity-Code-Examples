using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public ElementType firstElement;
    public ElementType secondElement;
    public BaseStat baseStats;
    private Drops drops;

    void Awake() {
        drops = GetComponent<Drops>();
    }

    public void GetItems() {
        drops.GiveItems();
    }
}
