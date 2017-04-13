using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TOP;

public class ConstructionManager : Map {

	public static ConstructionManager instance;
	

	//Public varibles.
	public GameObject[] labyrinthObjects;
	public GameObject blockXAxis;
	public GameObject blockYAxis;
	public GameObject blockZAxis;
	public GameObject starterBlock;
	public GameObject goalPrefab;
	public GameObject wall;
	public GameObject room;
	
	private int[,,]map3D;
	private int faceId = -1;
	private int x = 0;
	private int z = 0;
	public int keys = 0;
	public int keysPlaced = 0;
	public System.Random ran;


	public const float lengthToWall = 40f;

	public static readonly int[] north = {4,10,2,0,8,6};
	public static readonly int[] east = {1,7,11,9,5,3};
	public static readonly int[] south = {7,9,1,3,11,5};
	public static readonly int[] west = {0,6,10,8,4,2};

	public static readonly int[] xDirection = {0,0,-1,1,0,0};
	public static readonly int[] yDirection = {0,-1,0,0,1,0};
	public static readonly int[] zDirection = {1,0,0,0,0,-1};
	public static readonly int[] nearWallSetOne = {0,2,5,3,4,5,1,0,3,1,2,4,3};
	public static readonly int[] nearWallSetTwo = {3,0,2,5,0,4,5,1,4,3,1,2,4};

	public static readonly int[] wallDistance = {1,-1,-1,1,0,0,0,0,1,1,-1,-1};

    public ConstructionManager() {}

	public void SetUpMainBlock(bool isUsingSeed, string seed, int width, int height, int length, float ratio, bool isLab, int keyAmount = 0){
		keys = keyAmount;
		isLabyrinthType = isLab;
		ran = new System.Random();
		int finalSeed = (int)Time.deltaTime;
		if (isUsingSeed) {
			finalSeed = seed.GetHashCode();
		}


		map3D = Generate.Maze(width, height, length, finalSeed, (double)ratio, labyrinthObjects != null ? labyrinthObjects.Length : 0);
	}

    public void SetUpMainBlock(bool isLab) {
        isLabyrinthType = isLab;
        map3D = new int[3, 3, 3];
        map3D[1, 1, 1] = 1;
    }


	public void BuildByMap(){
		if (map3D != null) {
			for (int x = 1; x < map3D.GetLength(0) -1; x++) {
				for (int z = 1; z < map3D.GetLength(1) -1; z++) {
					for (int y = 1; y < map3D.GetLength(2) -1; y++) {
						if(map3D[x,z,y] == 1){
							map3D[x,z,y] = -1;
							BuildByMap(x,z,y);
						}
					}
				}
			}
		}
	}

	public void BuildOnRoom(GameObject boss){
		GameObject finalRoom = FindAvailable ();
		GameObject addedRoom = Instantiate (room);
		GameObject objectThere = Instantiate(boss);
		objectThere.transform.SetParent (addedRoom.transform, false);
		addedRoom.GetComponent<LabyrinthBlock> ().objectThere = objectThere;
		addedRoom.GetComponent<LabyrinthBlock> ().objectThere.name = "Dragon";
		addedRoom.GetComponent<LabyrinthBlock> ().keyNeeded = ConstructionManager.instance.keysPlaced;
		addedRoom.transform.localPosition = finalRoom.GetComponent<LevelBlock> ().face [faceId].GetNewPosition (faceId);
		addedRoom.name = "room";
		float degree;
		if (faceId == 0) {
			degree = 0f;
		} else if (faceId == 5) {
			degree = 180f;
		} else if (faceId == 3) {
			degree = 90f;
		} else {
			degree = -90f;
		}
		addedRoom.transform.rotation = Quaternion.identity;
		addedRoom.transform.Rotate (new Vector3 (0f, degree, 0f));
		addedRoom.transform.SetParent (transform, false);
		AddBlock (addedRoom.transform.localPosition.ToString (), addedRoom);
		DestroyImmediate (finalRoom.GetComponent<LevelBlock> ().face [faceId].gameObject);
	}

	public void SetGoalsPoints(){
		for (int i = 0; i < 12; i++) {
			GameObject marker = FindAvailable ();
			if (marker != null) {
				GameObject goal = Instantiate (goalPrefab);
				goal.transform.SetParent (marker.transform, false);
				goal.transform.localPosition = Vector3.zero;
			}
		}
	}

