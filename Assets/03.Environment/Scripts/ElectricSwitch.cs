using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ElectricSwitch : MonoBehaviour
{
    public void OpenControl()
    {
         transform.DOLocalRotate(new Vector3(0, 90, 0), 1);
    }
    public void Close()
    {
        transform.DOLocalRotate(new Vector3(0, 0, 0), 1);       
    }
}
