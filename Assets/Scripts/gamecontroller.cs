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

                SetStart();
                if (Input.GetKeyDown(KeyCode.Space))
                {

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
