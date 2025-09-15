using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    public float speed = 5f; //�ӵ� ����
    public float destroyTime = 3.0f; //���� �ð� ������ ������ ����

    void OnEnable() //Ȱ��ȭ�� �ȴٸ�
    {
        currentTime = 0; //����ð� 0���� �Ͽ� �����Ǿ����� Ƣ��� �ϱ�

        Vector3 direction = Random.insideUnitSphere; //������ ���� ã��
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); //���� ���� ����
        Rigidbody rb = gameObject.GetComponent<Rigidbody>(); //������ �������� ���ư� �ӵ�
        rb.velocity = direction * speed;
    }

    float currentTime; //���� �ð� ������ ������ �����ؾ��ϹǷ� ����ð� ���� ����
    void Update()
    {
        currentTime += Time.deltaTime; //�ð��� �帣���� Ȯ��
        if (currentTime > destroyTime) //������ �ð��� ������ (�ð� �ʰ�)
        {
            gameObject.SetActive(false); //�ڱ� �ڽ��� ����
            VoxelMaker.voxelPool.Add(gameObject); //���� ����Ŀ �ڵ忡 �ִ� ���� Ǯ ����Ʈ�� �ҷ��� �ű⿡ �ڱ� �ڽ��� �߰�
            //Destroy(gameObject); //���� ������Ʈ ����
        }
    }
}
