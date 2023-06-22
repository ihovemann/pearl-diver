using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevel : MonoBehaviour
{
    //change level when seashell castle is reached
    public int _level = 1;
    public int _world = 1;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //has to be triggered by player
        if (other.CompareTag("Player"))
        {
            GameManager._instance.LoadLevel(_world, _level);
        }
    }
}
