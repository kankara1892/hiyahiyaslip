using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    bool IsOver= false;
    float _fallheight = -10.0f;
    public bool giveIsOver
    {
        get { return IsOver; }
    }
    private void Update()
    {
        if (transform.position.y < _fallheight)
        {
            IsOver = true;
        }
    }
}
