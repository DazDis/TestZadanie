using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int Durability;
    public int Class;
    public Vector2 size;


    private SpriteRenderer _spriteRenderer;



   
    public void GetDamage()
    {
        
        Durability -= 1;
        if (Durability <= 0) Remove();


    }


    public void Remove()
    {
        switch (Class)
        {
            case 0: Destroy(gameObject); break;

        }
    }
}
