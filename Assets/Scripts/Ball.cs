using System;
using System.Drawing;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 Speed = new Vector2(100,250);
    public Rigidbody2D Rigidbody2d;
    public GameObject Player;
    public bool Active = false;
    public Vector2 size;
    private Vector2 _position;
    private void Start()
    {
        _position = transform.position;
        Rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
       

        if (!Active) 
        { 
            Vector2 NewPos = new Vector2(Player.transform.position.x, _position.y);
            transform.position = NewPos;
           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DeathZone deathZone = collision.gameObject.GetComponent<DeathZone>(); 
        if (deathZone == null) 
        {
            Block block = collision.gameObject.GetComponent<Block>();
            Platform platform = collision.gameObject.GetComponent<Platform>();
            Wall wall = collision.gameObject.GetComponent<Wall>();
            SpriteRenderer _spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            Vector2 Point = new Vector2(gameObject.transform.position.x - collision.collider.transform.position.x,
                                        gameObject.transform.position.y - collision.collider.transform.position.y);
            size = _spriteRenderer.bounds.size;

            if (platform != null)
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

                Speed.y += 200 - Math.Abs(Speed.x);
                Push(Speed);


            }
            else
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
                if (block != null)
                {
                    block.GetDamage();
                    
                }
                if (wall != null)
                {
                    wall.TouchWall();
                }
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
