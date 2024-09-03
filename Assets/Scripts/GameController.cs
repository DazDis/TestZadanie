using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GameController : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Ball _ball;
    [SerializeField] private Platform _platform;
    [SerializeField] private DeathZone _deathZone;
    [SerializeField] private WinWindow _winWindow;
    [SerializeField] private MainWindow _mainWindow;
    [SerializeField] private LooseWindow _looseWindow;
    [SerializeField] private BlockManager _blockManager;

    public int health;
    private Vector3 _startposition = new Vector3 (-1, -5, 0);

    //public List<Block> blocks = new List<Block>();
    Block[] blocks;
    private void OnEnable()
    {
        blocks = FindObjectsOfType<Block>();
        _inputManager.OnMouseClick.AddListener(BindOnMouseButtonClick);
        _inputManager.OnMouseMove.AddListener(BindOnMouseMove);
        _deathZone.Respawn.AddListener(Respawn);
        _blockManager.TouchedWall.AddListener(SpawnBlock);
    }

    

    private void OnDisable()
    {
        _inputManager.OnMouseClick.RemoveListener(BindOnMouseButtonClick);
        _inputManager.OnMouseMove.RemoveListener(BindOnMouseMove);
        _deathZone.Respawn.RemoveListener(Respawn);
        _blockManager.TouchedWall.RemoveListener(SpawnBlock);
    }

    private void BindOnMouseMove(Vector3 MousePosition)
    {
        _platform.transform.position = new Vector3(MousePosition.x, _platform.transform.position.y, _platform.transform.position.z);
    }

    public void BindOnMouseButtonClick()
    {

        if (!_ball.Active)
        {
            _ball.Push(_ball.Speed);
            

            _ball.Active = !_ball.Active;

        }
    }
    private void Respawn()
    {
        
        _ball.Active = false;
        _ball.Rigidbody2d.velocity = new Vector2(0, 0);
        _ball.Speed = new Vector2(50, 150);
        EndOfGame();

    }

    private void SpawnBlock()
    {
        int num = UnityEngine.Random.Range(0, 45);
        while (blocks[num].Active) { num = UnityEngine.Random.Range(0, 45); }
        blocks[num].ChangeType();

    }
    private void EndOfGame()
    {
        Instantiate(_looseWindow);
    }

    public void BonusFlomBlock()
    {
        throw new NotImplementedException();
    }
}

