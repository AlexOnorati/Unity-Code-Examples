using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(FaceCollider))]
public class FaceColliderEditor : Editor {

    

	public override void OnInspectorGUI(){
		DrawDefaultInspector ();
		FaceCollider faceColliderReference = (FaceCollider)target;
        bool isExtendable = true;
        if (ConstructionManager.instance != null && ConstructionManager.instance.IsLabyrinth())
        {
            isExtendable = faceColliderReference.faceId != 1 && faceColliderReference.faceId != 4;
        }
            if (FaceCollider.inBuild && isExtendable && GUILayout.Button("Add Block"))
            {
                faceColliderReference.AddOnBlock();
            }
        
	}
}
