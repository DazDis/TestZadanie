using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private BlockManager _blockManager;
    [SerializeField] private Sprite _sprite1;
    [SerializeField] private Sprite _sprite2;
    [SerializeField] private Sprite _sprite3;
    [SerializeField] private Sprite _sprite4;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _color = Color.white;

    private float _maxDurability;

    public float Durability;
    public int Class;
    public Vector2 Size;
    public Vector2 Position;
    public bool Active = false;

    public UnityEvent AddSpeed = new UnityEvent();
    public UnityEvent <int> AddBlocks =new UnityEvent<int>();
    public UnityEvent PlaySound = new UnityEvent();
    public UnityEvent HitSound = new UnityEvent();
    private void Start()
    {
       gameObject.SetActive(false);
    }
    public void ChangeType()
    {
        if (Class != 9) 
        { 
            int classnum = UnityEngine.Random.Range(0,4);
        
            Class = classnum;
            Active = true;
            gameObject.SetActive(true);
        }
        switch (Class)
        {
            case 0:
                {
                    Durability = 1;
                    _maxDurability = 1;
                    _spriteRenderer.sprite = _sprite1;
                    break;
                }
            case 1:
                {
                    Durability = 2;
                    _maxDurability = 2;
                    _spriteRenderer.sprite = _sprite2;
                    break;
                }
            case 2:
                {
                    Durability = 1;
                    _maxDurability = 1;
                    _spriteRenderer.sprite = _sprite3;
                    break;
                }
            case 3:
                {
                    Durability = 3;
                    _maxDurability = 3;
                    _spriteRenderer.sprite = _sprite4;
                    break;
                }
        }
        _color.a = Durability / _maxDurability;
        
        _spriteRenderer.color = _color;
    }
    public void GetDamage()
    {
       
        Durability--;
        _color.a = Durability / _maxDurability;
        _spriteRenderer.color = _color;
       


        if (Durability <= 0)
        {
            
            Remove();
            PlaySound.Invoke();
        }
        else HitSound.Invoke();


    }


    public void Remove()
    {
        switch (Class)
        {
            case 0: 
                {
                    AddBlocks.Invoke(1);
                    _blockManager.AddScore(1);
                    Active = false;
                    gameObject.SetActive(false);
                    break;
                }
            case 1:
                {
                    _blockManager.AddScore(5);
                    Active = false;
                    gameObject.SetActive(false);
                    break;
                }


            case 2:
                {
                    AddSpeed.Invoke();
                    _blockManager.AddScore(10);
                    Active = false;
                    gameObject.SetActive(false);
                    break;
                }

            case 3:
                {
                    _blockManager.AddScore(30);
                    Active = false;
                    gameObject.SetActive(false);
                    break;
                }

            


        }

    }
}
