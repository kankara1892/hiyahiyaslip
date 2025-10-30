using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorditecction : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody = default;
    [SerializeField] float _boostSpeed = default;
    [SerializeField] float _boostCoolTime = default;
    RaycastHit _groundHit;
    bool _groundHitDetect;
    Vector3 _movementDifference;
    Vector3 Player_pos;
    string _groundHitTag;
    float _boostCooldownTimer;
    const string BOOSTFLOOR = "Boostfloor";
    const string GROUND = "Ground";
    private void Update()
    {
        _boostCooldownTimer += Time.deltaTime;
        
        if(_groundHitDetect )
        {
            _groundHitTag = _groundHit.collider.tag;
        }
        if (_groundHitTag == BOOSTFLOOR)
        {
            if (_boostCoolTime <= _boostCooldownTimer)
            {
                Boost();
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        _groundHitDetect = Physics.BoxCast(transform.position + Vector3.down, Vector3.one * 0.5f, Vector3.down, 
                                            out _groundHit, transform.rotation,LayerMask.GetMask(GROUND));
        Gizmos.DrawWireCube(transform.position + Vector3.down, Vector3.one);
       
    }
    private void Boost()
    {
        Debug.Log("Boost");
        _boostCooldownTimer = 0;
        Player_pos = transform.position;
        _movementDifference = new Vector3(transform.position.x, 0, transform.position.z)
                - new Vector3(Player_pos.x, 0, Player_pos.z);
        Vector3 _boostValue = _movementDifference * _boostSpeed;
        _rigidbody.AddForce(_boostValue);
    }
}
