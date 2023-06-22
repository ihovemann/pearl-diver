using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        Rigidbody2D _rigidbody = GetComponent<Rigidbody2D>();
        CircleCollider2D _circleCollider = GetComponent<CircleCollider2D>();
        BoxCollider2D _boxCollider = GetComponent<BoxCollider2D>();
        SpriteRenderer _spriteRenderer = GetComponent<SpriteRenderer>();

        
        //disable all components to be able to have a smooth animation
        _rigidbody.isKinematic = true;
        _circleCollider.enabled= false;
        _boxCollider.enabled = false;
        _spriteRenderer.enabled = false;

        yield return new WaitForSeconds(0.2f);
        
        //enable sprite again after block animation is finished
        _spriteRenderer.enabled = true;
        
        Vector3 _currentPos = transform.localPosition;
        Vector3 _newPos = _currentPos + Vector3.up;
        
        //starting time = 0
        float _xo = 0f;
        //time of animation
        float _duration = 0.2f;
        
        
        //update animation as long as time is not up
        while (_xo < _duration)
        {
            float _percentage = _xo / _duration;
            //update position with linear interpolation between _start and _end and time 
            transform.localPosition = Vector3.Lerp(_currentPos, _newPos, _percentage);
            
            //update time passed
            _xo += Time.deltaTime;
            
            //wait for next frame to continue
            yield return null;
        }

        transform.localPosition = _newPos;
        //enable all components to be able to have a smooth animation
        _rigidbody.isKinematic = false;
        _circleCollider.enabled= true;
        _boxCollider.enabled = true;

        

    }
}
