using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Returnpool : MonoBehaviour
{
    float _onInvisible;
    [SerializeField]float ReturnTime;
    private bool _isInvisible;
    private void OnBecameInvisible()
    {
        _isInvisible = true;
    }
    private void OnBecameVisible()
    {
        _isInvisible = false;
    }
    private void Update()
    {
        if (_isInvisible)
        {
            _onInvisible += Time.deltaTime;
            if (ReturnTime <= _onInvisible)
            {
                Debug.Log("Return");
                gameObject.SetActive(false);
                _onInvisible = 0f;
            }
        }
        else
        {
            _onInvisible = 0f;
        }
        
    }
}
