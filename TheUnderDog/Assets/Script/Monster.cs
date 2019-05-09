using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour {
    // 따라가는거 ok
    // 식칼던지는거 ok
    // 룩앳 ok
    // 진화
    public GameObject knifePrefab; // 생성할 총알의 원본 프리팹
    public float spawnRateMin = 1.2f; // 최소 생성 주기
    public float spawnRateMax = 4f; // 최대 생성 주기
    
    public Transform knifeTarget; // 발사할 대상
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성 시점에서 지난 시간

    public Transform Player;
    public float Chase_Range;
    public float Distance;
    public float RotSpeed = 3; // the target's rotation speed
    public float MoveSpeed = 1; // the target's moving speed

    // Use this for initialization
    void Start()
    {
        //타이머를 리셋
        timeAfterSpawn = 0;
        //총알 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 랜덤 결정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //총알을 조준할 대상으로 PlayerController를 가진 게임 오브젝트를 찾기

        Player = FindObjectOfType<Mover>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        // timeAfterSpawn을 갱신
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            //총알 생성 간격보다 타이머 값이 크면, 타이머를 리셋
            timeAfterSpawn = 0;

            //총알 생성
            // bulletPrefab의 복제본을 총알 생성기의 위치와 회전에 생성
            GameObject knife = Instantiate(knifePrefab, transform.position, transform.rotation);
            //생성한 총알의 앞쪽방향을 target을 바라보도록 변경
            knife.transform.LookAt(knifeTarget);
            //다음번 생성 시점 까지의 간격을 랜덤 설정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        }



        // The Distance Between Our Player and The Target(Enemy)
        Distance = (Player.transform.position - transform.position).magnitude;

        // when the target gets close to the player
        if (Distance <= Chase_Range)
        {
            Vector3 Direction = Player.position - transform.position; // the defference of position of these two objects, in order to use in rotation 
            Direction.y = 0; // so the target won't rotate in the y-axis

            // rotate the target toward the player
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(Direction), RotSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            // so when the target rotates toward the player then we can move the target to forward direction,
            // Suppose it Chases the player
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        }



    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            Mover mover = col.GetComponent<Mover>();

            if(mover != null)
            {
                mover.Die();
            }
        }
    }



}
