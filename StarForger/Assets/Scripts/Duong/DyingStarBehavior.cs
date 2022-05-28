using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RecipeRandomizer))]

//[Serializable]
// public class Inven
// {
//     public StarType StarType;
//     public int currentAmount;
// }

public class DyingStarBehavior : MonoBehaviour
{
    private RecipeElement _currentRecipeDataList;
    private RecipeRandomizer _randomizerBehavior => GetComponent<RecipeRandomizer>();
    
    private void Start()
    {
        //populating list of starType and their count to push into the DyingStar
        foreach (var data in GameManager.Instance.starPickupTypeList)
        {
            var element = new InvenItem
            {
                starData = data,
                starCount = 0
            };
            _currentRecipeDataList.recipeElement.Add(element);
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var starBehavior = other.GetComponent<StarBehavior>();
        if (!starBehavior) return;

        foreach (var data in _currentRecipeDataList.recipeElement)
        {
            if (starBehavior.starData.starValue == data.starData.starValue)
            {
                data.starCount++;
            }
        }

        _randomizerBehavior.GetCurrentRecipe();
        
        
        var header1 = _randomizerBehavior.GetCurrentRecipeCount();
        var header2 = _randomizerBehavior.GetMaxRecipeCount();
        ScreenSpaceUIManager.Instance.UpdateHeader(header1, header2);
    }
}
