using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class CurrentRecipeTracker
{
    public SO_StarPickupType starData;
    public int currentNum;
    public int requiredNum;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float globalYPos = 1;
    public  List<SO_StarPickupType> starPickupTypeList = new List<SO_StarPickupType>();
    public GameObject starPrefab;

    public int currentRecipeCount;
    public int maxRecipeCount;

    public List<CurrentRecipeTracker> currentRecipeTrackers = new List<CurrentRecipeTracker>();
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        foreach (var data in starPickupTypeList)
        {
            CurrentRecipeTracker tracker = new CurrentRecipeTracker()
            {
                starData = data,
                currentNum = 0,
                requiredNum = 0
            };
            currentRecipeTrackers.Add(tracker);
        }
    }

    // public void UpdateRequiredNum(InvenItem recipeElement)
    // {
    //     foreach (var tracker in currentRecipeTrackers)
    //     {
    //         if (recipeElement.starData == tracker.starData)
    //         {
    //             tracker.requiredNum = recipeElement.starCount;
    //         }
    //     }
    // }
    //
    // public void UpdateCurrentNum(InvenItem recipeElement)
    // {
    //     foreach (var tracker in currentRecipeTrackers)
    //     {
    //         if (recipeElement.starData == tracker.starData)
    //         {
    //             tracker.currentNum = recipeElement.starCount;
    //         }
    //     }
    // }
    //
    // public void UpdateCurrentRecipeCount(int current, int max)
    // {
    //     currentRecipeCount = current;
    //     maxRecipeCount = max;
    // }
    //
    // private void CheckCompleteRecipe()
    // {
    //     bool complete = true;
    //     foreach (var data in currentRecipeTrackers)
    //     {
    //         if (data.currentNum < data.requiredNum)
    //         {
    //             complete = false;
    //         }
    //     }
    //
    //     if (complete)
    //     {
    //         RecipeRandomizer.Instance.CycleNextRecipe();
    //     }
    // }
}
