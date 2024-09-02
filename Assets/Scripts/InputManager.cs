using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent OnMouseClick;
    public UnityEvent<Vector3> OnMouseMove = new UnityEvent<Vector3>();
    private void Update()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        OnMouseMove.Invoke(mousePosition);


        if (Input.GetButtonDown("Fire1"))
        {
            OnMouseClick.Invoke();
            
        }


    }




}
