using UnityEngine;
using System.Collections;

// Author: Alex Onorati 2015
// Description: Adds components to keep track of extra chariteristics for the game world Fathomless Labyrinth in A Tale of Pixels.
public class LabyrinthBlock : MonoBehaviour {

	// Fields: chariteristics about what the object is.
	public GameObject objectThere;
	public int keyNeeded = 0;
	public bool isBoss;

	// Checks what is going on in that room
	public void CheckRoom(){
		// If there is an object there trigger objects Object is found overwise do nothing but rest the text.
		if (objectThere != null) {
			LabyrinthManager.instance.infoText.text = objectThere.GetComponent<LabyrinthObject>().ObjectIsFound();
		} else {
			LabyrinthManager.instance.infoText.text = "";
		}
	}

	// Destroys the object there unless it is an enemy.
	public void LeavingRoom(){
		if (objectThere != null && objectThere.GetComponent<Enemy>() == null) {
			objectThere.GetComponent<LabyrinthObject>().ObjectIsLost();
		}
	}
}
