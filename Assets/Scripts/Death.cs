using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Sprite _death;
    public SpriteRenderer _spriteRenderer;
    
    //reset sprite to default sprite
    private void Reset()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //be able to enable sprites
    private void OnEnable()
    {
        SpriteUpdate();
        StopPhysics();
        StartCoroutine(DeathAnimate());
    }

    private void SpriteUpdate()
    {
        _spriteRenderer.enabled = true;
        //higher order to show actual animation
        _spriteRenderer.sortingOrder = 10;
        
        //null check: do we have a sprite for death?
        if (_death != null)
        {
            _spriteRenderer.sprite = _death;
        } 
        
    }

    //stop the physics of died object
    private void StopPhysics()
    {
        //create array to get all colliders
        Collider2D[] _colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in _colliders)
        {
            collider.enabled = false;
        }
        
        //physics will not affect that object
        GetComponent<Rigidbody2D>().isKinematic = true;
        
        //Disable movements of respective entity
        //get references to corresponding movement scripts

        PlayerMovement _playerMovement = GetComponent<PlayerMovement>();
        OtherMovement _otherMovement = GetComponent<OtherMovement>();

        if (_playerMovement != null)
        {
            _playerMovement.enabled = false;
        }

        if (_otherMovement != null)
        {
            _otherMovement.enabled = false;
        }
    }

    private IEnumerator DeathAnimate()
    {
       //starting time = 0
        float _xo = 0f;
        //time of animation
        float _duration = 2f;

        //float _up = 10f;
        float _grav = -30f;
        
        Vector3 _velocity = Vector3.up; //*_up
        
        //update animation as long as time is not up
        while (_xo < _duration)
        {
            //update position
            transform.position += _velocity * Time.deltaTime;
            
            _velocity.y += _grav * Time.deltaTime;
            //update time passed
            _xo += Time.deltaTime;
            
            //wait for next frame to continue
            yield return null;
        }
    }
}
