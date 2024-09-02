using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
      
        
            Debug.Log(gameObject.transform.position.x - collision.collider.transform.position.x);
           
        
    }
}
