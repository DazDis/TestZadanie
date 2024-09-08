using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainWindow : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _movementButton;
    [SerializeField] private Button _exitButton;
    
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
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }
    private void BindOnMovementButtonPressed()
    {
        SceneManager.LoadScene(2);
    }
    private void BindOnExitButtonPressed()
    {
        Application.Quit();
    }

}
