using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class StarBehavior : MonoBehaviour
{
    public SO_StarPickupType starData;

    private SpriteRenderer _spriteRenderer => GetComponentInChildren<SpriteRenderer>();
    private Rigidbody _rigidbody => GetComponent<Rigidbody>();
    public bool canPlayerPickUp = true;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, GameManager.Instance.globalYPos, transform.position.z);

        _spriteRenderer.sprite = starData.sprite;
        _rigidbody.useGravity = false;
        
    }

    public void AddForce(Vector3 direction)
    {
        _rigidbody.velocity = Vector3.zero;
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
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    public void OnConverterEntered(SO_StarPickupType outputType)
    {
        starData = outputType;
        _spriteRenderer.sprite = starData.sprite;
    }

    public async void PlayerPickUpCoolDown()
    {
        canPlayerPickUp = false;
        await Task.Delay(1000);
        canPlayerPickUp = true;
    }

    public void ResetPlayerPickUpCoolDown()
    {
        canPlayerPickUp = true;
    }
}
