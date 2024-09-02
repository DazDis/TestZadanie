using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 _speed = new Vector2(50,100);
    public Rigidbody2D _rigidbody2d;
    public GameObject Player;
    public bool Active = false;
    private Vector2 _multiplier = new Vector2(1,1);


    private void Start()
    {
        _rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
       

        if (!Active) 
        { 
            Vector2 NewPos = new Vector2(Player.transform.position.x, transform.position.y);
            transform.position = NewPos;
           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        _speed.x *= -1; _speed.y *= -1;
        
        Block Block = collision.gameObject.GetComponent<Block>();
        if (Block == null) return;
        else 
        {
            Push(_speed);
            Block.GetDamage();
        }
    }

    internal void Push(Vector2 speed)
    {
        _rigidbody2d.AddForce(speed);
        Debug.Log(speed);
    }

    
}
