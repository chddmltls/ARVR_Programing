using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFactory;

    public int voxelPoolSize = 20; //������Ʈ Ǯ�� ũ��

    public static List<GameObject> voxelPool = new List<GameObject>(); //���ο� �迭 ����

    public float createTime = 0.1f; //���� ���� �ð�
    private float currentTime = 0; //�ڵ� ���� ����ð�
    void Start()
    {
        for (int i = 0; i < voxelPoolSize; i++) //�ݺ������� Ǯ�� ���� ���� ���� ����
        {
            GameObject voxel = Instantiate(voxelFactory); //���� ���� ����� / Instantiate -> ���ο� ���� ������Ʈ ������� 
            voxel.SetActive(false); //Ǯ�� ���� ������ ���� ���� �� �ƴϹǷ� ��Ȱ��ȭ
            voxelPool.Add(voxel); //���� Ǯ�� ������ �߰�
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1")) //����ڰ� ���콺�� Ŭ���Ѵٸ�,
        if (currentTime > createTime) //���� �ð��� �����ٸ� ��� �����ϵ���
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //���콺�� ���� �������� ���� ���
            RaycastHit hitInfo = new RaycastHit(); //hit ���� ���� ����

            if (Physics.Raycast(ray, out hitInfo)) //hitInfo�� ���� ���´ٸ�.. (out�� �ǹ�: ������ ä�������ִ� output)
            {
                if (voxelPool.Count > 0) //Ǯ �ȿ� ������ �ִٸ�
                {
                    GameObject voxel = voxelPool[0]; //voxelPool���� ��������
                    voxel.SetActive(true); //Ǯ�� �ִ� ��ü Ȱ��ȭ
                    voxel.transform.position = hitInfo.point; //������ ��ġ�� ��Ʈ������ �����ִ� ��ġ ������
                    voxelPool.RemoveAt(0); //������Ʈ Ǯ���� ���� 1�� ����

                    currentTime = 0; //�ݺ��ؼ� ����
                }
            }
        }

        currentTime += Time.deltaTime;
    }
}
