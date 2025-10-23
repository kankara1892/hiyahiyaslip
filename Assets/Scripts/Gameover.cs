using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    float _fallheight = -10.0f;
    private void FixedUpdate()
    {
        if (transform.position.y < _fallheight)
        {
            Debug.Log("Over");
        }
    }
}
