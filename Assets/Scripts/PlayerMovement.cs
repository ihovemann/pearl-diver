using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private variables
    //camera 
    private Camera _camera;
    private Rigidbody2D _rigidbody;
    
    //moving
    private Vector2 _velocity;
    private float _inputAxis_x;
    private float _inputAxis_y;
    
    //firing bullets
    private float _nextFireTime = 0f;
    private float _firecooldownTime = 0.5f;
    
    //Serialized fields
    [SerializeField] 
    private GameObject _bulletPrefab;
    
    //public variables
    //moving speed
    public float _speed = 8f;
    
    public bool _swimming => Mathf.Abs(_velocity.x) > 0.25f || Mathf.Abs(_inputAxis_x) > 0.25f || Mathf.Abs(_velocity.y) > 0.25f || Mathf.Abs(_inputAxis_y) > 0.25f;
 
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void Update()
    {
        //move
        HorizontalMovement();
        VerticalMovement();
        
        PlayerScript _player = gameObject.GetComponent<PlayerScript>();
        //bullets add constraint of being red
        if (Input.GetKeyDown(KeyCode.E) && _nextFireTime < Time.time && _player._red)
        {
            //instantiate bullet
            Instantiate(_bulletPrefab, transform.position + new Vector3(1f, -0.3f, 0f), Quaternion.identity);
            _nextFireTime = Time.time + _firecooldownTime;
        }

    }

    //regulate Horizontal Movement
    private void HorizontalMovement()
    {
        _inputAxis_x = Input.GetAxis("Horizontal");
        _velocity.x = Mathf.MoveTowards(_velocity.x, _inputAxis_x * _speed, _speed * Time.deltaTime);
        
        //check if we hit a wall in x direction to stop velocity from going up
        if (_rigidbody.Raycast(Vector2.right * _velocity.x))
        {
            _velocity.x = 0f;
        }
        
        
        //change rotation of diver 
        //facing right
        if (_velocity.x > 0f)
        {
            transform.eulerAngles = Vector3.zero;
        }
        //facing left
        else if(_velocity.x < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
    
    //regulate vertical Movement
    private void VerticalMovement()
    {
        _inputAxis_y = Input.GetAxis("Vertical");
        _velocity.y = Mathf.MoveTowards(_velocity.y, _inputAxis_y * _speed, _speed * Time.deltaTime);
        
        //check if we hit a wall in y direction to stop velocity from going up
        if (_rigidbody.Raycast(Vector2.down * _velocity.y))
        {
            _velocity.y = 0f;
        }
        
        if (_velocity.y > 0f)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 10f);
        }
        //facing left
        else if(_velocity.y < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 0f, -20f);
        }
    }
    
    
    private void FixedUpdate()
    {

        //update position
        Vector2 _position = _rigidbody.position;
        _position += _velocity * Time.fixedDeltaTime;
        
        //limit divers frame to the left (camera)
        Vector2 _leftSide = _camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 _rightSide = _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        _position.x = Mathf.Clamp(_position.x, _leftSide.x + 1.5f, _rightSide.x - 1.5f);
        _rigidbody.MovePosition(_position);
        
        //limit divers frame to the upper (camera)
        Vector2 _upperSide = _camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 _lowerSide = _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        _position.y = Mathf.Clamp(_position.y, _upperSide.y + 0.5f, _lowerSide.y - 0.5f);
        _rigidbody.MovePosition(_position);


        }
    
    //check if diver hit something
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        //check layer of collision object
        if (_collision.gameObject.layer != LayerMask.NameToLayer("PowerUp"))
        {
            //bumping into a brick should stop velocity
            if (transform.VectTest(_collision.transform, Vector2.up))
            {
                _velocity.y = 0f;
            }
        }
    }
}
