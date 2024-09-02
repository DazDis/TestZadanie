using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int Durability;
    public int Class;

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
