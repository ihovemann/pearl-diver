using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HitBlocks : MonoBehaviour
{
    //set mystery block to empty block, need sprite of empty block
    public GameObject _item;
    public Sprite _emptyBlock;
    private int _numbHits = 0;
    private bool _inAnimation;
    
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        //can only be hit if its not currently in animation
        if (_numbHits != 1 && !_inAnimation && _collision.gameObject.CompareTag("Player"))
        {
            //check if diver hits from below
            if (_collision.transform.VectTest(transform, Vector2.up))
            {
                Hit();
            }
        }
    }

    private void Hit()
    {

        SpriteRenderer _spriteRenderer = GetComponent<SpriteRenderer>();
        
        //set down number of hit 
        _numbHits++;
        //if it was hit one time change sprite to empty block
        if (_numbHits == 1)
        {
            _spriteRenderer.sprite = _emptyBlock;
        }

        //check that item really exists to avoid error
        if (_item != null)
        {
            //Instantiate new item, no need for rotation -> Quaternion.identity
            Instantiate(_item, transform.position, Quaternion.identity);
        }
        //start animation
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        _inAnimation = true;

        //make the block go uo a bit if its hit, calculate values
        Vector3 _currentPos = transform.localPosition;
        Vector3 _newPos = _currentPos + Vector3.up * 0.3f;
        
        //actually move the blocks
        yield return PosChange(_currentPos, _newPos);
        yield return PosChange(_newPos, _currentPos);
        _inAnimation = false;

    }

    //move up and down
    private IEnumerator PosChange(Vector3 _start, Vector3 _end)
    {
        //starting time = 0
        float _xo = 0f;
        //time of animation
        float _duration = 0.2f;
        
        
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
