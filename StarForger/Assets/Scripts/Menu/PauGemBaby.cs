using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauGemBaby : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] bool isPaused = false;

    public GameObject config;
    public GameObject tutorial;
    
    public void PauseGame(bool _isPaused)
    {
        if (_isPaused)
        {
            Time.timeScale = 0;
            
        }
        else
        {
            config.SetActive(false);
            tutorial.SetActive(false);
            Time.timeScale = 1;
        }
        
        pauseMenu.SetActive(_isPaused);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;

        PauseGame(isPaused);
    }

    public void PressResume()
    {
        isPaused = false;
    }

    public void PressConfig()
    {
        print("Chim 1");
    }

    public void PressTutorial()
    {
        print("Chim 2");
    }

    public void PressToMenu()
    {
        isPaused = false;
        LevelManager.Instance.LoadMenu();
    }
}
