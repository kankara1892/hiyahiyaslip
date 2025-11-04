using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Playercontroller : MonoBehaviour
{ 
    [SerializeField,Tooltip("Rigidbody")] Rigidbody _rigidbody = default;
    [SerializeField,Tooltip("‰Á‘¬“x")] float speed = default;
 
    [SerializeField]float _speedAbusoluteValue;
    float Horizontal;
    float Vertical;
    float minInputValue = 0.001f;
    bool _groundHitdetect ;
    Vector3 Player_pos;
    Vector3 _movementDifference;
    Vector3 _inputDirection;
   
    

    private void Update()
    {
        //“ü—Í
        Horizontal =Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        _inputDirection = new Vector3(Horizontal, 0, Vertical);  
    }

    private void FixedUpdate()
    {
        //playeris•ûŒü‰ñ“]
        _movementDifference= new Vector3(transform.position.x, 0, transform.position.z)
                - new Vector3(Player_pos.x, 0, Player_pos.z);

        Player_pos = transform.position;
        if (_movementDifference.magnitude >minInputValue )
        {
            transform.rotation =
                Quaternion.LookRotation(_movementDifference);
        }

        //ˆÚ“®
        Vector3 _movementforce = Vector3.zero;
        Vector3 _currentVelocity = _rigidbody.velocity;
        _movementforce =_inputDirection * speed;
        if(_rigidbody.velocity.magnitude <= _speedAbusoluteValue)
        {
            _rigidbody.velocity +=_movementforce;
            _rigidbody.velocity = new Vector3(Mathf.Clamp(_currentVelocity.x, -_speedAbusoluteValue, _speedAbusoluteValue),
                                                _currentVelocity.y,
                                                Mathf.Clamp(_currentVelocity.z, -_speedAbusoluteValue, _speedAbusoluteValue));
        }
       
    }
   
}
