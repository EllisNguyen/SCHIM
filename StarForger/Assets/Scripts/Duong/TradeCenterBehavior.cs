using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class TradeCenterBehavior : MonoBehaviour
{
    [SerializeField] private SO_TradeCenterType _tradeCenterType;

    private List<SO_StarPickupType> _starPickupTypeList = new List<SO_StarPickupType>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, GameManager.Instance.globalYPos, transform.position.z);
        _starPickupTypeList = GameManager.Instance.starPickupTypeList;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
