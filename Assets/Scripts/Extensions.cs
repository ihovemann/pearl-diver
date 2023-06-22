using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions 
{
    //Extensions script is used to detect collision with anything
    //Get correct layer for Raycast (not Diver themself)
    private static LayerMask _layerMask = LayerMask.GetMask("Default");
    
    public static bool Raycast(this Rigidbody2D _rigidbody, Vector2 _direction)
    {
        if (_rigidbody.isKinematic)
        {
            return false;
        }

        float _radius = 0.25f;
        float _distance = 0.375f;
        
        //do not collide with yourself with layerMAsk
        //get the information of what you hit
       RaycastHit2D _hit = Physics2D.CircleCast(_rigidbody.position, _radius, _direction.normalized,_distance, _layerMask);
       return _hit.collider != null && _hit.rigidbody != _rigidbody;
    }
    
    //check if how alike vectors are to see the direction between diver and collider e.g. bricks using dot product
    public static bool VectTest(this Transform transform, Transform other, Vector2 _directionTest)
    {
        Vector2 _direction = other.position - transform.position;
        // > 0.25 to check if we are moving upwards
        return Vector2.Dot(_direction.normalized, _directionTest) > 0.25f;
    }
     
    
}
