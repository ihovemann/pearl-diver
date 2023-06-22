using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    //under bricks use differnt camera settings
    public float _height = 6.5f;
    public float _underHeight = -6f;

    public float _underX = 30f;

    private Transform _player;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
    } 

    private void LateUpdate()
    {
        //get camera position
        Vector3 _cameraPosition = transform.position;
        
        //Camera can only go right not left, limited to player position
        _cameraPosition.x = Mathf.Max(_cameraPosition.x, _player.position.x);
        transform.position = _cameraPosition;
    }

    public void CameraUnder(bool _under)
    {
        //get cam position
        Vector3 _camPos = transform.position;
        //if we are underground use under height otherwise use height
        _camPos.y = _under ? _underHeight : _height;
        transform.position = _camPos;
        //if we are under change x position to have full screen of under again
        if (_under)
        {
            _camPos.x = _underX;
            transform.position = _camPos;
        }
        

    }
}
