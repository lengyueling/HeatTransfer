using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ComputerUIClose : MonoBehaviour
{
   // private bool isIn = false;
    public RectTransform panelTransform;
    public void OnClick()
    {
        panelTransform.DOLocalMove(new Vector3(-1500, 0, 0), 0.5f);

    }

}
