using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fader : MonoBehaviour
{

    public CanvasGroup fadeImg;
    public float fadeTime = 0.65f;

    public void FadeIn()
    {
        fadeImg.DOFade(0, fadeTime);
    }

    public void FadeOut()
    {
        fadeImg.DOFade(1, fadeTime);
    }

}
