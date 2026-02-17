using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkLogic : MonoBehaviour
{
    [SerializeField] GameObject TargetObject;
    [SerializeField] Rigidbody _rigidbody;
    [Header("SharkLogicSetting")]
    [SerializeField] float OnNormalModeDistance;
    [SerializeField] float OnHardModeDistance; 
    [SerializeField] float OnExpertModeDistance;
    [SerializeField] float NormalModeSpeed;
    [SerializeField] float HardModeSpeed;
    [SerializeField] float ExpertModeSpeed;
    private float moveSpeed = default;
    private float targetDistance;
    chaseMode _chaseMode;
    private enum chaseMode
    {
        Normal,
        Hard,
        Expert
    }
    private void Awake()
    {
        _chaseMode = chaseMode.Normal;
    }
    private void Update()
    {
        targetDistance =Mathf.Abs(new Vector2(TargetObject.transform.position.x - transform.position.x, 
                                              TargetObject.transform.position.z - transform.position.z).magnitude);
        
        if (targetDistance >= OnNormalModeDistance)
        {
            _chaseMode = chaseMode.Normal;
        }
        if(targetDistance >= OnHardModeDistance)
        {
            _chaseMode = chaseMode.Hard;
        }
        if(targetDistance >= OnExpertModeDistance)
        {
            _chaseMode = chaseMode.Expert;
        }
        switch (_chaseMode)
        {
            case chaseMode.Normal:
                moveSpeed = NormalModeSpeed;
                return;
            case chaseMode.Hard:
                moveSpeed = HardModeSpeed;
  
                return;
            case chaseMode.Expert:
                moveSpeed = ExpertModeSpeed;
     
                return;
        }

    }

    private void FixedUpdate()
    {
        //Debug.Log(_chaseMode);
        _rigidbody.velocity = Vector3.forward * moveSpeed;
    }
}