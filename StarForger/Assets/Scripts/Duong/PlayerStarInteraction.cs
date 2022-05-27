using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InvenItem
{
    //public StarType starType;
    public int starCount;
    //public Sprite sprite;
    public SO_StarPickupType starData;
}

public class PlayerStarInteraction : MonoBehaviour
{
    //private List<SO_StarPickupType> _starTypeList = new List<SO_StarPickupType>();
    [SerializeField] private List<InvenItem> _inventoryList;

    [SerializeField] private int currentInventoryIndex = 0;

    private GameObject _starPrefab;

    [SerializeField] private Transform _shootPoint;
    
    private void Start()
    {
        var starTypeList = GameManager.Instance.starPickupTypeList;
        _starPrefab = GameManager.Instance.starPrefab;
        
        //initialize with size
        //print($"{starTypeList.Count}");
        //_inventoryList = new List<InvenItem>(starTypeList.Count);
        for (int i = 0; i < starTypeList.Count; i++)
        {
            _inventoryList.Add(new InvenItem());
            _inventoryList[i].starData = starTypeList[i];
            //_inventoryList[i].starType = starTypeList[i].starValue;
            _inventoryList[i].starCount = 0;
            //_inventoryList[i].sprite = starTypeList[i].sprite;
        }
        
        //Update UI on screenSpace
        UpdateScreenSprite();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var starBehavior = other.GetComponent<StarBehavior>();
        
        if (!starBehavior) return;
        if (!starBehavior.canPlayerPickUp) return;
        
        //get star type
        var starValue = starBehavior.GetStarType();
        //add to inventory
        foreach (var item in _inventoryList)
        {
            if (item.starData.starValue == starValue)
                item.starCount++;
        }
        //destroy star
        starBehavior.OnCollected();
        UpdateScreenSprite();
    }

    private void Update()
    {
        OnInventorySwitch();
        OnFire();
        
    }

    private void OnFire()
    {
        if (Input.GetMouseButtonDown(0))//left click
        {
            if (_inventoryList[currentInventoryIndex].starCount <= 0) return;
            
            //shoot star and add force
            var starBehavior = Instantiate(_starPrefab, _shootPoint.position, Quaternion.identity).GetComponent<StarBehavior>();
            starBehavior.starData = _inventoryList[currentInventoryIndex].starData;
            starBehavior.PlayerPickUpCoolDown();
            starBehavior.SetDrag(0.1f);
            starBehavior.AddForce(_shootPoint.forward * 1000);

            //Update inventory amount
            _inventoryList[currentInventoryIndex].starCount--;
            UpdateScreenSprite();
        }
    }
    
    private void OnInventorySwitch()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentInventoryIndex++;
            
            if (currentInventoryIndex > _inventoryList.Count - 1)
                currentInventoryIndex = 0;
            
            UpdateScreenSprite();
            
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentInventoryIndex--;
            
            if (currentInventoryIndex < 0)
                currentInventoryIndex = _inventoryList.Count - 1;
            
            UpdateScreenSprite();
        }
    }
    
    private void UpdateScreenSprite()
    {
        ScreenSpaceUIManager.Instance.UpdateItemSlot(_inventoryList[currentInventoryIndex].starData.sprite,
                                                    _inventoryList[currentInventoryIndex].starCount.ToString());
    }
}
