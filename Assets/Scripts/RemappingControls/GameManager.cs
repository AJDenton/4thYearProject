using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public KeyCode jump { get; set; }
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }
    //public KeyCode grab { get; set; }


    private void Awake()
    {
        if(GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        } else if (GM != this)
        {
            Destroy(gameObject);
        }

        //Assigns the controls to the previously preferred control scheme based on the last time someone has played the game on a local machine. If there is not a preferred key, it will assign the control to the second string (in this line, "Space".
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));

    }
}
