using UnityEngine;
using System.Collections;

public interface LabyrinthObject {
	bool HasKey();
	void SetHasKey();
	string ObjectIsFound();
	void ObjectIsLost();
}
