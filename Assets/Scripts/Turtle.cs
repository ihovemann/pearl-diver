using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{

    public Sprite _ShellSprite;
    public float _speedShell = 6f;
    private bool _inShell;
    private bool _moveShell;
    
    

    private void OnCollisionEnter2D(Collision2D _collision)
    { 
        //Hit by bullet turtle goes into shell
        if (!_inShell && _collision.gameObject.CompareTag("Bullet"))
        {
            TurtleDeath();
            Destroy(_collision.gameObject);
            
            //Player hit: Player Hit is called from Player Script
        } else if (!_inShell && _collision.gameObject.CompareTag("Player"))
        {
            PlayerScript _player = _collision.gameObject.GetComponent<PlayerScript>();
            //if player is red turtle gets hit and player as well
            if (_player._red)
            {
                Hit();
                _player.Hit();
            }
            //if player is green only player gets hit
            else
            {
                //only hit player
                _player.Hit();
            }
        }
    }

    //movement of turtle in shell
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_inShell && other.CompareTag("Player"))
        {
            //if its not moving shell is set into motion
            if (!_moveShell)
            {
                //substrate positions to get direction
                Vector2 _direction = new Vector2(transform.position.x - other.transform.position.x, 0f);
                MoveShell(_direction);
            }
            //if it is already moving player gets hit 
            else
            {
                PlayerScript _player = other.gameObject.GetComponent<PlayerScript>();
                //if player is red turtle gets hit and player as well
                if (_player._red)
                {
                    Hit();
                    _player.Hit();
                }
                //if player is green only player gets hit
                else
                {
                    _player.Hit();
                }
                
            }
        }
        //turtle hitting turtle 
        else if(!_inShell && other.gameObject.layer == LayerMask.NameToLayer("Shell"))
        {
            Hit();
        }
    }

    private void TurtleDeath()
    {
        _inShell = true;
        //Turtle remains in game 
        GetComponent<OtherMovement>().enabled = false;
        GetComponent<SpriteAnimation>().enabled = false;
        //change Sprite
        GetComponent<SpriteRenderer>().sprite = _ShellSprite;
    }

    private void MoveShell(Vector2 _direction)
    {
        _moveShell = true;
        //move again isKinematic == false physic engine uses physics
        GetComponent<Rigidbody2D>().isKinematic = false;
        
        //reactive movement from other movement with given direction
        OtherMovement _movement = GetComponent<OtherMovement>();
        //normalize because its a direction not velocity 
        _movement._direction = _direction.normalized;
        //set speed
        _movement._speed = _speedShell;
        //enable movement
        _movement.enabled = true;
        
        //change layer of turtle so it can hit jelly
        gameObject.layer = LayerMask.NameToLayer("Shell");
    }
    
    private void Hit()
    {
        //disable walking animation
        GetComponent<SpriteAnimation>().enabled = false;
        //enable death animation
        GetComponent<Death>().enabled = true;
        //DestroyObject
        Destroy(gameObject, 2f);
    }
    
    //if turtle in shell moves and invisible make it disappear
    private void OnBecameInvisible()
    {
        if (_moveShell)
        {
            Destroy(gameObject);
        }
    }
}
