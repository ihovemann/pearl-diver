using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringPipe : MonoBehaviour
{
    //where do you end after exiting the pipe 
    public Transform _transform;
    //keys need to be pressed to actually enter pipe
    public KeyCode _enterPipe = KeyCode.S;
    
    //directions of diver 
    public Vector3 _directionIn = Vector3.down;
    public Vector3 _directionOut = Vector3.zero;
    
    
    //needs to actually stay on trigger 
    private void OnTriggerStay2D(Collider2D _other)
    {
        //diver can only enter certain pipes that have a connector 
        if (_transform != null && _other.CompareTag("Player"))
        {
            if (Input.GetKey(_enterPipe))
            {
                StartCoroutine(In(_other.transform));
            }
        }
    }
    
    //new
    private IEnumerator In(Transform _player)
    {
        //disable movement of diver
        _player.GetComponent<PlayerMovement>().enabled = false;
        //animate in direction you are entering
        Vector3 _startPos = transform.position + _directionIn;

        yield return Animate(_player, _startPos);

        //bool to check if we are underground after transform
        bool _under = _transform.position.y < 0f;
        
        //reference to camera
        Camera.main.GetComponent<CameraMovement>().CameraUnder(_under);
        if (_directionOut != Vector3.zero)
        {
            //set new position
            
            _player.position = _transform.position - (_directionOut * 2f);
            yield return Animate(_player, _transform.position + (_directionOut * 2f));
        }
        else //for a fixed point 
        {
            _player.position = _transform.position;
            _player.localScale = Vector3.one;
            
        }
        //enable movement of diver
        _player.GetComponent<PlayerMovement>().enabled = true;
        
    } 
    
    //new
    private IEnumerator Animate(Transform _player, Vector3 _end)
    {
        //starting time = 0
        float _xo = 0f;
        //time of animation
        float _duration = 1f;

        //get current position 
        Vector3 _start = _player.localPosition;

        //update animation as long as time is not up
        while (_xo < _duration)
        {
            float _percentage = _xo / _duration;
            //update position with linear interpolation between _start and _end and time 
            _player.localPosition = Vector3.Lerp(_start, _end, _percentage);
            
            //set scale to o
            _player.localScale = Vector3.zero;
            
            //update time passed
            _xo += Time.deltaTime;
            
            //wait for next frame to continue
            yield return null;
        }

        //make sure we are in the right position at the end
        _player.localPosition = _end;
        _player.localScale = Vector3.one;
    }
    
}
