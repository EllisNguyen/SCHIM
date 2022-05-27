﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class StarBehavior : MonoBehaviour
{
    public SO_StarPickupType starData;

    private SpriteRenderer _spriteRenderer => GetComponentInChildren<SpriteRenderer>();
    private Rigidbody _rigidbody => GetComponent<Rigidbody>();
    

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, GameManager.Instance.globalYPos, transform.position.z);

        _spriteRenderer.sprite = starData.sprite;
        _rigidbody.useGravity = false;
        
    }

    public void AddForce(Vector3 direction)
    {
        _rigidbody.AddForce(direction);
    }

    public void SetDrag(float drag)
    {
        _rigidbody.drag = drag;
    }

    public StarType GetStarType()
    {
        return starData.starValue;
    }

    public void OnCollected()
    {
        Destroy(gameObject);
    }
}
