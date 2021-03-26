using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpText : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;
    public float tutorialDisplayTime = 5f;
    public float waitForTutorialTime = 5f;


    void Update()
    {
        Tutorial();
        //InvokeRepeating("Tutorial", tutorialDisplayTime, waitForTutorialTime);
    }

    public void Tutorial()
    {
        //popUpBox.SetActive(true);
        //popUpText.text = text;
        StartCoroutine(tutorialIdle());
        StartCoroutine(tutorialTime());
        StartCoroutine(tutorialClose());
        //animator.SetTrigger("idle");
        //popUpBox.SetActive(false);
    }

    IEnumerator tutorialIdle()
    {
        yield return new WaitForSeconds(waitForTutorialTime);
        animator.SetTrigger("idle");
    }

    IEnumerator tutorialTime()
    {
        yield return new WaitForSeconds(tutorialDisplayTime);
        animator.SetTrigger("pop");
    }

    IEnumerator tutorialClose()
    {
        yield return new WaitForSeconds(waitForTutorialTime);
        animator.SetTrigger("close");
    }
}
