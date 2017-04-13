using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {
    
    protected Dictionary<string, GameObject> blocks;
	protected bool isLabyrinthType;
	protected Transform[] player;
    public bool hideMap;

	public Transform[] GetPlayerTransform(){
		return player;
	}

	public void SetPlayerTranform(params Transform[] playTran){
		player = playTran;
	}


	public void SetMap(bool type = false){
		isLabyrinthType = type;
	}

	public bool IsLabyrinth(){
		return isLabyrinthType;
	}
	void Awake(){

        blocks = new Dictionary<string, GameObject> ();
		for (int i = 0; i < transform.childCount; i++) {
			Transform child = transform.GetChild (i);
			AddBlock (child.localPosition.ToString (), child.gameObject);
            if (hideMap)
            {
                child.gameObject.SetActive(false);
            }
		}
	}


	public bool IsBlockThere(string location){
		GameObject temp = null;
		return  blocks.TryGetValue (location, out temp);
	}
	
	public bool IsBlockThere(float x, float y, float z){
		return IsBlockThere ((new Vector3(x,y,z)).ToString());
	}
	
	public GameObject GetBlock(string location){
		return IsBlockThere (location) ? blocks [location] : null;
		
	}
	
	public GameObject GetBlock(float x, float y, float z){
		return GetBlock ((new Vector3(x,y,z)).ToString());
	}
	
	public void AddBlock(string location, GameObject block){
		blocks.Add (location, block);
	}

   
}
