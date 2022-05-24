using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ComputerUIController : MonoBehaviour
{
   
    bool isOpen = false;
    public RectTransform panelTransform;
    void Update()
    {
        MoveComputerUI();
    }
    
    public void MoveComputerUI()
    {
        if (isOpen == false)
        {
            if (Input.GetKey(KeyCode.F))
            {
                panelTransform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
                isOpen = true;
            }          
        }

        else  if (isOpen == true)
        {
            if (Input.GetKey(KeyCode.F))
            {

                panelTransform.DOLocalMove(new Vector3(-1500, 0, 0), 0.5f);
            }
        }
    }

}
