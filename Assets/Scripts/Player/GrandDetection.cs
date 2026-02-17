using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Granddetection: MonoBehaviour
{
    RaycastHit _groundHit;
    bool _groundHitDetect;
    LayerMask GROUNDLayer = 1<<6;
    private void Update()
    {
        //raycast
        Ray GroundDitectionRay = new Ray(transform.position,Vector3.down);
        _groundHitDetect = Physics.Raycast(GroundDitectionRay,out _groundHit,1.2f,GROUNDLayer);
        Debug.DrawRay(transform.position, Vector3.down*1.2f, Color.red);
    }
   
    public bool IsGround
    {
        get { return _groundHitDetect; }
    }
}
