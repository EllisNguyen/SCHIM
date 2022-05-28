using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauGemBaby : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] bool isPaused = false;

    public void PauseGame(bool _isPaused)
    {
        if (_isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        
        pauseMenu.SetActive(_isPaused);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;

        PauseGame(isPaused);
    }
}