using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {
    public float speed = 100f; // 식칼 이동 속력
    private Rigidbody knifeRigidbody;
    // Use this for initialization
    void Start()
    {
        // knife 게임 오브젝트로부터 Rigidbody 타입의 컴포넌트를 
        //찾아서 knife Rigidbody에게 할당
        knifeRigidbody = GetComponent<Rigidbody>();
        // 리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        knifeRigidbody.velocity = transform.forward * speed;

        //활성화된 다음 3초 뒤에 자폭
        Destroy(gameObject, 15f);

    }
    // 충돌 감지는 직접 작성 x
    // 충돌했을때 무엇을 할지를 작성
    // 트리거 충돌시 자동 실행되는 method
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // 상대방 Mover 컴포넌트를 가져와서
            // Die() 실행
            Mover mover = other.GetComponent<Mover>();

            if (mover != null)
            {
                mover.Die();
            }
        }
    }
}
