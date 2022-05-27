using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{

    [SerializeField] AudioMixer mixer;

    const string MIXER_MASTER = "MasterVolume";
    const string MIXER_MUSIC = "MusiqueVolume";
    const string MIXER_SFX = "SfxVolume";

    [Header("FPS counter")]
    [SerializeField] GameObject fpsCounter;
    [SerializeField] Toggle enableCounter;

    [Header("Audio Sliders")]
    [SerializeField] Slider mainSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    void Awake()
    {
        fpsCounter = FindObjectOfType<FpsDisplay>().gameObject;

        mainSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusiqueVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);

        enableCounter.onValueChanged.AddListener(EnableFPSCounter);
        fpsCounter.gameObject.SetActive(enableCounter.isOn);
    }

    void SetMasterVolume(float value)
    {
        mixer.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20);
    }

    void SetMusiqueVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }

    void SetSfxVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }

    void EnableFPSCounter(bool isEnabled)
    {
        fpsCounter.gameObject.SetActive(isEnabled);
    }
}
