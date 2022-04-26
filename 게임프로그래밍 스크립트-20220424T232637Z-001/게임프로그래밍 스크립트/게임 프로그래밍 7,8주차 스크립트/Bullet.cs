using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        // 3초 후 자기자신을 파괴
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대가 Player태그를 가진다면
        if (other.tag == "Player")
        {
            // PlayerController 컴포넌트 가져오기(아까만든 스크립트)
            PlayerController playerController = other.GetComponent<PlayerController>();

            // PlayerController 컴포넌트가 존재한다면 (오류방지)
            if (playerController != null)
            {
                // 그 클래스의 Die() 실행
                playerController.Die();
            }
        }
    }
}
