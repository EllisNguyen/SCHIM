using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

[RequireComponent(typeof(BoxCollider))]

public class TradeCenterBehavior : MonoBehaviour
{
    [SerializeField] private SO_TradeCenterType _tradeCenterType;

    private List<SO_StarPickupType> _starPickupTypeList = new List<SO_StarPickupType>();
    [SerializeField] private SpriteRenderer _inputSpriteRenderer;
    [SerializeField] private SpriteRenderer _outputSpriteRenderer;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _conversionTimer;
    
    private SO_StarPickupType _outputType;
    
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
                _outputType = _starPickupTypeList[i];
            }
        }
        
    }

    private async void OnTriggerEnter(Collider other)
    {
        var starBehavior = other.GetComponent<StarBehavior>();
        if (!starBehavior) return;

        //if other == input
            //Change type of other
            //spit out other
        //else
            //spit out other

        //same input
        if (starBehavior.starData.starValue == _tradeCenterType.inputStar)
        {
            starBehavior.gameObject.SetActive(false);
            await (Task.Delay((int)_conversionTimer*1000));
            starBehavior.gameObject.SetActive(true);
            starBehavior.OnConverterEntered(_outputType);
            FinishConversion(starBehavior);
        }
        else
        {
            FinishConversion(starBehavior);
        }
            
        
    }

    private void FinishConversion(StarBehavior starBehavior)
    {
        starBehavior.ResetPlayerPickUpCoolDown();
        starBehavior.transform.position = _shootPoint.position;
        starBehavior.SetDrag(2.5f);
        starBehavior.AddForce(transform.forward * 1000);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 forward = transform.forward * 8;
        Gizmos.DrawRay(transform.position, transform.forward * 5);
    }
}
