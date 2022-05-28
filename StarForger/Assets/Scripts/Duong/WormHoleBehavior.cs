using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WormHoleBehavior : MonoBehaviour
{
    [SerializeField] private float _spawnInterval;
    private float _currentSpawnTimer;

    
    [SerializeField] private SO_StarPickupType _starPickupTypeDefault;

    private GameObject _starPrefab;
    [SerializeField] private Transform _spawnRoot;

    [SerializeField] private float _minDrag;
    [SerializeField] private float _maxDrag;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _currentSpawnTimer = _spawnInterval;
    }
    
    void Start()
    {
        transform.position = new Vector3(transform.position.x, GameManager.Instance.globalYPos, transform.position.z);
        //_starPickupTypeDefault = GameManager.Instance.starPickupTypeList[0];
        _starPrefab = GameManager.Instance.starPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        _currentSpawnTimer -= Time.deltaTime;

        if (_currentSpawnTimer <= 0 && GameManager.Instance.CanSpawn())
        {
            //Generate random yaw angle
            _spawnRoot.rotation = Random.rotation;
            float yaw = _spawnRoot.rotation.eulerAngles.y;
            _spawnRoot.eulerAngles = new Vector3(0, yaw, 0);
            var forceDir = _spawnRoot.forward;
            Debug.DrawRay(transform.position, forceDir*10);
            
            //Creating random star
            //var star = Instantiate(_starPrefab, transform.position, Quaternion.identity);
            //add to pool
            //GameManager.Instance.AddToPool(star);
            var star = ObjectPool.Instance.GetGameObject(_starPrefab, transform.position, Quaternion.identity);
            var starBehavior = star.GetComponent<StarBehavior>();
            
            //Add force to said star
            starBehavior.AddForce(forceDir * 1000);
            starBehavior.SetDrag(Random.Range(_minDrag, _maxDrag));
            starBehavior.starData = _starPickupTypeDefault;
            
            //reset timer
            _currentSpawnTimer = _spawnInterval;
            
            //increase spawn index
            GameManager.Instance.spawnIndex++;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 forward = transform.forward * 8;
        Gizmos.DrawRay(transform.position, _spawnRoot.forward * 10);
    }
}
