using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D collision)
    {
        Ball Ball = collision.gameObject.GetComponent<Ball>();
        
        
       // Ball.Speed.x *= -(gameObject.transform.position.x - collision.collider.transform.position.x);
        //Ball.Push(Ball.Speed);
       
    }
}
