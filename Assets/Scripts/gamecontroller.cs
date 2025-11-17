using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamecontroller : MonoBehaviour
{
    [SerializeField] GameObject GoalUI = default;
    [SerializeField] GameObject StartUI = default;
    [SerializeField] GameObject PlayingUI = default;
    [SerializeField] GameObject GameoverUI = default;
    [SerializeField] Playercontroller _playerController;
    [SerializeField] Gameover gameover;
    bool _isStarting;
    bool _isGoal;
    bool _isGameover;

    private enum gamestate
    {
        start,
        playing,
        gameover,
        goal
    }
    gamestate _gameState;
    private void Start()
    {
        _gameState = gamestate.start;
    }
    private void Update()
    {
        _isGoal = _playerController.IsGoal;
        _isGameover = gameover.giveIsOver;
        switch (_gameState)
        {
            case gamestate.start:

                if (!_isStarting)
                {
                    SetStart();
                }
                
                if (Input.anyKeyDown)
                {
                    _isStarting = false;
                    StartUI.SetActive(false);
                    Time.timeScale = 1;
                    _gameState = gamestate.playing;

                }
                break;

            case gamestate.playing:
                PlayingSet();
                if (_isGoal)
                {
                    _gameState = gamestate.goal;
                }
                if (_isGameover)
                {
                    _gameState = gamestate.gameover;
                }
                break;

            case gamestate.gameover:
                GameoverSet();
                if (Input.anyKeyDown)
                {
                    SceneManager.LoadScene("Title");
                }
                break;

            case gamestate.goal:
                GoalSet();
                if (Input.anyKeyDown)
                {
                    SceneManager.LoadScene("Title");
                }
                break;
        }

    }
    private void SetStart()
    {
        StartUI.SetActive(true);
        _isStarting = true;
        Time.timeScale = 0;
    }
    private void PlayingSet()
    {
        
    }
    private void GameoverSet()
    {
        GameoverUI.SetActive(true);
        Time.timeScale = 0;
    }
    private void GoalSet()
    {
        GoalUI.SetActive(true);
    }
}
