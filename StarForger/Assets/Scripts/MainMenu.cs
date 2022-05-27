using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;

    [Header("Start Operation")]
    [SerializeField] Operation startOperation;
    [SerializeField] List<GameObject> disableAfterStart;
    [SerializeField] List<GameObject> enableAfterStart;

    [Header("Config Operation")]
    [SerializeField] GameObject configMenu;
    [SerializeField] Operation configOperation;
    [SerializeField] List<GameObject> disableAfterConfig;
    [SerializeField] List<GameObject> enableAfterConfig;

    [Header("Tutorial Operation")]
    [SerializeField] GameObject tutorialMenu;
    [SerializeField] Operation tutorialOperation;
    [SerializeField] List<GameObject> disableAfterTutorial;
    [SerializeField] List<GameObject> enableAfterTutorial;

    GameObject curMenu;

    void Start()
    {
        curMenu = mainMenu;
    }

    public void PressStart()
    {
        //startOperation?.Invoke();
        for (int i = 0; i < disableAfterStart.Count; i++)
        {
            disableAfterStart[i].SetActive(false);
            enableAfterStart[i].SetActive(true);
        }
    }

    public void PressConfig()
    {
        //configOperation?.Invoke();
        for (int i = 0; i < disableAfterConfig.Count; i++)
        {
            disableAfterConfig[i].SetActive(false);
            enableAfterConfig[i].SetActive(true);
        }
    }

    public void PressTutorial()
    {
        //tutorialOperation?.Invoke();
        for (int i = 0; i < disableAfterTutorial.Count; i++)
        {
            disableAfterTutorial[i].SetActive(false);
            enableAfterTutorial[i].SetActive(true);
        }
    }

    void ActivateMenu(GameObject menu)
    {
        if (curMenu == menu)
        {
            menu.SetActive(false);
            curMenu = null;
        }
        else
        {
            if (curMenu != null)
                curMenu.SetActive(false);

            curMenu = menu;
            menu.SetActive(true);
        }
    }
}
