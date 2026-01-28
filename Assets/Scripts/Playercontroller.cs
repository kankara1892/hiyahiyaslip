using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Playercontroller : MonoBehaviour
{ 
    [SerializeField,Tooltip("Rigidbody")] private Rigidbody _rigidbody = default;
    [SerializeField,Tooltip("加速度")] private float speed = default;
    [SerializeField] private float _maxSpeedAbsoluteValue;
    [SerializeField] private float _maxSideForceAbsoluteValue;
    [SerializeField] private Granddetection Floordetection = default;
    private float Horizontal;
    private float Vertical;
    private float minInputValue = 0.001f;
    private float _inputMagnitude;
    private float _playerVertical;
    private bool isGround;
    private bool Jumpingfrag;
    private bool isGoal = false;
    private Vector3 Playerposition;
    private Vector3 _movementDifference;
    private Vector3 _inputDirection;
    private PlayerState playerState;
    private enum PlayerState 
    {
        Idle,
        Run,
        Jump,
        land
    }
    private void Awake()
    {
        playerState = PlayerState.Idle;
    }
    public int playerStateNumber
    {
        get { return (int)playerState; }
    }
    public float playerVertical
    {
        get { return _playerVertical; }
    }
    public bool IsGoal
    {
        get { return isGoal; }
    }

    private void Update()
    {
        //入力
        Horizontal =Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        _inputDirection = new Vector3(Horizontal, 0, Vertical);
        _inputMagnitude = _inputDirection.magnitude;
        isGround = Floordetection.IsGround;
        _playerVertical = _rigidbody.velocity.y;
        if (!isGround & !Jumpingfrag)
        {
            playerState = PlayerState.Jump;
            Jumpingfrag = true;
        }

        switch(playerState) {
            case PlayerState.Idle:
                if(_inputMagnitude > minInputValue  & isGround)
                {
                    playerState = PlayerState.Run;
                }
                if (!isGround)
                {
                    playerState = PlayerState.Jump;
                }
                break;

            case PlayerState.Run:
                if(_inputMagnitude <= minInputValue)
                {
                    playerState = PlayerState.Idle;
                }
                if (!isGround)
                {
                    playerState = PlayerState.Jump; 
                }
                break;

            case PlayerState.Jump:
                if (isGround)
                {
                    playerState = PlayerState.land;
                }
                break;
            case PlayerState.land:
                if (_inputMagnitude > minInputValue & isGround)
                {
                    playerState = PlayerState.Run;
                }
                if (_inputMagnitude <= minInputValue & isGround)
                {
                    playerState = PlayerState.Idle;
                }
                break;

        }
    }

    private void FixedUpdate()
    {
        //player進行方向回転
        _movementDifference= new Vector3(transform.position.x, transform.position.y, transform.position.z)
                - new Vector3(Playerposition.x, transform.position.y, Playerposition.z);
        Playerposition = transform.position;
        
        if (_inputMagnitude>minInputValue )
        {
            transform.rotation =
                Quaternion.LookRotation(_movementDifference);
        } 
        
        if(Mathf.Abs(_rigidbody.velocity.z) < _maxSpeedAbsoluteValue)
        {
            _rigidbody.AddForce((Vector3.forward * _inputDirection.z) * speed);
        }
        if(Mathf.Abs( _rigidbody.velocity.x) < _maxSideForceAbsoluteValue)
        {
            _rigidbody.AddForce((Vector3.right * _inputDirection.x )* speed);
        }
       
    }
}
