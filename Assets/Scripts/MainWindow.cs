using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainWindow : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _movementButton;
    [SerializeField] private Button _exitButton;
    // Start is called before the first frame update
    private void OnEnable()
    {
        _startButton.onClick.AddListener(BindOnStartButtonPressed);
        _movementButton.onClick.AddListener(BindOnMovementButtonPressed);
        _exitButton.onClick.AddListener(BindOnExitButtonPressed);
    }


    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(BindOnStartButtonPressed);
        _movementButton.onClick.RemoveListener(BindOnMovementButtonPressed);
        _exitButton.onClick.RemoveListener(BindOnExitButtonPressed);

    }

    private void BindOnStartButtonPressed()
    {
        SceneManager.LoadScene(1);
    }
    private void BindOnMovementButtonPressed()
    {
        throw new NotImplementedException();
    }
    private void BindOnExitButtonPressed()
    {
        throw new NotImplementedException();
    }

}
