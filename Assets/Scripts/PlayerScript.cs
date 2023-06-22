using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    //sprite for sprite state
    public SpriteRendererPlayer _greenRendererPlayer;

    public SpriteRendererPlayer _redRendererPlayer;

    private SpriteRendererPlayer _currentRenderer;

    private Death _death;
    
    //check in what stage diver is in 
    public bool _red => _redRendererPlayer.enabled;
    public bool _dead => _death.enabled;
    
    private void Awake()
    {
        _death = GetComponent<Death>();
        //set green sprite
        _currentRenderer = _greenRendererPlayer;
    }

    //check if diver was hit by anything
    public void Hit()
    {
        if (!_dead)
        {
            if (_red)
            {
                //just change to green and not dead
                ChangeToGreen();
            }
            else
            {
                //if diver is green then die
                ChangeToDead();
            }
        }
 
    }

    public void ChangeToRed()
    {
        //change sprites
        _greenRendererPlayer.enabled = false;
        _redRendererPlayer.enabled = true;
        
        //set current active sprite
        _currentRenderer = _redRendererPlayer;
    }
    private void ChangeToGreen()
    {
        //change sprites
        _greenRendererPlayer.enabled = true;
        _redRendererPlayer.enabled = false;
        
        //set current active sprite
        _currentRenderer = _redRendererPlayer;
    }

    private void ChangeToDead()
    {
        _greenRendererPlayer.enabled = false;
        _redRendererPlayer.enabled = false;
        _death.enabled = true;
        
        GameManager._instance.LevelReset(2f);
    }
}
