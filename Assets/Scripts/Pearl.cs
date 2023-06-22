using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pearl : MonoBehaviour
{
    
    private void Start()
    {
        GameManager._instance.AddPearl();
        StartCoroutine(Animate());
    }
    
    private IEnumerator Animate()
    {

        //make the block go uo a bit if its hit, calculate values
        Vector3 _currentPos = transform.localPosition;
        Vector3 _newPos = _currentPos + Vector3.up * 2f;
        
        //actually move the blocks
        yield return PosChange(_currentPos, _newPos);
        yield return PosChange(_newPos, _currentPos);
        
        Destroy(gameObject);

    }

    //move up and down
    private IEnumerator PosChange(Vector3 _start, Vector3 _end)
    {
        //starting time = 0
        float _xo = 0f;
        //time of animation
        float _duration = 1f;
        
        
        //update animation as long as time is not up
        while (_xo < _duration)
        {
            float _percentage = _xo / _duration;
            //update position with linear interpolation between _start and _end and time 
            transform.localPosition = Vector3.Lerp(_start, _end, _percentage);
            
            //update time passed
            _xo += Time.deltaTime;
            
            //wait for next frame to continue
            yield return null;
        }

        //make sure we are in the right position at the end
        transform.localPosition = _end;
    }
}
