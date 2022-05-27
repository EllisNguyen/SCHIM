using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InvenItem
{
    public StarType starType;
    public int starCount;
}

public class PlayerStarInteraction : MonoBehaviour
{
    //private List<SO_StarPickupType> _starTypeList = new List<SO_StarPickupType>();
    [SerializeField] private List<InvenItem> _inventoryList;

    private void Start()
    {
        var starTypeList = GameManager.Instance.starPickupTypeList;
        
        //initialize with size
        //print($"{starTypeList.Count}");
        //_inventoryList = new List<InvenItem>(starTypeList.Count);
        for (int i = 0; i < starTypeList.Count; i++)
        {
            _inventoryList.Add(new InvenItem());
            _inventoryList[i].starType = starTypeList[i].starValue;
            _inventoryList[i].starCount = 0;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var starBehavior = other.GetComponent<StarBehavior>();
        
        if (!starBehavior) return;

        //get star type
        var starValue = starBehavior.GetStarType();
        //add to inventory
        foreach (var item in _inventoryList)
        {
            if (item.starType == starValue)
                item.starCount++;
        }
        //destroy star
        starBehavior.OnCollected();
        
    }
}
