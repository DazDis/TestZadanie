using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Ball _ball;
    [SerializeField] private Platform _platform;
    [SerializeField] private DeathZone _deathZone;

    private Vector2 _firstMovement = new Vector2 (50, 100);  

    private void OnEnable()
    {
        _inputManager.OnMouseClick.AddListener(BindOnMouseButtonClick);
        _inputManager.OnMouseMove.AddListener(BindOnMouseMove);
        _deathZone.EndOfGame.AddListener(EndOfGame);

    }


    private void OnDisable()
    {
        _inputManager.OnMouseClick.RemoveListener(BindOnMouseButtonClick);
        _inputManager.OnMouseMove.RemoveListener(BindOnMouseMove);
        _deathZone.EndOfGame.RemoveListener(EndOfGame);

    }

    private void BindOnMouseMove(Vector3 MousePosition)
    {
        _platform.transform.position = new Vector3(MousePosition.x, _platform.transform.position.y, _platform.transform.position.z);
    }

    public void BindOnMouseButtonClick()
    {

        if (!_ball.Active)
        {
            _ball._rigidbody2d.AddForce(_firstMovement);
            

            _ball.Active = !_ball.Active;

        }
    }
    private void EndOfGame()
    {
        throw new NotImplementedException();
    }
}
