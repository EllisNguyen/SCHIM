using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class TestCardAnim : MonoBehaviour
{
    [SerializeField] RectTransform cardRect;
    [SerializeField] Vector2 deselectedForm;
    [SerializeField] Vector2 selectedForm;

    [SerializeField] float time = 0.15f;

    [SerializeField] Image iconImg;
    [SerializeField] Vector2 deselectedFormIcon;
    [SerializeField] Vector2 selectedFormIcon;

    public void Active()
    {
        cardRect.DOSizeDelta(selectedForm, time);
        iconImg.GetComponent<RectTransform>().DOSizeDelta(selectedFormIcon, time);
    }

    public void NonActive()
    {
        cardRect.DOSizeDelta(deselectedForm, time);
        iconImg.GetComponent<RectTransform>().DOSizeDelta(deselectedFormIcon, time);
    }

    // Start is called before the first frame update
    void Start()
    {
        cardRect = GetComponent<RectTransform>();

        cardRect.sizeDelta = deselectedForm;
    }


}
