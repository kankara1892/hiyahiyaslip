using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamecontroller : MonoBehaviour
{
    [SerializeField] GameObject GoalUI = default;
    [SerializeField] GameObject StartUI = default;
    [SerializeField] GameObject PlayingUI = default;
    [SerializeField] GameObject GameoverUI = default;
    bool _isStarting;
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
        switch (_gameState)
        {
            case gamestate.start:

                if (!_isStarting)
                {
                    SetStart();
                }
                
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    _isStarting = false;
                    StartUI.SetActive(false);
                    Time.timeScale = 1;
                    _gameState = gamestate.playing;

                }
                break;

            case gamestate.playing:
                PlayingSet();
                break;

            case gamestate.gameover:
                GameoverSet();
                break;

            case gamestate.goal:
                GoalSet();
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

    }
    private void GoalSet()
    {

    }
}
