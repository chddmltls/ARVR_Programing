using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    Vector3 angle; //�� ����
    public float sensitivity = 200; //���콺 �ΰ���
    void Start()
    {
        //�����ҋ� ���� ī�޶��� ���� ����
        angle = Camera.main.transform.eulerAngles;
        angle.x *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
