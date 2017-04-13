using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Author: Alex Onorati 2015
// Discription: This object-oriented class is used to hold items in the game world of Fathomless Labrinth in the Game A Tale Of Pixels.
public class Chest : MonoBehaviour , LabyrinthObject {
	// Fields (The number of what the chest contains).
	public int potion;
	public int gold;
	public int key;

	// Checks to see if the chest has any keys.
	public bool HasKey(){
		return key > 0;
	}

	// Adds a key to the chest. 
	public void SetHasKey(){
		key++;
	}

	// When the object is found, adds the contents to the players inventory, and displays a message.
	public virtual string ObjectIsFound(){
		LabyrinthManager.instance.AddToGold (gold);
		LabyrinthManager.instance.AddToInventory (potion);
		LabyrinthManager.instance.AddToKeyCount(key);
		LabyrinthManager.instance.objectImage [0].SetActive (true);
		return GetItemText ("You found a chest! You received ");
	}

	// When the object is lost, destroys the gameObject.
	public virtual void ObjectIsLost(){
		LabyrinthManager.instance.objectImage [0].SetActive (false);
		Destroy (gameObject);
	}

	// Gets a string text to be returned for display.
	public string GetItemText (string textInfo = "")
	{
		if (gold > 0) {
			textInfo += gold + " gold";
		}
		if (potion > 0) {
			textInfo += (gold > 0  ? (key > 0) ? ", ": " and " : "") +  potion + " potion" + (potion > 1 ? "s" : ""); 
		}
		if (key > 0){
			textInfo += ((potion > 0 || gold > 0 )? " and" : "")+ " a key";  
		}
		return textInfo + ".";
	}
}
