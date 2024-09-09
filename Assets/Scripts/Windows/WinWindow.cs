using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinWindow : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private TMP_Text _text;
    public TMP_Text Text { get => _text; set => _text = value; }




    private void OnEnable()
    {
        _restartButton.onClick.AddListener(BindOnRestartClick);
        _menuButton.onClick.AddListener(BindOnMenuClick);
      
    }


    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(BindOnRestartClick);
        _menuButton.onClick.RemoveListener(BindOnMenuClick);
    }
    private void BindOnMenuClick()
    {
        SceneManager.LoadScene(0);
    }

    private void BindOnRestartClick()
    {
        SceneManager.LoadScene(1);
    }
}

