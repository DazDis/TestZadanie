using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovementWindow : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _backButton;
    [SerializeField] private GameObject _okno1;
    [SerializeField] private GameObject _okno2;

    private void OnEnable()
    {
        _okno2.gameObject.SetActive(false);
        _exitButton.onClick.AddListener(BindOnExitClick);
        _nextButton.onClick.AddListener(BindOnNextClick);
        _backButton.onClick.AddListener(BindOnBackClick);

    }


    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(BindOnExitClick);
        _nextButton.onClick.RemoveListener(BindOnNextClick);
        _backButton.onClick.RemoveListener(BindOnBackClick);

    }


    private void BindOnNextClick()
    {
        _okno1.gameObject.SetActive(false);
        _okno2.gameObject.SetActive(true);
    }
    private void BindOnBackClick()
    {
        _okno1.gameObject.SetActive(true);
        _okno2.gameObject.SetActive(false);
    }

    private void BindOnExitClick()
    {
      
        SceneManager.LoadScene(0);
    }
}
