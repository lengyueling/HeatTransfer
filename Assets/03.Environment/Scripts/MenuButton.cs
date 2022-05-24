using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButton : MonoBehaviour
{
    private bool isIn = false;
    public RectTransform panelTransform;
    public void OnClick()
    {
        if (isIn == false)
        {
           Tweener tweener= panelTransform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
            tweener. SetAutoKill(false);
            isIn = true;
        }
        else 
        {

            panelTransform.DOPlayBackwards();
            isIn = false ;
        }
        
    }

}