using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFactory;

    public int voxelPoolSize = 20; //오브젝트 풀의 크기

    public static List<GameObject> voxelPool = new List<GameObject>(); //새로운 배열 생성

    public float createTime = 0.1f; //복셀 생성 시간
    private float currentTime = 0; //자동 생성 경과시간
    void Start()
    {
        for (int i = 0; i < voxelPoolSize; i++) //반복문으로 풀에 있을 복셀 개수 정의
        {
            GameObject voxel = Instantiate(voxelFactory); //복셀 새로 만들기 / Instantiate -> 새로운 게임 오브젝트 만들어줌 
            voxel.SetActive(false); //풀로 가는 복셀은 눈에 보일 건 아니므로 비활성화
            voxelPool.Add(voxel); //복셀 풀에 복셀을 추가
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1")) //사용자가 마우스를 클릭한다면,
        if (currentTime > createTime) //생성 시간이 지났다면 계속 생성하도록
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스가 가진 방향으로 레이 쏘기
            RaycastHit hitInfo = new RaycastHit(); //hit 관련 정보 저장

            if (Physics.Raycast(ray, out hitInfo)) //hitInfo에 값이 들어온다면.. (out의 의미: 정보를 채워나가주는 output)
            {
                if (voxelPool.Count > 0) //풀 안에 복셀이 있다면
                {
                    GameObject voxel = voxelPool[0]; //voxelPool에서 가져오기
                    voxel.SetActive(true); //풀에 있던 객체 활성화
                    voxel.transform.position = hitInfo.point; //복셀의 위치를 히트인포가 갖고있는 위치 값으로
                    voxelPool.RemoveAt(0); //오브젝트 풀에서 복셀 1개 제거

                    currentTime = 0; //반복해서 생성
                }
            }
        }

        currentTime += Time.deltaTime;
    }
}
