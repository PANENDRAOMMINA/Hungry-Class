using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { GAME_ON, PAUSE, GAME_OVER, GAME_WIN }

public class GameManager : MonoBehaviour
{


    [SerializeField] private Slider progressBar;
    [SerializeField] private float progressSpeed;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float totalTime;


    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject gameWinCanvas;



    private GameState gameState = GameState.GAME_ON;

    public static GameManager _instance;

    public void Awake()
    {
        if (_instance == null)
            _instance = this;
        if (Time.timeScale == 0)
            Time.timeScale = 1f;
        StartCoroutine(CountDown(1));
    }

    public void Update()
    {
        switch (gameState)
        {
            case GameState.PAUSE:
                pauseCanvas.SetActive(true);
                Time.timeScale = 0f;
                break;
            case GameState.GAME_OVER:
                gameOverCanvas.SetActive(true);
                Time.timeScale = 0f;
                break;
            case GameState.GAME_WIN:
                gameWinCanvas.SetActive(true);
                Time.timeScale = 0f;
                break;

        }
        if (gameState == GameState.GAME_ON)
        {
            if (pauseCanvas.activeInHierarchy || gameOverCanvas.activeInHierarchy || gameWinCanvas.activeInHierarchy)
            {
                pauseCanvas.SetActive(false);
                gameOverCanvas.SetActive(false);
                gameWinCanvas.SetActive(false);
            }
        }

    }

    IEnumerator CountDown(int time)
    {
        scoreText.text = totalTime.ToString();
        yield return new WaitForSecondsRealtime(time);
        if (totalTime == 0)
            if (gameState == GameState.GAME_ON)
            {
                Debug.Log("You Lose");
                scoreText.text = totalTime.ToString();
                yield return new WaitForSecondsRealtime(time);
                if (totalTime < 1)
                {
                    SetGameState(GameState.GAME_OVER);
                }
                totalTime--;
                StartCoroutine(CountDown(1));
            }
       
    }

    public void SetGameState(GameState gameState)
    {
        _instance.gameState = gameState;

        if (OnGameStateChanged != null) // checks if the number of game states are more than one 
        {
            OnGameStateChanged(gameState);
        }
    }

    public void Increase_Progress()
    {

        if (gameState==GameState.GAME_ON)
        {
            progressBar.value += progressSpeed;

            if (progressBar.value == 1) // when a progress bar is filled , you win 
            {
                Debug.Log("You_Win");
                SetGameState(GameState.GAME_WIN);
            }
        }
    }
    public delegate void GameStateHandler(GameState gameState);
    public static event GameStateHandler OnGameStateChanged;
}

    

