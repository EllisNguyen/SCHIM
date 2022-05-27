using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class ScreenSpaceUIManager : MonoBehaviour
{
    public static ScreenSpaceUIManager Instance;

    public Image CurrentOnScreenItem;
    public TextMeshProUGUI TMPStarAmount;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateItemSlot(Sprite currentSprite, string amount)
    {
        //CurrentOnScreenItem.sour = currentSprite;
        //CurrentOnScreenItem.GetComponent<Image>().sprite
        CurrentOnScreenItem.sprite = currentSprite;
        TMPStarAmount.text = amount;
    }
}
