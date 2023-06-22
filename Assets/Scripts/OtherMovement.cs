using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherMovement : MonoBehaviour
{
    //public variable
    public float _speed = 1f;
    
    //private variables
    //start moving to the left for enemies
    public Vector2 _direction = Vector2.left;
    private Rigidbody2D _rigidbody;
    private Vector2 _velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        enabled = false;
    }

    //make the enemies start moving when they become visible
    private void OnBecameVisible()
    {
        enabled = true;
    }

    //stop moving when invisible
    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        _rigidbody.WakeUp();
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.Sleep();
    }

    //actual moving
    private void FixedUpdate()
    {
        //update velocity 
        _velocity.x = _direction.x * _speed;
        _velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;
        
        //move position
        _rigidbody.MovePosition(_rigidbody.position + _velocity * Time.fixedDeltaTime);

        //check if they hit a wall and change direction doesn't work?
        if (_rigidbody.Raycast(_direction))
        {
            _direction = -1 * _direction;
        }

        //velocity should not build up when they are on ground
        if (_rigidbody.Raycast(Vector2.down))
        {
            _velocity.y = Mathf.Max(_velocity.y, 0f);
        }
    }
    
    
}
