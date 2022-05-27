using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] float transitionDelay = 0.1f;

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
    CanvasGroup curCanv;

    void Start()
    {
        StartCoroutine(ActivateMenu(mainMenu));
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
        curMenu.GetComponent<CanvasGroup>().interactable = false;

        //configOperation?.Invoke();
        StartCoroutine(ActivateMenu(configMenu, transitionDelay));
        for (int i = 0; i < disableAfterConfig.Count; i++)
        {
            disableAfterConfig[i].SetActive(false);
        }

        for (int i = 0; i < enableAfterConfig.Count; i++)
        {
            enableAfterConfig[i].SetActive(true);
        }
    }

    public void PressTutorial()
    {
        curMenu.GetComponent<CanvasGroup>().interactable = false;

        //tutorialOperation?.Invoke();
        StartCoroutine(ActivateMenu(tutorialMenu, transitionDelay));
        for (int i = 0; i < disableAfterTutorial.Count; i++)
        {
            disableAfterTutorial[i].SetActive(false);
        }

        for (int i = 0; i < enableAfterTutorial.Count; i++)
        {
            enableAfterTutorial[i].SetActive(true);
        }
    }

    public void PressBack()
    {
        StartCoroutine(ActivateMenu(mainMenu, transitionDelay));

        for (int i = 0; i < disableAfterStart.Count; i++)
        {
            disableAfterStart[i].SetActive(false);
        }
    }

    IEnumerator ActivateMenu(GameObject menu, float delay = 0f)
    {
        yield return new WaitForSecondsRealtime(delay);

        if (curMenu == menu)
        {
            menu.SetActive(false);
            curMenu = null;
        }
        else
        {
            if (curMenu != null)
            {
                curMenu.SetActive(false);
            }
            curMenu = menu;
            menu.SetActive(true);
            curMenu.GetComponent<CanvasGroup>().interactable = true;
        }
    }
}
