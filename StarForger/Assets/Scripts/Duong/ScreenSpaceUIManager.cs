using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

[Serializable]
public class RecipeDataTMP
{
    public StarType StarType;
    public Image displaySprite;
    public TextMeshProUGUI TMPStarAmount;
}

public class ScreenSpaceUIManager : MonoBehaviour
{
    
    
    public static ScreenSpaceUIManager Instance;

    // public Image CurrentOnScreenItem;
    public TextMeshProUGUI RecipeHeader;
    public List<RecipeDataTMP> RecipeDisplayList;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateHeader(int currentAmount, int maxAmount)
    {
        RecipeHeader.text = "Recipe #" + currentAmount + "/" + maxAmount;
    }

    // public void UpdateCurrentRecipeCount(RecipeElement currentAmount, RecipeElement requiredAmount)
    // {
    //     var count = requiredAmount.recipeElement.Count;
    //     if (currentAmount.recipeElement.Count != requiredAmount.recipeElement.Count)
    //     {
    //         Debug.LogError("Unequal amount of elements, please check SS_UI_MANAGER");
    //     }
    //
    //     for (int i = 0; i < RecipeDisplayList.Count; i++)
    //     {
    //         for (int j = 0; j < count; j++)
    //         {
    //             
    //         }
    //     }
    //     
    // }
    
    
    // public void UpdateItemSlot(Sprite currentSprite, string amount)
    // {
    //     //CurrentOnScreenItem.sour = currentSprite;
    //     //CurrentOnScreenItem.GetComponent<Image>().sprite
    //     CurrentOnScreenItem.sprite = currentSprite;
    //     TMPStarAmount.text = amount;
    // }
}
