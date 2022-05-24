using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Loading : MonoBehaviour
{
    public void Handle()
    { 
    transform .DOLocalMove(new Vector3(0, 0, 0), 0.5f);
    }
    

   
}
