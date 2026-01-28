using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkLogic : MonoBehaviour
{
    [SerializeField] GameObject TargetObject;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float OnHardModeDistance;
    [SerializeField] float OnNormalModeDistance;
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
        _rigidbody.velocity = Vector3.forward * moveSpeed;
    }
}