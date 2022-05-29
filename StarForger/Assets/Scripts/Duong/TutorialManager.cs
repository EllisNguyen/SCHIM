using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    public void ReturnButton()
    {
        //return to main menu
    }

    public void NextButton()
    {
        page1.SetActive(false);
        page2.SetActive(true);
    }

    public void PreviousButton()
    {
        page1.SetActive(true);
        page2.SetActive(false);
    }
}
