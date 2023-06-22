using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererPlayer : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;
    //reference to movement in player script
    private PlayerMovement _movement;
    
    //public variables for sprites
    public Sprite _idle;
    
    public SpriteAnimation _swim;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        //Player Movement is attached to parent of diver green and red
        _movement = GetComponentInParent<PlayerMovement>();
    }

    private void OnEnable()
    {
        _spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        _spriteRenderer.enabled = false;
        _swim.enabled = false;
    }

    private void LateUpdate()
    {
        _swim.enabled = _movement._swimming;
        
        //if diver is not swimming stop movement and go back to first state 
        if (!_movement._swimming )
        {
            _spriteRenderer.sprite = _idle;
        }
    }
}
