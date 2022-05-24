using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{   
    //射线检测
    private new Camera camera;
    private Vector3 mousePosition;
    public Transform targetTransform;//获取屏幕中心
    void Awake()
    {
        camera = gameObject.GetComponent<Camera>();//实例化第一人称相机
    }
    /// <summary>
    /// 射线检测
    /// </summary>
    /// <returns></returns>
    public bool TarRaycast()
    {
        mousePosition = Input.mousePosition;
        targetTransform = null;
        if (camera != null)
        {
            RaycastHit hitInfo;
            Ray ray = camera.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, 0f));
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                targetTransform = hitInfo.collider.transform;
                return true;
            }
        }
        return false;
    }
}
