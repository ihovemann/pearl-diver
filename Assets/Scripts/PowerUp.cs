using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //enumerations of items
    public enum Items
    {
        Pearl,
        Power
    }

    public Items _item;

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Player"))
        {
            PickUp(_other.gameObject);
        }
    }

    //what happens when you pick up corresponding item
    private void PickUp(GameObject _player)
    {
        switch (_item)
        {
            case Items.Power:
                _player.GetComponent<PlayerScript>().ChangeToRed();
                break;
            case Items.Pearl:
                GameManager._instance.AddPearl();
                break;
        }
        Destroy(gameObject);
    }
}
