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
    Vector3 _currentVelocity;
    string _groundHitTag;
    float _boostCooldownTimer;
    const string BOOSTFLOOR = "BoostFloor";
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
                _currentVelocity = _rigidbody.velocity;
                Boost();
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        _groundHitDetect = Physics.BoxCast(transform.position + Vector3.down * 0.5f, Vector3.one * 0.5f, Vector3.down, 
                                            out _groundHit, transform.rotation,LayerMask.GetMask(GROUND));
        Gizmos.DrawWireCube(transform.position + Vector3.down * 0.5f, Vector3.one);
       
    }
    private void Boost()
    {
        
        Vector3 _boostValue = _currentVelocity.normalized * _boostSpeed;
        _rigidbody.AddForce(_boostValue,ForceMode.Impulse);
        _boostCooldownTimer = 0;
        Debug.Log( _boostValue +"Boosted" + _currentVelocity);
    }
}
