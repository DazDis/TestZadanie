using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D collision)
    {
        Ball Ball = collision.gameObject.GetComponent<Ball>();
        
        Vector2 vector2 = new Vector2((gameObject.transform.position.x - collision.collider.transform.position.x)*-50, 100);
        Ball.Push(vector2);
       
    }
}
