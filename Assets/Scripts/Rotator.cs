using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    int pinCount = 0;
    private void Update()
    {
        transform.Rotate(0f, 0f, GameManager.Instance.RotationSpeed * Time.deltaTime);
        if (pinCount == GameManager.Instance.LevelIndex * 2 && !GameManager.Instance.GameEnded && GameManager.Instance.LevelIndex < 10)
            GameManager.Instance.NextLevel();
        else if (pinCount == 20 && !GameManager.Instance.GameEnded)
            GameManager.Instance.NextLevel();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        pinCount++;
    }
}