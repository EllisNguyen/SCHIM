using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
   // private RecipeElement _currentRecipeDataList = new RecipeElement(){recipeElement = new List<RecipeInvenItem>()};
    private RecipeRandomizer _randomizerBehavior => GetComponent<RecipeRandomizer>();
    
    private void Start()
    {
        //populating list of starType and their count to push into the DyingStar
        // foreach (var data in GameManager.Instance.starPickupTypeList)
        // {
        //     var element = new RecipeInvenItem
        //     {
        //         starData = data,
        //         starCurrent = 0,
        //         starRequired = 0
        //     };
        //     _currentRecipeDataList.recipeElement.Add(element);
        // }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var starBehavior = other.GetComponent<StarBehavior>();
        if (!starBehavior) return;


        foreach (var data in _randomizerBehavior.recipeArray[_randomizerBehavior.currentRecipeIndex].recipeElement)
        {
            if (starBehavior.starData.starValue == data.starData.starValue)
            {
                data.starCurrent++;
                //GameManager.Instance.UpdateCurrentNum(data);
            }
        }

        _randomizerBehavior.CheckCompleteRecipe();
        
        starBehavior.OnCollected();
        
        
        
        // foreach (var data in _currentRecipeDataList.recipeElement)
        // {
        //     if (starBehavior.starData.starValue == data.starData.starValue)
        //     {
        //         data.starCount++;
        //         GameManager.Instance.UpdateCurrentNum(data);
        //     }
        // }
        //
        //
        //
        // _randomizerBehavior.GetCurrentRecipe();
        //
        //
        // var header1 = _randomizerBehavior.GetCurrentRecipeCount();
        // var header2 = _randomizerBehavior.GetMaxRecipeCount();
        //ScreenSpaceUIManager.Instance.UpdateHeader(header1, header2);
    }

   
}
