using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _characterAnimator = default;
    [SerializeField] private Playercontroller _playerController = default;
    private const int _stateIdleNumber = 0;
    private const int _stateRunNumber = 1;
    private const int _stateJumpNumber = 2;
    private const int _stateLandNumber = 3;
    private int _currentStateNumber;
    private float _currentVertical;
    private void Update()
    {
        _currentStateNumber = _playerController.playerStateNumber;
        _currentVertical = _playerController.playerVertical;
        _characterAnimator.SetFloat("Vertical Speed", _currentVertical);
        if (_currentStateNumber == _stateLandNumber)
        {
           _characterAnimator.SetBool("Grounded", true);
        }
        if(_currentStateNumber == _stateJumpNumber)
        {
            _characterAnimator.SetBool("Grounded", false);
            _characterAnimator.SetBool("Idle", false);
            _characterAnimator.SetBool("Run", false);
        }
        if (_currentStateNumber == _stateIdleNumber)
        {
            _characterAnimator.SetBool("Idle", true);
        }
        else
        {
            _characterAnimator.SetBool("Idle", false);
        }
        if(_currentStateNumber == _stateRunNumber)
        {
            _characterAnimator.SetBool("Run", true);
        }
        else
        {
            _characterAnimator.SetBool("Run", false);
        }

    }
}
