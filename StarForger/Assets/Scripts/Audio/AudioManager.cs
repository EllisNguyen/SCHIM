using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource musiqueSource;
    [SerializeField] AudioSource sfxSource;

    [SerializeField] List<AudioType> audioType;

    public AudioClip[] audioClips;

    public static AudioManager instance;

    void Awake()
    {
        instance = this;
    }

    //public void PlayMusique(string name, AudioClip clip)
    //{
    //    //musiqueSource.clip = audioType.PlayAudio(name, clip);

    //    clip = audioType.Where(p => p.Clip == clip).FirstOrDefault();
    //    musiqueSource.Play();
    //}

    public void PlayThisClip(string incomeingClip)
    {
        foreach (AudioClip clip in audioClips)
        {
            if (clip.name == incomeingClip)
                sfxSource.PlayOneShot(clip);
        }
    }
}

[System.Serializable]
public class AudioType
{
    [SerializeField] string audioName;
    [SerializeField] AudioClip clip;

    public string AudioName => audioName;
    public AudioClip Clip => clip;

    public void PlayAudio(string _audioName, AudioClip _clip)
    {
        this.audioName = _audioName;
        this.clip = _clip;
    }
}