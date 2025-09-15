using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    public float speed = 5f; //속도 정의
    public float destroyTime = 3.0f; //일정 시간 지나면 복셀을 제거

    void OnEnable() //활성화가 된다면
    {
        currentTime = 0; //현재시간 0으로 하여 생성되었을떄 튀기게 하기

        Vector3 direction = Random.insideUnitSphere; //랜덤한 방향 찾기
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); //랜덤 색상 지정
        Rigidbody rb = gameObject.GetComponent<Rigidbody>(); //랜덤한 방향으로 날아갈 속도
        rb.velocity = direction * speed;
    }

    float currentTime; //일정 시간 지나면 복셀을 제거해야하므로 현재시간 변수 설정
    void Update()
    {
        currentTime += Time.deltaTime; //시간이 흐르는지 확인
        if (currentTime > destroyTime) //설정한 시간이 지나면 (시간 초과)
        {
            gameObject.SetActive(false); //자기 자신을 끄기
            VoxelMaker.voxelPool.Add(gameObject); //복셀 메이커 코드에 있는 복셀 풀 리스트를 불러와 거기에 자기 자신을 추가
            //Destroy(gameObject); //게임 오브젝트 제거
        }
    }
}
