using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathZone : MonoBehaviour
{
    public UnityEvent EndOfGame;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball Ball = collision.gameObject.GetComponent<Ball>();
        if (Ball != null ) EndOfGame.Invoke();
    }
}
