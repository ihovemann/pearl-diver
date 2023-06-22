using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    //array with different animations
    public Sprite[] _sprites;
    //framerate 6 frames in a second 
    public float _framerate = 1f / 6f;

    //reference to sprite renderer
    private SpriteRenderer _spriteRenderer;
    
    //need the index of current frame
    private int _frame;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(Animate), _framerate, _framerate);
        
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    
    //change animation
    private void Animate()
    {
        //change frames for illusion of moving
        _frame++;
        if (_frame >= _sprites.Length)
        {
            _frame = 0;
        }

        //check if index is out of bounce
        if (_frame >= 0 && _frame < _sprites.Length)
        {
            _spriteRenderer.sprite = _sprites[_frame];
        }
        
    }
}
