using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFactory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //����ڰ� ���콺�� Ŭ���Ѵٸ�,
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //���콺�� ���� �������� ���� ���
            RaycastHit hitInfo = new RaycastHit(); //hit ���� ���� ����

            if (Physics.Raycast(ray, out hitInfo)) //hitInfo�� ���� ���´ٸ�.. (out�� �ǹ�: ������ ä�������ִ� output)
            {
                GameObject voxel = Instantiate(voxelFactory); //Instantiate -> ���ο� ���� ������Ʈ �������
                voxel.transform.position = hitInfo.point; //������ ��ġ�� ��Ʈ������ �����ִ� ��ġ ������
            }
        }
    }
}