	private GameObject FindAvailable(){
		bool roomIsFound = false;

		GameObject roomBlockLeft = null;
		GameObject roomBlockRight = null;
		
		for (int startX = x; startX < map3D.GetLength(0) && !roomIsFound; startX++) {
			for (int startZ = z; startZ < map3D.GetLength(0) && !roomIsFound; startZ++) {
				for (x = startX; x < map3D.GetLength(0)-startX && !roomIsFound; x++) {
					roomBlockLeft = GetBlock (x * lengthToWall, lengthToWall, z * lengthToWall);
					roomBlockRight = GetBlock (x * lengthToWall, lengthToWall, (map3D.GetLength (2) - startZ) * lengthToWall);
					if (roomBlockLeft != null && roomBlockLeft.GetComponent<LevelBlock> ().face [5] != null) {
						faceId = 5;
						roomIsFound = true;
					} else if (roomBlockLeft != null && roomBlockLeft.GetComponent<LevelBlock> ().face [0] != null) {
						faceId = 0;
						roomIsFound = true;
					}
				}
				x = startX;
				for (z = startZ; z < map3D.GetLength(2) - startZ && !roomIsFound; z++) {
					roomBlockLeft = GetBlock (x * lengthToWall, lengthToWall, z * lengthToWall);
					roomBlockRight = GetBlock ((map3D.GetLength (0) - startX) * lengthToWall, lengthToWall, z * lengthToWall);
					if (roomBlockLeft != null && roomBlockLeft.GetComponent<LevelBlock> ().face [2] != null) {
						faceId = 2;
						roomIsFound = true;
					} else if (roomBlockLeft != null && roomBlockLeft.GetComponent<LevelBlock> ().face [3] != null) {
						faceId = 3;
						roomIsFound = true;
					}
				}
				z = startZ;
			}
		}
		return roomBlockLeft != null ? roomBlockLeft : roomBlockRight;
	}


	public void AddOnWalls(){
		bool isAdding = true;
		for (int i = 0; i < transform.childCount; i++) {
			Vector3 position = transform.GetChild (i).localPosition;
			LevelBlock currentBlock = transform.GetChild (i).GetComponent<LevelBlock> ();
			bool[] blockNear = hasNeighbors (position);
			for (int w = 0; w < 12; w++) {
				if (((blockNear [nearWallSetOne[w]] && blockNear [nearWallSetTwo[w]]&&isAdding)|| !blockNear [nearWallSetOne[w]] && !blockNear [nearWallSetTwo[w]]) && currentBlock.walls [w] == null) {
					currentBlock.walls [w] = Instantiate (wall);
					currentBlock.walls [w].transform.localPosition = GetNewWallPosition (w);
					currentBlock.walls[w].transform.SetParent(currentBlock.transform, false);
					ScaleWall (currentBlock, w);
				} 
			}
            for (int f = 0; f < 6; f++)
            {
                currentBlock.LinkWalls(f);
            }

        }
        
    }
	private Vector3 GetNewWallPosition(int element){
		float x = .5f * NewIndex(element,wallDistance)* lengthToWall;
		float y = .5f *  NewIndex(GetIndexShift(element, 11, 4),wallDistance)* lengthToWall;
		float z = .5f *  NewIndex(GetIndexShift(element, 11, 8),wallDistance)* lengthToWall;
		return new Vector3 (x, y, z);
	}

	private void ScaleWall(LevelBlock currentBlock, int elementNum){
		if(elementNum < 4){
			currentBlock.walls[elementNum].transform.localScale = new Vector3(1f, lengthToWall + 1f, 1f);
		}else if(elementNum < 8){
			currentBlock.walls[elementNum].transform.localScale = new Vector3(lengthToWall + 1f, 1f, 1f);
		}else if(elementNum < 12){
			currentBlock.walls[elementNum].transform.localScale = new Vector3(1f, 1f, lengthToWall + 1f);
		}
	}

	private int NewIndex(int element, int[] determantes ){
		return determantes != null ? determantes [element] : -1;
	}
	
	private int GetIndexShift(int elementNum, int maximum, int shift ){
		if (elementNum + shift > maximum) {
			return elementNum - maximum + shift -1;
		} else {
			return elementNum + shift;
		}
	}

	private bool[] hasNeighbors(Vector3 position){
		bool[] blockNear = new bool[6];
		blockNear[0] = IsBlockThere((position + new Vector3(0f,0f,1f) * lengthToWall).ToString());
		blockNear[1] = IsBlockThere((position + new Vector3(0f,-1f,0f) * lengthToWall).ToString());
		blockNear[2] = IsBlockThere((position + new Vector3(-1f,0f,0f) * lengthToWall).ToString());
		blockNear[3] = IsBlockThere((position + new Vector3(1f,0f,0f) * lengthToWall).ToString());
		blockNear[4] = IsBlockThere((position + new Vector3(0f,1f,0f) * lengthToWall).ToString());
		blockNear[5] = IsBlockThere((position + new Vector3(0f,0f,-1f) * lengthToWall).ToString());
		return blockNear;
	}

