using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectionPanel : MonoBehaviour {

    public GameObject[] buttons;

    public int split;

    private int currentPosition = 0;
    private int currentAnalogPosition = 0;
    private bool isPressed = false;
    public bool isComputerBuild = false;

    public void SetExplorerSelection() {
        SetActive(true);

    }

    public void SetBattleSelection() {
        SetActive(false);

    }

    private void SetActive(bool active) {
        for (int i = 0; i < split; i++) {
            buttons[i].SetActive(active);
        }
        for (int i = split; i < buttons.Length; i++) {
            buttons[i].SetActive(!active);
   
        }
        FindCurrent();

    }

    public void FindCurrent() {
        bool isFound = false;
        for (int i = 0; i < buttons.Length; i++) {
            if (buttons[i].activeSelf && !isFound) {
                currentPosition = i;
                isFound = true;
            }
        }
        SetCursor();
    }
    

    public void SetCursor()
    {
        int index = currentPosition;
        for (int i = 0; i < buttons.Length; i++)
        {
            int childCount = buttons[i].transform.childCount;
            for (int j = 0; j < childCount; j++)
            {
                if (buttons[i].transform.GetChild(j).tag == "Cursor")
                {
                    buttons[i].transform.GetChild(j).gameObject.SetActive(false);
                }
            }
        }

        int childCountCheck = buttons[index].transform.childCount;
        for (int j = 0; j < childCountCheck; j++)
        {
            if (buttons[index].transform.GetChild(j).tag == "Cursor")
            {
                buttons[index].transform.GetChild(j).gameObject.SetActive(true);
            }
        }
    }
                
    

    private void MoveCursor(int index) {
        currentPosition = index;
        SetCursor();
    }

    public void FixedUpdate() {
    
        int hor = (int)Input.GetAxisRaw(isComputerBuild ? "Horizontal" : "LeftAngHor");
 
        bool isSet = false;
        if (hor > 0 && hor != currentAnalogPosition) {
            currentAnalogPosition = hor;
            for (int i = currentPosition + 1; i < buttons.Length; i++) {
                if (!isSet && buttons[i].activeSelf) {
                    MoveCursor(i);
                    isSet = true;
                }
            }
        }
        else if (hor < 0 && hor != currentAnalogPosition) {
            currentAnalogPosition = hor;
            for (int i = currentPosition - 1; i >= 0; i--)
            {
                if (!isSet && buttons[i].activeSelf)
                {
                    MoveCursor(i);
                    isSet = true;
                }
            }
        }
        if (hor == 0) {
            currentAnalogPosition = 0;
        }

        if (Input.GetButton("a") && !isPressed){
            isPressed = true;
            buttons[currentPosition].GetComponent<Button>().onClick.Invoke();
            SetCursor();
        }
        else if (!Input.GetButton("a")) {
            isPressed = false;
        }

        if (Input.GetButton("x")) {
            SceneManager.LoadScene("FathomlessLabrith");
        }
        
    }
}
