using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField,Tooltip("加速度")]
    float speed = 25f;
    [SerializeField,Tooltip("入力に対する追従度")]
    float moveForceMultiplier;
    float Horizontal;
    float Vertical;
    Rigidbody rb;
    Vector3 Player_pos;
    Vector3 diff;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player_pos = GetComponent<Transform>().position;
    }
    private void Update()
    {
        //入力
        Horizontal =Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        diff = new Vector3(transform.position.x, 0, transform.position.z)
                - (new Vector3(Player_pos.x, 0, Player_pos.z));
        Player_pos = transform.position;
        //player進行方向回転
        if (diff.magnitude > 0.001f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(diff), 0.2f);
        }
        //移動
        Vector3 force = Vector3.zero;
        force = new Vector3(Horizontal*speed,0,Vertical* speed);
        rb.AddForce(force);
    }
}
