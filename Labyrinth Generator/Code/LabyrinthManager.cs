using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// Author: Alex Onorati 2015
// Description this class is to aid with the maintaining and creating levels in the world Fathomless Labyrinth.
public class LabyrinthManager : MonoBehaviour {

	// Static instance of this class.
	public static LabyrinthManager instance;

	// Reference to the Construction Manager.
	public ConstructionManager refConMan;


	public float distanceToNextPoint = 40f;
	public Text infoText;
	public Text statText;
	public GameObject gameOverPanel;
	public GameObject gameWonPanel;
	public SelectionPanel selPan;
	public float currentRotation = 0f;
	public Camera player;
	private Map map;
	public GameObject[] objectImage;

	[Range(1,100)]
	public int width;
	[Range(1,100)]
	public int length;
	[Range(0.5f,.9f)]
	public float ratio;
	public string seed;
	[Range(0,6)]
	public int variance;
	[Range(1,5)]
	public int keys;
	public bool isUsingSeed;
	public bool showBlocks;
	public bool showConections;
    public bool loadOnPlay;
	
	private int health = 50;
	private int gold = 0;
	private int attack = 5;
	private int potionCount = 0;
	private int keysObtained = 0;

	private bool isTurning;
	private bool isMoving;
	private GameObject newBlock;
	private Enemy currentEnemy;

	private LabyrinthBlock currentBlock;

