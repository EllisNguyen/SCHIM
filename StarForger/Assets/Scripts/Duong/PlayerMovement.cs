using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputHandler _input;

    [SerializeField]
    private bool RotateTowardMouse = true;
    [SerializeField]
    private float MovementSpeed;

    private Rigidbody _rigidbody => GetComponent<Rigidbody>();
    
    private Camera Camera => Camera.main;
    private Transform _camtTransform;

    private void Awake()
    {
       
        _input = GetComponent<InputHandler>();
        _camtTransform = Camera.transform;
    }

    private void Start()
    {
        
        transform.position = new Vector3(transform.position.x, GameManager.Instance.globalYPos, transform.position.z);
    }


    // Update is called once per frame
    void Update()
    {
        _camtTransform.position = new Vector3(transform.position.x, _camtTransform.position.y, transform.position.z);

        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
        var movementVector = MoveTowardTarget(targetVector);
        
        if (RotateTowardMouse)
        {
            RotateFromMouseVector();
        }

        if (_rigidbody.velocity.magnitude > 0)
        {
            _rigidbody.velocity = Vector3.zero;
        }

    }

    private void RotateFromMouseVector()
    {
        Ray ray = Camera.ScreenPointToRay(_input.MousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = MovementSpeed * Time.deltaTime;
        // transform.Translate(targetVector * (MovementSpeed * Time.deltaTime)); Demonstrate why this doesn't work
        //transform.Translate(targetVector * (MovementSpeed * Time.deltaTime), Camera.gameObject.transform);

        targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    // private void RotateTowardMovementVector(Vector3 movementDirection)
    // {
    //     if(movementDirection.magnitude == 0) { return; }
    //     var rotation = Quaternion.LookRotation(movementDirection);
    //     transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
    // }
}