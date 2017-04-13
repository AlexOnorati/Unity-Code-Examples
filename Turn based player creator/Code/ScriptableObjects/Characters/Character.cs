using UnityEngine;
using System.Collections;
using UnityEditor;

public class Character : MonoBehaviour {
    public static int saveFile = 1;
    public string nickname;
    public ElementType firstElement;
    public ElementType secondElement;
    public BaseStat baseStats;
    public BaseStat increasedStats;
    public BaseStat finalStats;
    public int experince;
    public int Level {
        get {
            if (experince == 0 || increasedStats == null) {
                return 1;
            } else if ((int)(increasedStats.experience / experince) + 1 > BattleManager.maxLevel) {
                return BattleManager.maxLevel;
            }
            return (int)(increasedStats.experience / experince) + 1 ;
        }
    }

    public StatRank[] statRanks = new StatRank[3];

    public void Awake() {
       
            
            string assetPathAndName = "Assets/ScriptableObject/Characters/IncreasedStats/" + baseStats.name + "instance"+saveFile+".asset";
            increasedStats = AssetDatabase.LoadAssetAtPath(assetPathAndName, typeof(BaseStat)) as BaseStat;
            if (increasedStats == null) {
                increasedStats = BaseStat.ConstructScriptableObject();
                increasedStats.name = baseStats.name + "instance" + saveFile;
                AssetDatabase.CreateAsset(increasedStats, assetPathAndName);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }

        
    }

    public void setStats()
    {
        BaseStat stats = BaseStat.ConstructScriptableObject();
        Equipment equipment = GetComponent<Equipment>(); ;
        if (equipment != null) {
            equipment.setStats();
            stats = equipment.finalStats;
        }
        finalStats = BaseStat.CombineStats(baseStats, stats);
        finalStats.name = baseStats.name;
        finalStats.description = baseStats.description;
        finalStats.image = baseStats.image;
    }
}