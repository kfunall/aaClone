using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // * References
    public static GameManager Instance = null;
    Animator cameraAnimator;
    // * Variables
    float rotationSpeed = 30f;
    int levelIndex = 1;
    bool gameOver = false;
    // * Properties
    public float RotationSpeed { get { return rotationSpeed; } private set { } }
    public int LevelIndex { get { return levelIndex; } private set { } }
    public bool GameEnded { get { return gameOver; } private set { } }
    // * Methods
    private void Awake() => SingletonGameManager();
    private void Start()
    {
        FindObjectOfType<Text>().text = levelIndex.ToString();
    }
    public void NextLevel()
    {
        Rotator rotator = FindObjectOfType<Rotator>();
        PinSpawner pinSpawner = FindObjectOfType<PinSpawner>();
        rotator.enabled = false;
        pinSpawner.enabled = false;
        StartCoroutine(ChangeLevel());
        rotator.enabled = true;
        pinSpawner.enabled = true;
    }
    public void GameOver()
    {
        gameOver = true;
        FindObjectOfType<Rotator>().enabled = false;
        FindObjectOfType<PinSpawner>().enabled = false;
        StartCoroutine(EndGame());
    }
    void SingletonGameManager()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
            Destroy(gameObject);
    }
    // * Coroutines
    IEnumerator EndGame()
    {
        cameraAnimator = FindObjectOfType<Animator>();
        cameraAnimator.SetTrigger("EndGame");
        yield return new WaitUntil(() => cameraAnimator.GetCurrentAnimatorStateInfo(0).IsName("EndGame"));
        levelIndex = 1;
        rotationSpeed = 30f;
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(0.1f);
        FindObjectOfType<Text>().text = levelIndex.ToString();
        gameOver = false;
    }
    IEnumerator ChangeLevel()
    {
        rotationSpeed += 10f;
        levelIndex++;
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(0.1f);
        FindObjectOfType<Text>().text = levelIndex.ToString();
    }
}