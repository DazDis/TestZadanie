using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    private Vector2 _speed = new Vector2(50,100);
    private Rigidbody2D _rigidbody2d;
    public GameObject Player;
    public bool Active = false;



    private void Start()
    {
        _rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
       

        if (!Active) 
        { 
            Vector3 NewPos = new Vector3(Player.transform.position.x, transform.position.y, 0);
            transform.position = NewPos;
           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        _speed.x *= -1; _speed.y *= -1;
        Push();
        Block Block = collision.gameObject.GetComponent<Block>();
        if (Block == null) return;
        else 
        {
            
            Block.GetDamage();
        }
    }

    internal void Push()
    {
        _rigidbody2d.AddForce(_speed);
    }
}
