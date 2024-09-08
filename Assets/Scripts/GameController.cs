using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    [SerializeField] private AudioClip StandartClip;
    [SerializeField] private AudioClip RemoveClip;
    public AudioSource AudioSource;
   

    public int Score;
    public int Health;


    public List<Block> blocks = new List<Block>();

    private void OnApplicationFocus(bool focus)
    {
            Cursor.visible = !focus;

    }
    private void Awake()
    {
       blocks = new List<Block>(FindObjectsOfType<Block>());
       
    }
    private void OnEnable()
    {
        
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].AddBlocks.AddListener(AddBlocks) ;
            blocks[i].AddSpeed.AddListener(AddSpeed);
            blocks[i].PlaySound.AddListener(PlaySound);
            blocks[i].HitSound.AddListener(HitSound);

        }


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

        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].AddBlocks.RemoveListener(AddBlocks);
            blocks[i].AddSpeed.RemoveListener(AddSpeed);
            blocks[i].PlaySound.AddListener(PlaySound);
            blocks[i].HitSound.AddListener(HitSound);


        }
    }
    private void Start()
    {
        AddBlocks(5);
    }

    private void HitSound()
    {
        AudioSource.PlayOneShot(RemoveClip, 1f);

    }

    private void PlaySound()
    {

        AudioSource.PlayOneShot(StandartClip, 1f);
    }

    private void BindOnMouseMove(Vector3 MousePosition)
    {
        _platform.SetPosition(MousePosition.x);
        
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
        _ball.Speed = new Vector2(50, 150);
        _ball.MaxSpeed = new Vector2(200, 400);
        if (Health <= 0)
        {
            EndOfGame();
        }
        _textSnaryadi.text = "Snaryadi: " + Health;

    }

    private void SpawnBlock()
    {
        
        if (blocks.Count == 0) { return;}
        int num = UnityEngine.Random.Range(0, blocks.Count);
        for (int i = 0; i < 3; i++)
        {
            if (!blocks[num].Active)
            {
                break;
            }
            num = UnityEngine.Random.Range(0, blocks.Count);
        }
        blocks[num].ChangeType();

    }
    public void AddScore(int score)
    {
        Score += score;
        _textScore.text = "Ochki: " + Score.ToString();

        if (Score < 50)
            _textZvanie.text = "Level: Noob";
        else if (Score > 50 && Score < 150)
            _textZvanie.text = "Level: Norm";
        else if (Score > 150 && Score < 700)
            _textZvanie.text = "Level: Pro";
        else if (Score > 700 && Score < 1000)
            _textZvanie.text = "Level: Legenda";
        
        if (blocks.Count == 0)
        {
            _ball.Active = false;
            Cursor.visible = true;
            Instantiate(_winWindow);
            
        }
    }
    private void AddSpeed()
    {
        _ball.Speed *= 2;
    }

    public void AddBlocks(int Amount)
    {
        for (int i = 0;i < Amount;i++)
        {
            SpawnBlock();
        }
    }
    private void EndOfGame()
    {
        Cursor.visible = true;
        Instantiate(_looseWindow);
    }

    
}

