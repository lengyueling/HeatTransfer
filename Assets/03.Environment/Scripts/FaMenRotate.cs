using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FaMenRotate : MonoBehaviour
{
    /*
    float rou;
    public void Start()
    {
        rou = gameObject.transform.rotation.x;
    }
    */
    public void RotateControl()
    {
        // if (Input .GetKeyDown(KeyCode.F)) 
        //  {
        // transform.Rotate(new Vector3(0, 0, -1));
        transform.DOLocalRotate(new Vector3(0, 0, 180), 2);
       // }
    }
    public void Close()
    {
        // transform.Rotate(new Vector3(0, 0, 1));
        if (transform.rotation == new Quaternion(0,0,0,0))
        {
            transform.DOLocalRotate(new Vector3(0, 0, 180), 2);
        }
        else
        {
            transform.DOLocalRotate(new Vector3(0, 0, 0), 2);
        }
            
       // Debug.Log(rou);
    }
    
}
