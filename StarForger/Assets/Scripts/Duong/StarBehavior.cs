using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]

public class StarBehavior : MonoBehaviour
{
    public SO_StarPickupType starData;

    private MeshFilter _meshFilter => GetComponent<MeshFilter>();
    private MeshRenderer _meshRenderer => GetComponent<MeshRenderer>();
    private Rigidbody _rigidbody => GetComponent<Rigidbody>();
    

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, GameManager.Instance.globalYPos, transform.position.z);
        
        _meshFilter.mesh = starData.mesh;
        _meshRenderer.material = starData.mainMaterial;
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
}
