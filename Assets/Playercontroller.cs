using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField,Tooltip("‰Á‘¬“x")]
    float speed = 25f;
    [SerializeField]
    float _maxMagunitude;
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
        //“ü—Í
        Horizontal =Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //playeris•ûŒü‰ñ“]
        diff = new Vector3(transform.position.x, 0, transform.position.z)
                - new Vector3(Player_pos.x, 0, Player_pos.z);

        Player_pos = transform.position;

        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(diff), 0.2f);
        }

        //ˆÚ“®
        Vector3 force = Vector3.zero;
        force =new Vector3 (Horizontal,0,Vertical)*speed;
        if(rb.velocity.magnitude <= _maxMagunitude)
        {
            rb.AddForce(force);
        }
    }
}
