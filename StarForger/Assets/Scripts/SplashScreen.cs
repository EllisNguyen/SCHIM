using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SplashScreen : MonoBehaviour
{
    public VideoPlayer splash;
    Fader fader;

    IEnumerator Start()
    {
        splash.Play();
        splash.loopPointReached += OnSpashFinished;
        fader = FindObjectOfType<Fader>();
        yield return fader.FadeInAsync();

        yield return new WaitForSeconds((float)splash.length - 0.5f);

        yield return fader.FadeOutAsync();

        LevelManager.Instance.LoadMenu();
    }

    void OnSpashFinished(VideoPlayer player)
    {
        Debug.Log("Event for movie end called");
        player.Stop();
    }
}
