using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovementWindow : MonoBehaviour
{
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(BindOnExitClick);
        
    }


    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(BindOnExitClick);
    }
    private void BindOnExitClick()
    {
      
        SceneManager.LoadScene(0);
    }
}
