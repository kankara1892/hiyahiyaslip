using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetection : MonoBehaviour
{
    [SerializeField] private int addScoreGetFish;
    [SerializeField] Rigidbody _rigidbody = default;
    // [SerializeField] private ScoreSystem;
    [SerializeField] float _boostSpeed = default;
    private const string Item = "Item";
    private Vector3 _currentVelocity;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Item && other.tag != null)
        {
            Boost();
        }
    }
    private void Boost()
    {
        Vector3 _boostValue = _currentVelocity.normalized * _boostSpeed;
        _rigidbody.AddForce(_boostValue, ForceMode.Impulse);
        Debug.Log(_boostValue + "Boosted" + _currentVelocity);
    }
}
