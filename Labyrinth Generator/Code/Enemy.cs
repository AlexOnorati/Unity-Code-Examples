using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Author: Alex Onorati 2015
// Description: This object-oritend class is an basic enemy and a built in Chest object;
public class Enemy : Chest, LabyrinthObject {

	// Fields: basic stats of the enemy.
	public int health;
	public int attack;
	public int enemyId;

	// When the enemy is found by the player, a battle will start with a disclamer message.
	public override string ObjectIsFound(){
		LabyrinthManager.instance.StartBattle (this);
		return "A wild " + name + " appeared!";
	}

	// An override for the string class the display the enemies name and health.
	public override string ToString(){
		return "\n" + name + ": " + health;
	}

	// Displays the info of what the player has recieved through the battle.	
	new public virtual string GetItemText (string textInfo = ""){
		return base.GetItemText ("Victory! you recieved ");
	}
}