using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleInnerBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var starBehavior = other.GetComponent<StarBehavior>();
        if (!starBehavior) return;
        
        ObjectPool.Instance.ReturnGameObject(starBehavior.gameObject);
        GameManager.Instance.spawnIndex--;
        
    }
}
