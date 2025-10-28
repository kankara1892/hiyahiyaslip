using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Playercontroller : MonoBehaviour
{
    [SerializeField,Tooltip("‰Á‘¬“x")] float speed = default;
    [SerializeField,Tooltip("Rigidbody")] Rigidbody _rigidbody = default;
    [SerializeField]float _maxMagunitude;
    float Horizontal;
    float Vertical;
    float minInputValue = 0.001f;
    Vector3 Player_pos;
    Vector3 _movementDifference;
    Vector3 _inputDirection;
    RaycastHit _groundHit;
    bool _groundHitdetect ;

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
        _movementforce =_inputDirection*speed;
        if(_rigidbody.velocity.magnitude <= _maxMagunitude)
        {
            _rigidbody.AddForce(_movementforce);
        }
    }

    private void OnDrawGizmos()
    {
        _groundHitdetect = Physics.BoxCast(transform.position + Vector3.down, Vector3.one *0.5f, Vector3.down,out _groundHit,transform.rotation);
        if (_groundHitdetect)
        {
           Debug.Log( _groundHit.collider.name);
            Gizmos.DrawWireCube(transform.position + Vector3.down, Vector3.one);
        }
    }
}
