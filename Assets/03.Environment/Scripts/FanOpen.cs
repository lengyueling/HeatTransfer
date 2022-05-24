using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FanOpen : MonoBehaviour
{
    public void FanOpenControl()
    {
        transform.DOLocalMoveZ(5.354f, 0.5f);
        StartCoroutine(CloseTimer());
        
    }
    IEnumerator CloseTimer()
    {
        yield return new WaitForSeconds(1f);
        transform.DOLocalMoveZ(5.431487f, 0.5f); 
    }
}
