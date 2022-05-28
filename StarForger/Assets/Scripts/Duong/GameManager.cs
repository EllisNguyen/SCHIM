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
    public int maxStarOnScreen = 20;
    public int spawnIndex = 0;
    
    public GameObject starPrefab;
    //public List<GameObject> starPool = new List<GameObject>();

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

    // public void RemoveNullFromStarPool()
    // {
    //     for(int i = 0; i < starPool.Count; i++)
    //     {
    //         if (starPool[i] == null)
    //         {
    //             starPool.RemoveAt(i);
    //         }
    //     }
    // }
    //
    // public void AddToPool(GameObject star)
    // {
    //     if (starPool.Count >= maxStarOnScreen) { return; }
    //     starPool.Add(star);
    // }

    public bool CanSpawn()
    {
        return spawnIndex < maxStarOnScreen;
    }
    
}
