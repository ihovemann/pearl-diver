using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{

    
    public Sprite _flatSprite;

    private void OnCollisionEnter2D(Collision2D _collision)
    { 
        //Hit by bullet jelly dies
        if (_collision.gameObject.CompareTag("Bullet"))
        {
            JellyDeath();
            Destroy(_collision.gameObject);

            //Player hit Player Hit is called from Player Script
        } else if (_collision.gameObject.CompareTag("Player"))
        {
            PlayerScript _player = _collision.gameObject.GetComponent<PlayerScript>();
            if (_player._red)
            {
                JellyDeath();
                _player.Hit();
            }
            else
            {
                _player.Hit();    
            }
            
        }
    }

    //function to destroy jelly when hit by shell
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shell"))
        {
            Hit();
        }
    }

    private void JellyDeath()
    {
        
        //enabled = false for collider, animation and movement
        GetComponent<Collider2D>().enabled = false;
        GetComponent<OtherMovement>().enabled = false;
        GetComponent<SpriteAnimation>().enabled = false;
        //change Sprite
        GetComponent<SpriteRenderer>().sprite = _flatSprite;
        //destroy jelly after some offset
        Destroy(gameObject, 0.5f);
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
}
