using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 Speed = new Vector2(50,150);
    public Vector2 MaxSpeed = new Vector2(200, 400);
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
                    MaxSpeed.x *= -1;
                }
                if ((size.y / 2) <= Math.Abs(Point.y))
                {
                    Speed.x = 50 * (gameObject.transform.position.x - collision.collider.transform.position.x);
                    Speed.y *= -1;
                    MaxSpeed.y *= -1;
                }

               
                Push(Speed);
                


            }
            else if (wall != null)
            {
                if (wall.side)
                {
                    Speed.x*=-1;
                    MaxSpeed.x *= -1;
                }
                else
                {
                    Speed.y *= -1;
                    MaxSpeed.y *= -1;
                }
                wall.TouchWall();
                Push(Speed);
            }
                
            else
            {
                if ((size.x / 2) <= Math.Abs(Point.x))
                {
                    if ((Speed.x > 0 == Point.x < 0) || (Speed.x < 0 == Point.x > 0))
                    {
                        Speed.x *= -1;
                        MaxSpeed.x *= -1;
                    }
                    Debug.Log("Sleva/Sprava");

                }
                if ((size.y / 2) <= Math.Abs(Point.y))
                {
                    if ((Speed.y > 0 == Point.y < 0) || (Speed.y < 0 == Point.y > 0))
                    {
                        Speed.y *= -1;
                        MaxSpeed.y *= -1;

                    }


                    Debug.Log("Vniz/Vverh");
                }
                else
                {
                    Debug.Log(size.y / 2);
                    Debug.Log(Math.Abs(Point.y));

                }

                if (block != null)
                {
                    block.GetDamage();
                    
                }
              
                Push(Speed);


            }
        }
        
    }

    internal void Push(Vector2 speed)
    {

        if (Math.Abs(speed.x) > Math.Abs(MaxSpeed.x))
        {
            speed.x = MaxSpeed.x;
            Speed.x = MaxSpeed.x;
        }
        if (Math.Abs(speed.y) > Math.Abs(MaxSpeed.y))
        {
            speed.y = MaxSpeed.y;
            Speed.y = MaxSpeed.y;
        }
        Rigidbody2d.velocity = new Vector2(0, 0);
        
        Rigidbody2d.AddForce(speed);

        
    }

    
}
