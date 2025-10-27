using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamecontroller : MonoBehaviour
{
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

                break;

            case gamestate.playing:

                break;

            case gamestate.gameover:

                break;

            case gamestate.goal:

                break;
        }
    }
}
