using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleBehavior : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    private float _angle;
    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, GameManager.Instance.globalYPos, transform.position.z);
    }

    // Update is called once per frame
    private void Update()
    {
        _angle += rotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, _angle, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        var starBehavior = other.GetComponent<StarBehavior>();
        if (!starBehavior) return;
        
        starBehavior.OnBlackHoleContact(gameObject);
        
    }
}
