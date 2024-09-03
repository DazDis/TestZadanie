using System;
using System.Drawing;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 Speed = new Vector2(50,150);
    public Rigidbody2D Rigidbody2d;
    public GameObject Player;
    public bool Active = false;
    public Vector2 size;
    private void Start()
    {
        Rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
       

        if (!Active) 
        { 
            Vector2 NewPos = new Vector2(Player.transform.position.x, 5f);
            transform.position = NewPos;
           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DeathZone deathZone = collision.gameObject.GetComponent<DeathZone>(); 
        if (deathZone == null) 
        {
            Block block = collision.gameObject.GetComponent<Block>();
            SpriteRenderer _spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            Vector2 Point = new Vector2(gameObject.transform.position.x - collision.collider.transform.position.x,
                                        gameObject.transform.position.y - collision.collider.transform.position.y);
            size = _spriteRenderer.bounds.size;

            if (block != null)
            {

                if ((size.x / 2) <= Math.Abs(Point.x))
                {
                    if ((Speed.x > 0 == Point.x < 0) || (Speed.x < 0 == Point.x > 0))
                        Speed.x *= -1;

                }
                if ((size.y / 2) <= Math.Abs(Point.y))
                {
                    if ((Speed.y > 0 == Point.y < 0) || (Speed.y < 0 == Point.y > 0))
                        Speed.y *= -1;

                }
                block.GetDamage();
                Push(Speed);
            }
            else
            {
                if ((size.x / 2) <= Math.Abs(Point.x))
                {
                    Speed.x *= -1;

                }
                if ((size.y / 2) <= Math.Abs(Point.y))
                {
                    Speed.x = 50 * (gameObject.transform.position.x - collision.collider.transform.position.x);
                    Speed.y = 100;
                }

                Speed.y += 100 - Math.Abs(Speed.x);
                Push(Speed);

            }
        }
        
    }

    internal void Push(Vector2 speed)
    {
        Rigidbody2d.velocity = new Vector2(0, 0);
        
        Rigidbody2d.AddForce(speed);
       
        
    }

    
}
