using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fader : MonoBehaviour
{

    public CanvasGroup fadeImg;
    public float fadeTime = 0.65f;

    private void Awake()
    {
        FadeOut();
    }

    public void FadeIn()
    {
        fadeImg.DOFade(0, fadeTime);
    }

    public IEnumerator FadeInAsync()
    {
        fadeImg.DOFade(0, fadeTime);
        yield return new WaitForSeconds(fadeTime);
    }

    public void FadeOut()
    {
        fadeImg.DOFade(1, fadeTime);
    }

    public IEnumerator FadeOutAsync()
    {
        fadeImg.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
    }
}
