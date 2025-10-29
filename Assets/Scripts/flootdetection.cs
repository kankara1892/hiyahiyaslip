using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorditecction : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody = default;
    [SerializeField] float _boostSpeed = default;
    RaycastHit _groundHit;
    bool _groundHitDetect;
    Vector3 _movementDifference;
    Vector3 Player_pos;
    private void Update()
    {
        if (_groundHitDetect & _groundHit.collider.tag == ("BoostFloor"))
        {
            Boost();
        }
    }

    private void OnDrawGizmos()
    {
        _groundHitDetect = Physics.BoxCast(transform.position + Vector3.down, Vector3.one * 0.5f, Vector3.down, out _groundHit, transform.rotation);
        Gizmos.DrawWireCube(transform.position + Vector3.down, Vector3.one);
        Debug.Log(_groundHit.collider.tag);
    }
    private void Boost()
    {
        Player_pos = transform.position;
        _movementDifference = new Vector3(transform.position.x, 0, transform.position.z)
                - new Vector3(Player_pos.x, 0, Player_pos.z);
        Vector3 _boostValue = _movementDifference * _boostSpeed;
        _rigidbody.AddForce(_boostValue);
    }
}
