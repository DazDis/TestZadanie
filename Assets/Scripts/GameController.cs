using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Ball _ball;
    [SerializeField] private Platform _platform;

    private void OnEnable()
    {
        _inputManager.OnMouseClick.AddListener(BindOnMouseButtonClick);
        _inputManager.OnMouseMove.AddListener(BindOnMouseMove);
    }

    private void OnDisable()
    {
        _inputManager.OnMouseClick.RemoveListener(BindOnMouseButtonClick);
        _inputManager.OnMouseMove.AddListener(BindOnMouseMove);


    }

    private void BindOnMouseMove(Vector3 MousePosition)
    {
        _platform.transform.position = new Vector3(MousePosition.x, _platform.transform.position.y, _platform.transform.position.z);
    }

    public void BindOnMouseButtonClick()
    {

        if (!_ball.Active)
        {
            _ball.Push();
            

            _ball.Active = !_ball.Active;

        }
    }
}
