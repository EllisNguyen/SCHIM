using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class StarCard : MonoBehaviour
{

    [SerializeField] Image starIcon;
    [SerializeField] TextMeshProUGUI starCount;

    [SerializeField] RectTransform cardRect;
    [SerializeField] Vector2 deselectedForm;
    [SerializeField] Vector2 selectedForm;

    [SerializeField] float time = 0.15f;

    [SerializeField] Image iconImg;
    [SerializeField] Vector2 deselectedFormIcon;
    [SerializeField] Vector2 selectedFormIcon;

    [SerializeField] bool _isActive = false;

    public void UpdateItemSlot(Sprite currentSprite, string amount)
    {
        starIcon.sprite = currentSprite;
        starCount.text = amount;
    }

    public void Active(bool isActive)
    {
        if (isActive)
        {
            cardRect.DOSizeDelta(selectedForm, time);
            iconImg.GetComponent<RectTransform>().DOSizeDelta(selectedFormIcon, time);
        }
        else
        {
            cardRect.DOSizeDelta(deselectedForm, time);
            iconImg.GetComponent<RectTransform>().DOSizeDelta(deselectedFormIcon, time);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cardRect = GetComponent<RectTransform>();

        cardRect.sizeDelta = deselectedForm;
    }
}
