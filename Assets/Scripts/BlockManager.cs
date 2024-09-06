using UnityEngine;
using UnityEngine.Events;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private GameController controller;
    public UnityEvent TouchedWall;


    public void AddScore(int score)
    {
        controller.AddScore(score);
    }
}
