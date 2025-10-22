using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject _player;
    Transform _playerTransforme;
    Vector3 _playerPos;
    Vector3 _cameraPos;
    [SerializeField]
    Vector3 _cameraToplayerDistance;

    private void Start()
    {
        _playerTransforme = _player.transform;
        _cameraToplayerDistance = _cameraPos - _playerPos;
    }
    private void FixedUpdate()
    {
        _playerPos = _playerTransforme.position;
        _cameraPos = transform.position;

        //cameraí«è]
        _cameraPos = Vector3.Lerp(transform.position, _playerPos + _cameraToplayerDistance
                                    , 0.5f* Time.deltaTime);
        transform.position = _cameraPos;
    }
}
