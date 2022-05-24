using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FaMenController : MonoBehaviour
{
    
    public void InControl()
    {
            transform.DOLocalRotate(new Vector3(0, 0, 0), 2);
          
    }
    public void InClose()
    {
           
                transform.DOLocalRotate(new Vector3(0, -90, 0), 2);
            

    }


    public void OutControl()
    {
        
            transform.DOLocalRotate(new Vector3(0, 0, 0), 2);
       
    }
    public  void OutClose()
    {
       
            transform.DOLocalRotate(new Vector3(0, 90, 0), 2);
       
    }
}

