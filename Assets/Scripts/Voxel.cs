using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    public float speed = 5f; //�ӵ� ����
    public float destroyTime = 3.0f; //���� �ð� ������ ������ ����

    void Start()
    {
        Vector3 direction = Random.insideUnitSphere; //������ ���� ã��
        Rigidbody rb = gameObject.GetComponent<Rigidbody>(); //������ �������� ���ư� �ӵ�
        rb.velocity = direction * speed;
    }

    float currentTime; //���� �ð� ������ ������ �����ؾ��ϹǷ� ����ð� ���� ����
    void Update()
    {
        currentTime += Time.deltaTime; //�ð��� �帣���� Ȯ��
        if (currentTime > destroyTime) //������ �ð��� ������ (�ð� �ʰ�)
        {
            Destroy(gameObject); //���� ������Ʈ ����
        }
    }
}
