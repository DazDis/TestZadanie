using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private BlockManager _blockManager;
    [SerializeField] private Color _color;
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
        int classnum = UnityEngine.Random.Range(0,4);
        Debug.Log(classnum);
        Class = classnum;
        Active = true;
        gameObject.SetActive(true);

        switch (Class)
        {
            case 0:
                {
                    _spriteRenderer.color = Color.yellow;
                    break;
                }
            case 1:
                {
                    _spriteRenderer.color = Color.green;
                    break;
                }
            case 2:
                {
                    _spriteRenderer.color = Color.red;
                    break;
                }
            case 3:
                {
                    _spriteRenderer.color = Color.black;
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
                    Active = false;
                    gameObject.SetActive(false);
                    break;
                }
            case 1:
                {
                    Active = false;
                    gameObject.SetActive(false);
                    break;
                }


            case 2:
                {
                    Active = false;
                    gameObject.SetActive(false);
                    break;
                }

            case 3:
                {
                    Active = false;
                    gameObject.SetActive(false);
                    break;
                }

            case 9: _blockManager.TouchedWall.Invoke(); break;


        }

    }
}
