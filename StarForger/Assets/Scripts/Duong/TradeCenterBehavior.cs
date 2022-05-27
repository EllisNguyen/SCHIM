using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class TradeCenterBehavior : MonoBehaviour
{
    [SerializeField] private SO_TradeCenterType _tradeCenterType;

    private List<SO_StarPickupType> _starPickupTypeList = new List<SO_StarPickupType>();
    [SerializeField] private SpriteRenderer _inputSpriteRenderer;
    [SerializeField] private SpriteRenderer _outputSpriteRenderer;
    
    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, GameManager.Instance.globalYPos, transform.position.z);
        _starPickupTypeList = GameManager.Instance.starPickupTypeList;

        for (int i = 0; i < _starPickupTypeList.Count; i++)
        {
            if (_tradeCenterType.inputStar == _starPickupTypeList[i].starValue)
            {
                _inputSpriteRenderer.sprite = _starPickupTypeList[i].sprite;
            }
            else if (_tradeCenterType.outputStar == _starPickupTypeList[i].starValue)
            {
                _outputSpriteRenderer.sprite = _starPickupTypeList[i].sprite;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
