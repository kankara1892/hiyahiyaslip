using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class gamecontroller : MonoBehaviour
{
    [SerializeField] GameObject StartUI = default;
    [SerializeField] GameObject PlayingUI = default;
    [SerializeField] GameObject GameoverUI = default;
    [SerializeField] AudioSource BGM;
    [SerializeField] Text runnedDistance;
    [SerializeField] Playercontroller _playerController;
    [SerializeField] Gameover gameover;
    [SerializeField] GameObject Player;
    private float StartPoint;
    private string _distance;
    bool _isStarting;
    bool _isGameover;
   
    private enum gamestate
    {
        start,
        playing,
        gameover,
    }
    gamestate _gameState;
    private void Start()
    {
      StartPoint= Player.transform.position.z;
        _gameState = gamestate.start;
    }
    private void Update()
    {
       _distance = MathF.Abs(Player.transform.position.z -StartPoint).ToString("F0");
        runnedDistance.text =_distance + "m" ;
      //  BGM.Play();
        //UIの遷移
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
                    BGM.Play();
                    _isStarting = false;
                    StartUI.SetActive(false);
                    Time.timeScale = 1;
                    _gameState = gamestate.playing;

                }
                break;

            case gamestate.playing:
               
                PlayingSet();
                PlayingUI.SetActive(true);
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
        //BGM.Play();
    }
    private void GameoverSet()
    {
        BGM.Stop();
        GameoverUI.SetActive(true);
        Time.timeScale = 0;
    }  
}