	private void BuildByMap(int x, int z, int y){
		GameObject addedBlock = Instantiate (starterBlock);
		addedBlock.transform.SetParent (transform, false);
		addedBlock.transform.localPosition = new Vector3 (x * lengthToWall, z * lengthToWall, y * lengthToWall);
		if (isLabyrinthType) {
			addedBlock.AddComponent<LabyrinthBlock> ();
		}
		blocks = new Dictionary<string, GameObject> ();
		blocks.Add (addedBlock.transform.localPosition.ToString(), addedBlock);
		BuildBlockBy (addedBlock.GetComponent<LevelBlock>(), x, z, y);
	}

	private void BuildByMapQuick(){
		LevelBlock block = null;
		int[] mapX = Generate.mapX;
		int[] mapZ = Generate.mapZ;
		int[] mapY = Generate.mapX;
		bool isStarterBlock = false;
		blocks = new Dictionary<string, GameObject> ();
		for (int x = 1; x < map3D.GetLength(0) -1; x++) {
			for (int z = 1; z < map3D.GetLength(1) -1; z++) {
				for (int y = 1; y < map3D.GetLength(2) -1; y++) {
					if(!isStarterBlock){
						isStarterBlock = true;
						block = Instantiate (starterBlock).GetComponent<LevelBlock>();
						block.transform.SetParent (transform, false);
						block.transform.localPosition = new Vector3 (x * lengthToWall, z * lengthToWall, y * lengthToWall);
						blocks.Add (block.transform.localPosition.ToString(), block.gameObject);
					}
					for (int v = 0; v < 6; v++) {
						int newX = x +  mapX[v];
						int newZ = z + mapZ[v];
						int newY = y + mapY[v];
						if(block != null && Generate.IsNotAnEnd(map3D, newX, newZ, newY) && map3D[newX, newZ, newY] > 0){
							FaceCollider face = block.face[Generate.blockRef[v]];
                            if (map3D[newX, newZ, newY] > 1)
                            {
                                face.AddOnBlock(map3D[newX, newZ, newY]);
                            }
                            else {
                                face.AddOnBlock();
                            }
							map3D[newX, newZ, newY] = -1;
							block = face.block.GetComponent<LevelBlock>();
						}
					}
				}
			}
		}
	}

	private void BuildBlockBy(LevelBlock block, int x, int z, int y){
		if ( x - 1 != 0 && map3D [x - 1, z, y] > 0 ){

			FaceCollider face = block.face[2];
			face.AddOnBlock(map3D[x-1,z,y]);
			map3D[x-1,z,y] = -1;
			BuildBlockBy(face.block.GetComponent<LevelBlock>(), x - 1, z, y);
		}
		if (x + 1 != map3D.GetLength(0) - 1 && map3D [x + 1, z, y] > 0) {
			FaceCollider face = block.face[3];
			face.AddOnBlock(map3D[x+1,z,y]);
			map3D[x+1,z,y] = -1;
			BuildBlockBy(face.block.GetComponent<LevelBlock>(), x + 1, z, y);
		}
		if (z - 1 != 0 && map3D [x, z - 1, y] > 0) {
			FaceCollider face = block.face[1];
			face.AddOnBlock(map3D[x,z-1,y]);
			map3D[x,z-1,y] = -1;
			BuildBlockBy(face.block.GetComponent<LevelBlock>(), x, z - 1, y);
		}
		if (z + 1 != map3D.GetLength (1) - 1 && map3D [x, z + 1, y] > 0) {
			FaceCollider face = block.face[4];
			face.AddOnBlock(map3D[x,z+1,y]);
			map3D[x,z+1,y] = -1;
			BuildBlockBy(face.block.GetComponent<LevelBlock>(), x, z + 1, y);
		}
		if (y - 1 != 0 &&map3D [x, z, y - 1] > 0) {
			FaceCollider face = block.face[5];
			face.AddOnBlock(map3D[x,z,y-1]);
			map3D[x,z,y-1] = -1;
			BuildBlockBy(face.block.GetComponent<LevelBlock>(), x, z, y - 1);
		}
		if (y + 1 != map3D.GetLength(2) - 1 && map3D [x, z, y + 1] > 0) {
			FaceCollider face = block.face[0];
			face.AddOnBlock(map3D[x,z,y+1]);
			map3D[x,z,y+1] = -1;
			BuildBlockBy(face.block.GetComponent<LevelBlock>(), x, z, y + 1);
		}
	}

	//Saves the desired set up of the map.
	public GameObject SaveSetUp(){
		GameObject map = new GameObject ();
		map.AddComponent<Map>();
		map.name = "Map";
		map.GetComponent<Map> ().SetMap (isLabyrinthType);
		map.transform.localPosition = transform.localPosition;
        if (!isLabyrinthType) {
            AddOnWalls();
        }
		int childNumber = transform.childCount;
		for (int i = 0; i < childNumber; i++) {
			if(!isLabyrinthType){
                
                transform.GetChild (0).GetComponent<LevelBlock>().HideFace(new int[]{0,1,2,3,4,5});
			}
			transform.GetChild(0).SetParent(map.transform, false);
		}
		return map;
	}

	
}