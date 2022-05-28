using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public PlayerEntity entity;

    private void Start()
    {
        entity = GameObject.FindObjectOfType<PlayerEntity>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            print("in");
            entity.InBound();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            print("out");
            entity.OutBound();
        }
    }

}
