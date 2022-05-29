using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Video;

public enum MenuState { Splash, Menu}

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

    [SerializeField] GameObject creditsMenu;
    [SerializeField] GameObject levelSelectMenu;

    [SerializeField] GameObject camObject;
    [SerializeField] float normalZ = -10f;
    [SerializeField] float levelSelectZ = 350f;

    GameObject curMenu;
    CanvasGroup curCanv;

    public Fader fader;
    public VideoPlayer splashVideo;

    MenuState state;

    IEnumerator Start()
    {
        state = MenuState.Splash;
        fader = FindObjectOfType<Fader>();
        yield return fader.FadeInAsync();
        splashVideo.Play();
        splashVideo.loopPointReached += OnSpashFinished;

        yield return fader.FadeOutAsync();
        yield return fader.FadeInAsync();

        yield return ActivateMenu(mainMenu);
    }

    void OnSpashFinished(VideoPlayer player)
    {
        Debug.Log("Event for movie end called");
        player.Stop();
    }

    public void PressStart()
    {
        if(curMenu.GetComponent<CanvasGroup>() != null) curMenu.GetComponent<CanvasGroup>().interactable = false;
        //startOperation?.Invoke();
        camObject.transform.DOMoveZ(levelSelectZ, 2f);

        StartCoroutine(ActivateMenu(levelSelectMenu, transitionDelay));
        for (int i = 0; i < disableAfterStart.Count; i++)
        {
            disableAfterStart[i].SetActive(false);
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

    public void PressCredits()
    {
        curMenu.GetComponent<CanvasGroup>().interactable = false;

        //tutorialOperation?.Invoke();
        StartCoroutine(ActivateMenu(creditsMenu
            , transitionDelay));
    }

    public void PressBack()
    {
        StartCoroutine(ActivateMenu(mainMenu, transitionDelay));

        if (camObject.transform.position.z != normalZ) camObject.transform.DOMoveZ(normalZ, 1.35f);

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
            menu.GetComponent<CanvasGroup>().DOFade(0, 0.75f);
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


            if (curMenu.GetComponent<CanvasGroup>() == null) yield break;

            curMenu.GetComponent<CanvasGroup>().interactable = true;
            curMenu.GetComponent<CanvasGroup>().DOFade(1, 0.75f);
        }
    }
}
