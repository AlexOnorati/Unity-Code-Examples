using System;
using System.Reflection;
using UnityEngine;

public class LevelBlock : MonoBehaviour {

	public GameObject[] walls;
	public FaceCollider[] face;

	public void RemoveBlock(){
		Debug.Log ("Remove dat block!");
	}

	public void RemoveFace(int faceId){
		GameObject wallToRemove = walls [ConstructionManager.north [faceId]];
		if (wallToRemove != null) {
			DestroyImmediate(wallToRemove);
		}
		wallToRemove = walls [ConstructionManager.east [faceId]];
		if (wallToRemove != null) {
			DestroyImmediate(wallToRemove);
		}
		wallToRemove = walls [ConstructionManager.south [faceId]];
		if (wallToRemove != null) {
			DestroyImmediate(wallToRemove);
		}
		wallToRemove = walls [ConstructionManager.west [faceId]];
		if (wallToRemove != null) {
			DestroyImmediate(wallToRemove);
		}
		if (face [faceId] != null) {
			DestroyImmediate (face [faceId].gameObject);
		}
	}

	public void HideFace(int[] faces){
		for (int i = 0; i < faces.Length; i++) {
			if(face[faces[i]] != null){
				face[faces[i]].GetComponent<MeshRenderer>().enabled = false;
			}
		}
	}

    public void LinkWalls(int faceId) {
        FaceCollider faceObject = face[faceId];
        ColliderMesh faceMesh = null;
        if (faceObject != null) {
            faceMesh = faceObject.GetComponent<ColliderMesh>();
        }

        MeshRenderer[] colliders = new MeshRenderer[4];

        GameObject wallToLink = walls[ConstructionManager.north[faceId]];
        if (wallToLink != null)
        {
            colliders[0] = wallToLink.GetComponent<MeshRenderer>();
        }
        wallToLink = walls[ConstructionManager.east[faceId]];
        if (wallToLink != null)
        {
            colliders[1] = wallToLink.GetComponent<MeshRenderer>();
        }
        wallToLink = walls[ConstructionManager.south[faceId]];
        if (wallToLink != null)
        {
            colliders[2] = wallToLink.GetComponent<MeshRenderer>();
        }
        wallToLink = walls[ConstructionManager.west[faceId]];
        if (wallToLink != null)
        {
            colliders[3] = wallToLink.GetComponent<MeshRenderer>();
        }
        if (faceMesh != null)
        {
            faceMesh.meshes = colliders;
        }
     
    } 

	//Sets all objects to the proper block location.
	public void SetAsPlayerStart(){
		Transform[] player = transform.parent.GetComponent<Map>().GetPlayerTransform();
		for (int i = 0; i < player.Length; i++) {
			if(player[i].name == "Paddle"){
				player[i].localPosition = new Vector3(transform.localPosition.x - 5f, transform.localPosition.y, transform.localPosition.z);
			}else{
				player[i].localPosition = transform.localPosition;
			}
		}
	}
}
