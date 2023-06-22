using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    //define speed
    [SerializeField] private float _bulletSpeed = 8f;

    void Update()
    {
        //move bullet
        transform.Translate(Vector3.right * _bulletSpeed * Time.deltaTime);
    }
    
    //remove object when invisible
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
