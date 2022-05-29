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

public class GameManager : Singleton<GameManager>
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
    
    
    //TimerCountDown
    public float countDown = 120.0f;
    [SerializeField] int countDownByMinute;
    public string displayTimeValue;
    int[] minutes = new int[] { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15 };


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        AudioManager.instance.PlayThisClipBGM("GameplayMusic", 0.5f, true);
        
        for (int i = 0; i < minutes.Length; i++)
        {
            if (countDown / minutes[i] > 0)
            {
                if (countDown / minutes[i] >= 60)
                {
                    print("time at i: " + countDown / minutes[i]);
                    countDownByMinute = i + 1;
                }
                //else if(countDown / minutes[i] < 60)
                //{
                //    countDownByMinute = 0;
                //}
            }
            //else countDownByMinute = 0;
        }

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

    private void Update() 
    {     
        if(countDown > 0)     
        {         
            countDown -= Time.deltaTime;     
        }

        double b = System.Math.Round(countDown - (60 * (countDownByMinute - 1)), 0);
        string currentTime = string.Format("{00:00}:{1:00}", countDownByMinute, b);

        if (countDownByMinute > 0)
        {
            if (b < 0)
            {
                countDownByMinute -= 1;
            }
        }
        else if (countDownByMinute == 0)
        {
            if (countDown < 0)
            {
                AudioManager.instance.PlayThisClipBGM("Lose", 0.7f, false);
                Debug.Log("You've Lost");
            }
        }


        displayTimeValue = currentTime.ToString();
    }

    public bool CanSpawn()
    {
        return spawnIndex < maxStarOnScreen;
    }
    
}
