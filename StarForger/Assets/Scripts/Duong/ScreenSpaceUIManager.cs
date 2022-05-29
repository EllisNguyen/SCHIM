using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    
    public TextMeshProUGUI TMPTimeLeft;

    public GameObject winCanvas;
    public GameObject loseCanvas;
    public string levelName;
    [SerializeField] int nextLevel;

    private void Awake()
    {
        Instance = this;
        levelName = SceneManager.GetActiveScene().name;
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void ToMenu()
    {
        LevelManager.Instance.LoadMenu();
    }

    public void ReloadLevel()
    {
        Application.LoadLevel(levelName);
    }

    public void NextLevel()
    {
        LevelManager.Instance.ActivateScene(nextLevel);

        LevelManager.Instance.LoadScene(nextLevel);
    }

    private void Update()
    {
        //if (!RecipeRandomizer.Instance.isWon)
        //{
            UpdateHeader();
            UpdateRecipeElement();
         
            TMPTimeLeft.text = GameManager.Instance.displayTimeValue;

            //}
    }
    
    public void UpdateHeader()
    {
        var currIndex = RecipeRandomizer.Instance.isWon
            ? RecipeRandomizer.Instance.GetMaxRecipeCount()
            : RecipeRandomizer.Instance.currentRecipeIndex;
        RecipeHeader.text = "Recipe #" + currIndex + "/" + RecipeRandomizer.Instance.GetMaxRecipeCount();
    }

    public void UpdateRecipeElement()
    {
        var trackers = RecipeRandomizer.Instance.recipeArray[RecipeRandomizer.Instance.currentRecipeIndex].recipeElement;
        for (int i = 0; i < RecipeDisplayList.Count; i++)
        {
            RecipeDisplayList[i].StarType = trackers[i].starData.starValue;
            RecipeDisplayList[i].displaySprite.sprite = trackers[i].starData.sprite;
            RecipeDisplayList[i].TMPStarAmount.text = trackers[i].starCurrent + "/" + trackers[i].starRequired;
        }
    }

    public void ActivateWinScreen()
    {
        winCanvas.SetActive(true);
    }

    public void ActivateLoseScreen()
    {
        loseCanvas.SetActive(true);
    }
}
