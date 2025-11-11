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
    LayerMask GROUNDLayer = 1<<6;
    private void Update()
    {
        Ray GroundDitectionRay = new Ray(transform.position,Vector3.down);
        _groundHitDetect = Physics.Raycast(GroundDitectionRay,out _groundHit,1.2f,GROUNDLayer);
        _boostCooldownTimer += Time.deltaTime;
        Debug.DrawRay(transform.position, Vector3.down*1.2f, Color.red);
        if(_groundHitDetect)
        {
            _groundHitTag = _groundHit.collider.tag;
        }
        else
        {
            return;
        }
        if (_groundHitTag == BOOSTFLOOR)
        { 
            Debug.Log("isActive");
            if (_boostCoolTime <= _boostCooldownTimer)
            {
                _currentVelocity = _rigidbody.velocity;
                Boost();
            } 
        }
    }
    private void Boost()
    {
        Vector3 _boostValue = _currentVelocity.normalized * _boostSpeed;
        _rigidbody.AddForce(_boostValue,ForceMode.Impulse);
        _boostCooldownTimer = 0;
        Debug.Log( _boostValue +"Boosted" + _currentVelocity);
    }
    public bool IsGround
    {
        get { return _groundHitDetect; }
    }
}
