using System;
using System.Collections;
using System.Collections.Generic;
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
    public int Durability;
    public int Class;
    public Vector2 Size;
    public Vector2 Position;
    public bool Active = false;
    



    private void Start()
    {
        if (Class != 9) gameObject.SetActive(false);
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

                    _spriteRenderer.sprite = _sprite1;
                    break;
                }
            case 1:
                {
                    _spriteRenderer.sprite = _sprite2;
                    break;
                }
            case 2:
                {
                    _spriteRenderer.sprite = _sprite3;
                    break;
                }
            case 3:
                {
                    _spriteRenderer.sprite = _sprite4;
                    break;
                }
        }
    }
    public void GetDamage()
    {
        
        Durability -= 1;
        if (Durability <= 0) Remove();


    }


    public void Remove()
    {
        switch (Class)
        {
            case 0: 
                {
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

            case 9: _blockManager.TouchedWall.Invoke(); break;


        }

    }
}
