using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InvenItem
{
    public StarType starType;
    public int starCount;
}

public class PlayerStarInteraction : MonoBehaviour
{
    //private List<SO_StarPickupType> _starTypeList = new List<SO_StarPickupType>();
    private List<InvenItem> _inventoryList = new List<InvenItem>();

    private void Start()
    {
        var starTypeList = GameManager.Instance.starPickupTypeList;
        
        //initialize with size
        _inventoryList = new List<InvenItem>(starTypeList.Count);
        foreach (var item in _inventoryList)
        {
            
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var starBehavior = other.GetComponent<StarBehavior>();
        
        if (!starBehavior) return;

        var starValue = starBehavior.GetStarType();
        
    }
}
