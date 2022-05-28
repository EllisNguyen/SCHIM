using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;

public class PlayerEntity : MonoBehaviour
{

    [SerializeField] PostProcessProfile postPro;
    Vignette vignette;
    Bloom bloom;
    ChromaticAberration chroma;
    ColorGrading colorGrading;

    [SerializeField] GameObject outOfBound;
    float prevGrading = 0;
    float prevVignette = 0;

    public void Start()
    {
        postPro.TryGetSettings<Vignette>(out vignette);
        postPro.TryGetSettings<Bloom>(out bloom);
        postPro.TryGetSettings<ChromaticAberration>(out chroma);
        postPro.TryGetSettings<ColorGrading>(out colorGrading);
    }

    public void InBound()
    {
        float gradingVal = prevGrading;
        DOTween.To(() => gradingVal, x => gradingVal = x, 5, 1.35f)
            .OnUpdate(() => {
                colorGrading.saturation.value = gradingVal;
            });
        prevGrading = 5;

        float vignetteVal = prevVignette;
        DOTween.To(() => vignetteVal, x => vignetteVal = x, 0.52f, 1.35f)
            .OnUpdate(() => {
                vignette.intensity.value = vignetteVal;
            });
        prevVignette = 0.52f;

        bloom.intensity.value = 3;
        chroma.intensity.value = 0.08f;
        
        outOfBound.SetActive(false);
    }

    public void OutBound()
    {
        float value = prevGrading;
        DOTween.To(() => value, x => value = x, -100, 1.35f)
            .OnUpdate(() => {
                colorGrading.saturation.value = value;
            });
        prevGrading = -100;

        float vignetteVal = prevVignette;
        DOTween.To(() => vignetteVal, x => vignetteVal = x, 0.65f, 1.35f)
            .OnUpdate(() => {
                vignette.intensity.value = vignetteVal;
            });
        prevVignette = 0.65f;

        bloom.intensity.value = 5f;
        chroma.intensity.value = 0.8f;

        outOfBound.SetActive(true);
    }
}
