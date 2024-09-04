using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private BlockManager _blockManager;
    public void TouchWall()
    {
        
        Debug.Log("AAAAAAAAAAAAAAAAA");

       
        _blockManager.TouchedWall.Invoke();
       
        
    }
}
