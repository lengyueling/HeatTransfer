using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HeatingSwitch : MonoBehaviour
{
  //  float close;
   // public void Start()
  //  {
  //      close = gameObject.transform.position.z;
  //  }
    public void HeatingSwitchControl()
    {
    //    Debug.Log(close);
        transform.DOLocalMoveZ(5.354f, 0.5f);
        StartCoroutine(CloseTimer());       
    }
    IEnumerator CloseTimer()
    {
        yield return new WaitForSeconds(1f);
        transform.DOLocalMoveZ(5.431487f, 0.5f);
    }

}


