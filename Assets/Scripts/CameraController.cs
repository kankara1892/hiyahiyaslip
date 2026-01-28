using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject _player = default;
    [Header("CameraSetting")]
    [SerializeField, Tooltip("âúçsç≈ëÂ")] float offsetMax_z = default;
    [SerializeField, Tooltip("âúçsç≈í·")] float offsetMin_z = default;
    Transform _playerTransforme;
    Vector3 _playerPos;
    Vector3 _cameraPos;
    Vector3 _newcameraPos;

    private void Start()
    {
        _playerTransforme = _player.transform;
    }
    private void FixedUpdate()
    {
        //cameraí«è]
        _playerPos = _playerTransforme.position;
        _cameraPos = transform.position;
        
        _newcameraPos = new Vector3(_playerPos.x, _cameraPos.y,
            Mathf.Clamp(_playerPos.z  - 15,_playerPos.z-15,_playerPos.z-5));

        _newcameraPos.x = Mathf.Clamp(_newcameraPos.x,_playerPos.x-2,_playerPos.x +2);
      
        _cameraPos = Vector3.Lerp(transform.position,_newcameraPos
                                    ,5.0f* Time.deltaTime);
        transform.position = _cameraPos;
    }
}
