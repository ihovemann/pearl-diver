using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfDeath : MonoBehaviour
{
    
    //zones where you die
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        //if palyer collides with point of death
        if (other.CompareTag("Player"))
        {
            //disable anything related to player
            other.gameObject.SetActive(false);
            GameManager._instance.LevelReset(2f);
        }
        else
        {
            
            //anything else than player just gets destroyed
            Destroy(other.gameObject);
        }
    }
}
