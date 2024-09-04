using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField] private TMP_Text _textScore;
    [SerializeField] private TMP_Text _textZvanie;
    [SerializeField] private TMP_Text _textSnaryadi;
    public int Score;
    public int Health;
    private Vector3 _startposition = new Vector3(-1, -5, 0);

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
        Health--;
        _ball.Active = false;
        _ball.Rigidbody2d.velocity = new Vector2(0, 0);
        _ball.Speed = new Vector2(100, 250);
        if (Health <= 0)
        {
            EndOfGame();
        }
        _textSnaryadi.text = "Snaryadi: " + Health;

    }

    private void SpawnBlock()
    {
        
        int num = UnityEngine.Random.Range(0, 30);
        for (int i = 0; i < 3; i++)
        {
            if (blocks[num].Active)
            {
                num = UnityEngine.Random.Range(0, 30);
                break;
            }
        }
        blocks[num].ChangeType();

    }
    public void AddScore(int score)
    {
        Score += score;
        _textScore.text = "Poteri: " + Score.ToString();

        if (Score < 50)
            _textZvanie.text = "ZVanie: Sergant";
        else if (Score > 50 && Score < 150)
            _textZvanie.text = "ZVanie: Leitenant";
        else if (Score > 150 && Score < 800)
            _textZvanie.text = "ZVanie: Polkovnik";
        else if (Score > 800)
            _textZvanie.text = "ZVanie: General";
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

