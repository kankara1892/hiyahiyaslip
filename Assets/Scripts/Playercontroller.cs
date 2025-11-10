using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Playercontroller : MonoBehaviour
{ 
    [SerializeField,Tooltip("Rigidbody")] Rigidbody _rigidbody = default;
    [SerializeField,Tooltip("‰Á‘¬“x")] float speed = default;
    [SerializeField]float _maxSpeedAbsoluteValue;
    [SerializeField] float _maxSideForceAbsoluteValue;
    float Horizontal;
    float Vertical;
    float minInputValue = 0.001f;
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
        _movementDifference= new Vector3(transform.position.x, transform.position.y, transform.position.z)
                - new Vector3(Player_pos.x, transform.position.y, Player_pos.z);
        Player_pos = transform.position;
        
        if (_inputDirection.magnitude>minInputValue )
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
