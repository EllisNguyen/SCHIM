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

    public int currentRecipe;
    public int maxRecipe;

    public List<CurrentRecipeTracker> currentRecipeTrackers = new List<CurrentRecipeTracker>();
    
    private void Awake()
    {
        Instance = this;
    }
}
