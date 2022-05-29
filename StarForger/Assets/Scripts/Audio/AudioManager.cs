using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource musiqueSource;
    [SerializeField] AudioSource sfxSource;

    [SerializeField] List<AudioType> audioType;

    //public AudioClip[] audioClips;

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

    public void PlayThisClipFX(string incomingClip, float volume)
    {
        foreach (var audio in audioType)
        {
            if (audio.AudioName == incomingClip)
            {
                try
                {

                sfxSource.PlayOneShot(audio.Clip, volume);
                }
                catch (Exception e)
                {
                    ;
                }
            }
        }
    }
    
    //overloaded func
    public void PlayThisClipFX(string incomingClip)
    {
        foreach (var audio in audioType)
        {
            if (audio.AudioName == incomingClip)
            {
                try
                {
                sfxSource.PlayOneShot(audio.Clip, 1);

                }
                catch (Exception e)
                {
                    ;
                }
            }
        }
    }
    

    /// FOR BGM MUSIC

    public void PlayThisClipBGM(string incomingClip, float volume, bool isLoop)
    {
        foreach (var audio in audioType)
        {
            if (audio.AudioName == incomingClip)
            {
                try
                {
                    musiqueSource.Stop();
                    musiqueSource.PlayOneShot(audio.Clip, volume);
                    musiqueSource.loop = isLoop;
                }
                catch (Exception e)
                {
                    ;
                }
            }
        }
    }
    
    public void PlayThisClipBGM(string incomingClip, bool isLoop)
    {
        foreach (var audio in audioType)
        {
            if (audio.AudioName == incomingClip)
            {
                try
                {
                    musiqueSource.Stop();
                    musiqueSource.PlayOneShot(audio.Clip, 1);
                    musiqueSource.loop = isLoop;
                }catch(Exception e)
                {
                    ;
                }
            }
        }
    }

    private void Exception(object e)
    {
        throw new NotImplementedException();
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