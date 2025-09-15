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
        if (Input.GetButtonDown("Fire1")) //사용자가 마우스를 클릭한다면,
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스가 가진 방향으로 레이 쏘기
            RaycastHit hitInfo = new RaycastHit(); //hit 관련 정보 저장

            if (Physics.Raycast(ray, out hitInfo)) //hitInfo에 값이 들어온다면.. (out의 의미: 정보를 채워나가주는 output)
            {
                GameObject voxel = Instantiate(voxelFactory); //Instantiate -> 새로운 게임 오브젝트 만들어줌
                voxel.transform.position = hitInfo.point; //복셀의 위치를 히트인포가 갖고있는 위치 값으로
            }
        }
    }
}
