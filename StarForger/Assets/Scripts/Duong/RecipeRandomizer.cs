using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class RecipeInvenItem
{
    public int starCurrent;
    public int starRequired;
    public SO_StarPickupType starData;
}
[Serializable]
public struct RecipeElement
{
    public List<RecipeInvenItem> recipeElement;
}
public class RecipeRandomizer : MonoBehaviour
{
    public static RecipeRandomizer Instance;
    [SerializeField] private int _recipeAmount = 5;
    [SerializeField] private int _minStarStack = 0;
    [SerializeField] private int _maxStarStack = 3;//max amount of same type star in a single recipe
    [SerializeField] private RecipeElement _recipeElement = new RecipeElement();
    [SerializeField] public RecipeElement [] recipeArray;
    public bool isWon = false;

    public int currentRecipeIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _recipeElement.recipeElement = new List<RecipeInvenItem>();
        recipeArray = new RecipeElement [_recipeAmount];
        //int recipeListNum = _recipeAmount;
        var starTypeList = GameManager.Instance.starPickupTypeList;
        
        
        //Populate the Recipe list with the element
        for (int i = 0; i < recipeArray.Length; i++)
        {
            int totalStar = 0;
            //Populate the element
            for (int j = 0; j < starTypeList.Count; j++)
            {
                //print($"{j}");
                _recipeElement.recipeElement.Add(new RecipeInvenItem());
                _recipeElement.recipeElement[j].starData = starTypeList[j];
                
                //avoid all 3 element being 0
                if (j == starTypeList.Count - 1 && totalStar == 0)
                {
                    _recipeElement.recipeElement[j].starRequired = (int)Random.Range(1, _maxStarStack+1);
                }
                else
                {
                    totalStar = _recipeElement.recipeElement[j].starRequired = (int)Random.Range(_minStarStack, _maxStarStack+1);
                }
            }
            
            //add the element to list and clear it to make a new one
            recipeArray[i] = _recipeElement;
            //_recipeElement.recipeElement.Clear();
            _recipeElement.recipeElement = new List<RecipeInvenItem>();
        }
        
        // //update required num
        // foreach (var inventItems in _recipeArray[_currentRecipeIndex].recipeElement)
        // {
        //     GameManager.Instance.UpdateRequiredNum(inventItems);
        // }
        // //update recipe amount
        // GameManager.Instance.UpdateCurrentRecipeCount(_currentRecipeIndex, _recipeAmount);
    }

    // public RecipeElement GetCurrentRecipe()
    // {
    //     return new RecipeElement();
    // }
    
    public void CycleNextRecipe()
    {
        AudioManager.instance.PlayThisClipFX("RecipeComplete", 0.8f);
        currentRecipeIndex++;
        
        if (currentRecipeIndex > _recipeAmount - 1)
        {
            currentRecipeIndex--;
            Debug.Log("WIN");
            isWon = true;
            return;
        }
        
        // foreach (var inventItems in _recipeArray[_currentRecipeIndex].recipeElement)
        // {
        //     GameManager.Instance.UpdateRequiredNum(inventItems);
        // }
        //
        // GameManager.Instance.UpdateCurrentRecipeCount(_currentRecipeIndex, _recipeAmount);
        
    }

    public void CheckCompleteRecipe()
    {
        bool complete = true;
        foreach (var data in recipeArray[currentRecipeIndex].recipeElement)
        {
            if (data.starCurrent < data.starRequired)
            {
                complete = false;
            }
        }

        if (complete)
        {
            CycleNextRecipe();
        }
    }
    
    public int GetCurrentRecipeCount()
    {
        return currentRecipeIndex;
    }

    public int GetMaxRecipeCount()
    {
        return _recipeAmount;
    }
}
