using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ControlScript : MonoBehaviour
{
    Transform controlPanel;
    //Will allow for detection of what key will be assigned
    Event keyEvent;
    //Text to display what control has been changed to
    TMP_Text buttonText;
    //To determine the newly assigned key, will be assigned to a control keycode
    KeyCode newKey;

    bool waitForKey;
    // Start is called before the first frame update
    void Start()
    {
        //Fidn the panel object in the control panel
        controlPanel = transform.Find("Controls");
        //Setting the panel to inactive at first
        controlPanel.gameObject.SetActive(false);
        waitForKey = false;

        //This will go through all of the child items in the controlPanel object (I.E. all of the buttons)
        for (int i = 0; i < controlPanel.childCount; i++){
            //If the child of the controlPanel object (the button) is called "LeftButton"
            if(controlPanel.GetChild(i).name == "LeftButton")
            {
                //Get the child's text component and change the text to equal to the left key value assigned in the GameManager script. Then convert it to a string value to change the text
                controlPanel.GetChild(i).GetComponentInChildren<TMP_Text>().text = GameManager.GM.left.ToString();
            }
            //If the child of the controlPanel object (the button) is called "RightButton"
            else if (controlPanel.GetChild(i).name == "RightButton")
            {
                //Get the child's text component and change the text to equal to the left key value assigned in the GameManager script. Then convert it to a string value to change the text
                controlPanel.GetChild(i).GetComponentInChildren<TMP_Text>().text = GameManager.GM.right.ToString();
            }
            //If the child of the controlPanel object (the button) is called "JumpButton"
            else if (controlPanel.GetChild(i).name == "JumpButton")
            {
                //Get the child's text component and change the text to equal to the left key value assigned in the GameManager script. Then convert it to a string value to change the text
                controlPanel.GetChild(i).GetComponentInChildren<TMP_Text>().text = GameManager.GM.jump.ToString();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.Escape) && !controlPanel.gameObject.activeSelf)
        {
            controlPanel.gameObject.SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.Escape) && controlPanel.gameObject.activeSelf)
        {
            controlPanel.gameObject.SetActive(false);
        }*/
        
    }

    //This function gets called every frame for the GUI specifically. It also has events that can be used based on the event handler utilized.
    private void OnGUI()
    {
        keyEvent = Event.current;

        if(keyEvent.isKey && waitForKey == true)
        {
            newKey = keyEvent.keyCode;
            waitForKey = false;
        }
    }

    public void StartKeyBind(string keyName)
    {
        if (!waitForKey)
        {
            StartCoroutine(AssignKey(keyName));
        }
    }

    public void SendText(TMP_Text text)
    {
        buttonText = text;
    }

    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
        {
            yield return null;
        }
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitForKey = true;

        yield return WaitForKey();

        //Switch statement used to save player's key input that they have changed. 
        switch (keyName)
        {
            case "left":
                GameManager.GM.left = newKey;
                buttonText.text = GameManager.GM.left.ToString();
                PlayerPrefs.SetString("LeftKey", GameManager.GM.left.ToString());
            break;

            case "right":
                GameManager.GM.right = newKey;
                buttonText.text = GameManager.GM.right.ToString();
                PlayerPrefs.SetString("RightKey", GameManager.GM.right.ToString());
            break;

            case "jump":
                GameManager.GM.jump = newKey;
                buttonText.text = GameManager.GM.jump.ToString();
                PlayerPrefs.SetString("JumpKey", GameManager.GM.jump.ToString());
            break;
        }

        yield return null;
    }
}
