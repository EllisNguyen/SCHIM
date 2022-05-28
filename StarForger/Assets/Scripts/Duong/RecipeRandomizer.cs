using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct RecipeElement
{
    public List<InvenItem> recipeElement;
}
public class RecipeRandomizer : MonoBehaviour
{
    [SerializeField] private int _recipeAmount = 5;
    [SerializeField] private int _maxStarStack = 3;//max amount of same type star in a single recipe
    [SerializeField] private RecipeElement _recipeElement;
    [SerializeField] private RecipeElement [] _recipeArray;

    // Start is called before the first frame update
    void Start()
    {
        _recipeArray = new RecipeElement [_recipeAmount];
        //int recipeListNum = _recipeAmount;
        var starTypeList = GameManager.Instance.starPickupTypeList;
        
        
        //Populate the Recipe list with the element
        for (int i = 0; i < _recipeArray.Length; i++)
        {
            int totalStar = 0;
            //Populate the element
            for (int j = 0; j < starTypeList.Count; j++)
            {
                print($"{j}");
                _recipeElement.recipeElement.Add(new InvenItem());
                _recipeElement.recipeElement[j].starData = starTypeList[j];
                
                //avoid all 3 element being 0
                if (j == starTypeList.Count - 1 && totalStar == 0)
                {
                    _recipeElement.recipeElement[j].starCount = (int)Random.Range(1, _maxStarStack+1);
                }
                else
                {
                    totalStar = _recipeElement.recipeElement[j].starCount = (int)Random.Range(0, _maxStarStack+1);
                }
            }
            
            //add the element to list and clear it to make a new one
            _recipeArray[i] = _recipeElement;
            //_recipeElement.recipeElement.Clear();
            _recipeElement.recipeElement = new List<InvenItem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
