using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알.프리팹 파일 가져오기 위한 공간
    public float spawnRateMin = 0.5f; // 최소 생성 주기
    public float spawnRateMax = 3f; // 최대 생성 주기

    private Transform target; // 발사할 대상
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성 시점에서 지난시간

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        // 탄알 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 랜덤 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
        target = FindObjectOfType<PlayerContorller>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;

        // 최근 생성 시점에서부터 누적된 시간이 생성주기보다 크거나 같다면
        if (timeAfterSpawn >= spawnRate)
        {
            // 누적 시간 리셋
            timeAfterSpawn = 0;

            // bulletPrefab 복제본을
            // transgorm.position 위치와 transform.ratation 회전으로 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // 생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            bullet.transform.LookAt(target);
            // 다음번 생성 간격을 spawnRateMin, spawnRateMax 사이에서 랜덤지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

}
