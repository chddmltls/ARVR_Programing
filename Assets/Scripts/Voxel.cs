using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    public float speed = 5f; //속도 정의
    public float destroyTime = 3.0f; //일정 시간 지나면 복셀을 제거

    void Start()
    {
        Vector3 direction = Random.insideUnitSphere; //랜덤한 방향 찾기
        Rigidbody rb = gameObject.GetComponent<Rigidbody>(); //랜덤한 방향으로 날아갈 속도
        rb.velocity = direction * speed;
    }

    float currentTime; //일정 시간 지나면 복셀을 제거해야하므로 현재시간 변수 설정
    void Update()
    {
        currentTime += Time.deltaTime; //시간이 흐르는지 확인
        if (currentTime > destroyTime) //설정한 시간이 지나면 (시간 초과)
        {
            Destroy(gameObject); //게임 오브젝트 제거
        }
    }
}