	//Run on start;
	public void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		} else {
			instance = this;
		}
        if (loadOnPlay)
        {
            SetUpMainBlock();
            BuildByMap();
            SaveSetUp();
        }

        map = transform.GetChild (transform.childCount - 1).gameObject.GetComponent<Map>();
        SetStartingPlace();
        ChangeButtons ();
		RewriteStatText ();
	}

	public void SetUpMainBlock(){
		if (ConstructionManager.instance != null) {
			DestroyImmediate(ConstructionManager.instance.gameObject);
		}
		ConstructionManager.instance = Instantiate (refConMan).GetComponent<ConstructionManager>();
		//ConstructionManager.instance.SetUpMainBlock (isUsingSeed, seed, width, 1, length, ratio, variance, showBlocks, showConections, true, keys);
	}

	public void BuildByMap(){
		ConstructionManager.instance.BuildByMap ();
		//ConstructionManager.instance.BuildOnRoom ();

	}

	public void SaveSetUp(){
		GameObject mapObject;
		mapObject = ConstructionManager.instance.SaveSetUp ();
		mapObject.transform.SetParent (transform, false);
		mapObject.GetComponent<Map> ().SetPlayerTranform (Camera.main.transform);

		DestroyImmediate (ConstructionManager.instance.gameObject);
	}

	private void RewriteStatText(string enemyStats = ""){
		statText.text = "Gold: " + gold + "\t\t" + "Keys: " + keysObtained +"\n" + "Health: " + health + "\t\t" + "Potions: " + potionCount + enemyStats;
		if (health <= 0) {
			EndGame(false);
		}
	}

	public void StartBattle(Enemy enemy){
		selPan.SetBattleSelection ();
		currentEnemy = enemy;
		objectImage [currentEnemy.enemyId].SetActive (true);
		if (potionCount == 0) {
			selPan.buttons[5].SetActive(false);
		}
		if (currentBlock != null && currentBlock.GetComponent<LabyrinthBlock> ().isBoss) {
			selPan.buttons[6].SetActive(false);
		}
		RewriteStatText (currentEnemy.ToString ());
	}

	private void EndGame(bool won){
		gameOverPanel.SetActive(!won);
		gameWonPanel.SetActive(won);

	}
	public void AddToInventory(int numOfItem){
		potionCount += numOfItem;
		RewriteStatText ();
	}

	public void AddToGold(int goldIncrease){
		gold += goldIncrease;
		RewriteStatText ();
	}

	public void AddToKeyCount(int key){
		keysObtained += key;
		RewriteStatText ();
	}

	public void MoveForward(){
		MoveBy (0f);
	}

	public void MoveLeft(){
		MoveBy (-90f);
	}

	public void MoveRight(){
		MoveBy (90f);
	}

	public void MoveBackward(){
		MoveBy (180f);
	}

	private void EnemyAttack(){
		health -= currentEnemy.attack;
		RewriteStatText (currentEnemy.ToString ());
	}

	public void Attack(){
		if (currentEnemy != null) {
			currentEnemy.health -= attack;
			infoText.text = "You delt " + attack + " damage.";
			RewriteStatText (currentEnemy.ToString ());
			if (currentEnemy.health > 0) {
				EnemyAttack ();
			} else {
				gold += currentEnemy.gold;
				potionCount += currentEnemy.potion;
				keysObtained += currentEnemy.HasKey () ? 1 : 0;
				RewriteStatText ();
				infoText.text = currentEnemy.GetItemText ();
				objectImage[currentEnemy.enemyId].SetActive (false);
				currentEnemy.ObjectIsLost ();
				selPan.SetExplorerSelection ();
				ChangeButtons();
				if(currentBlock.GetComponent<LabyrinthBlock>().isBoss){
					EndGame(true);
				}
			}
		}
	}

	public void UsePotion(){
		if (potionCount > 0) {
			health += 15;
			potionCount--;
			if (potionCount == 0) {
				selPan.buttons[5].SetActive(false);
                selPan.FindCurrent();
			}
			RewriteStatText ();
			EnemyAttack ();
		}
	}

	public void Run(){
		System.Random ran = new System.Random ((int)Time.deltaTime);
		if (ran.NextDouble () < .6) {
			infoText.text = "You got away!";
			RewriteStatText();
			selPan.SetExplorerSelection();
			MoveForward(180f);
			objectImage [currentEnemy.enemyId].SetActive (false);
		} else {
			infoText.text = "Couldn't flee!";
			EnemyAttack();
		}
	}

	void MoveBy(float changeInDegree){
		if (map != null) {
			newBlock = map.GetBlock (GetPositionDirection (currentRotation + changeInDegree).ToString ());
            newBlock.gameObject.SetActive(true);
			if (newBlock != null && newBlock.GetComponent<LabyrinthBlock>().keyNeeded == 0) {
				MoveForward (changeInDegree);
				if(newBlock.GetComponent<LabyrinthBlock>().isBoss){
					MoveForward(0f);
					selPan.buttons [6].SetActive (false);
				}
				if (currentBlock != null) {
					currentBlock.LeavingRoom ();
				}
				currentBlock = newBlock.GetComponent<LabyrinthBlock> ();
				currentBlock.CheckRoom ();
			}else{
				if (keysObtained != 0){
					newBlock.GetComponent<LabyrinthBlock>().keyNeeded--;
					keysObtained--;
				}
				if(newBlock.GetComponent<LabyrinthBlock>().keyNeeded == 0){
					infoText.text = "The door is now unlocked.";
				}else{
					infoText.text = "You need " + newBlock.GetComponent<LabyrinthBlock>().keyNeeded + " more keys to enter this room.";
				}
				RewriteStatText();
			}
		}
	}
	
	private Vector3 GetRotationDirection(float degree){
		return new Vector3 (Mathf.Round (Mathf.Sin (Mathf.PI * degree / 180f)), 0f, Mathf.Round (Mathf.Cos (Mathf.PI * degree / 180f)));
	}

	private Vector3 GetPositionDirection(float degree){
		Vector3 currentPosition = player.transform.localPosition;
		return currentPosition + GetRotationDirection (degree) * distanceToNextPoint;
	}

	private void MoveForward(float degree){
		currentRotation += degree;
		player.transform.localPosition = GetPositionDirection(currentRotation) ;
		player.transform.Rotate(new Vector3 (0f, degree, 0f));
		ChangeButtons ();
	}

	IEnumerator MoveForwarda(float degree){
		float finalRotation = currentRotation + degree;
		Vector3 newPosition = GetPositionDirection (finalRotation);
		while (finalRotation - currentRotation > 0f) {
			transform.Rotate(new Vector3(0f, currentRotation, 0f));
			currentRotation += Mathf.Sign (degree);
			yield return new WaitForSeconds(.25f);
		}
		yield return new WaitForSeconds (1f);
		while (Vector3.Distance(transform.localPosition, newPosition) > 0.05f) {
			transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, 1f * Time.deltaTime );
		}
		transform.localPosition = newPosition;
	}

	private void ChangeButtons(){
        float[] directionAngle = { 0f, -90f, 90f, 180f };
        for (int i = 0; i < directionAngle.Length; i++)
        {
            if (map.IsBlockThere(GetPositionDirection(currentRotation + directionAngle[i]).ToString())) { 
                map.GetBlock(GetPositionDirection(currentRotation + directionAngle[i]).ToString()).SetActive(true);
            }
           
            selPan.buttons[i].SetActive(map.IsBlockThere(GetPositionDirection(currentRotation + directionAngle[i]).ToString()));
        }

		
        selPan.FindCurrent();
	}

    private void SetStartingPlace() {
        map.GetBlock(player.transform.localPosition.ToString()).SetActive(true);
    }
}