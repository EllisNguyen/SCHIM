using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAudio : MonoBehaviour
{
    [SerializeField] AudioSource effectSource;
    [SerializeField] AudioSource musiqueSource;

    [SerializeField] AudioClip effectTest;
    [SerializeField] AudioClip musiqueTest;

    public void playFx()
    {
        effectSource.PlayOneShot(effectTest);
    }

    public void playMusique()
    {
        musiqueSource.Play();
    }
}
