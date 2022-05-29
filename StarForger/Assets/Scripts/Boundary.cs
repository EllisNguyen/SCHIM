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
            AudioManager.instance.PlayThisClipBGM("GameplayMusic", 0.5f, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            print("out");
            entity.OutBound();
            AudioManager.instance.PlayThisClipBGM("Warning", 0.5f, true);
        }
    }

}
