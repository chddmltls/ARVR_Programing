using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    Vector3 angle; //현 각도
    public float sensitivity = 200; //마우스 민감도
    void Start()
    {
        //시작할떄 현재 카메라의 각도 적용
        angle = Camera.main.transform.eulerAngles;
        angle.x *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
