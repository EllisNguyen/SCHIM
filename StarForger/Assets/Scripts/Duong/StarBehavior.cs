using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Body))]

public class StarBehavior : MonoBehaviour
{
    public SO_StarPickupType starData;

    private SpriteRenderer _spriteRenderer => GetComponentInChildren<SpriteRenderer>();
    private Rigidbody _rigidbody => GetComponent<Rigidbody>();
    private Body _body => GetComponent<Body>();
    public bool canPlayerPickUp = true;

    public Sprite Circle;
    public Sprite Triangle;
    public Sprite Square;

    public Color SquareColor;
    
    private void Start()
    {
        _body.enabled = false;
        transform.position = new Vector3(transform.position.x, GameManager.Instance.globalYPos, transform.position.z);

        //_spriteRenderer.sprite = starData.sprite;
        ChangeAccordingSprite();
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
        RemoveBlackHoleContact();
        starData = outputType;
        ChangeAccordingSprite();
        //_spriteRenderer.sprite = starData.sprite;
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

    public void UpdateStarData(SO_StarPickupType newData)
    {
        RemoveBlackHoleContact();
        starData = newData;
        //_spriteRenderer.sprite = starData.sprite;
        ChangeAccordingSprite();
    }

    public void OnBlackHoleContact(GameObject blackHole)
    {
        //_rigidbody.velocity.magni = Vector3.zero;
        _body.enabled = true;
        _body.heavyBody = blackHole;
    }

    public void RemoveBlackHoleContact()
    {
        _body.heavyBody = null;
        _body.enabled = false;
    }

    public void ChangeAccordingSprite()
    {
        switch (starData.starValue)
        {
            case StarType.Square:
                _spriteRenderer.sprite = Square;
                _spriteRenderer.color = Color.magenta;
                break;
            case StarType.Triangle:
                _spriteRenderer.sprite = Triangle;
                _spriteRenderer.color = Color.green;
                break;
            case StarType.Circle:
                _spriteRenderer.sprite = Circle;
                _spriteRenderer.color = Color.red;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
