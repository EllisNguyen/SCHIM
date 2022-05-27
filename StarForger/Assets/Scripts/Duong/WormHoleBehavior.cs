using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHoleBehavior : MonoBehaviour
{
    [SerializeField] private float _spawnInterval;
    private float _currentSpawnTimer;
    [SerializeField] private float _spreadAngle;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _currentSpawnTimer = _spawnInterval;
    }
    
    void Start()
    {
        transform.position = new Vector3(transform.position.x, GameManager.Instance.globalYPos, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        _currentSpawnTimer -= Time.deltaTime;

        if (_currentSpawnTimer <= 0)
        {
            //spawn shape
            _currentSpawnTimer = _spawnInterval;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 forward = transform.forward * 8;
        Gizmos.DrawLine(transform.position, transform.position+ forward);
    }
}
