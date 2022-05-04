using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal"); // x입력
        float zInput = Input.GetAxis("Vertical"); // y입력
        float xSpeed = xInput * speed; // x속도
        float zSpeed = zInput * speed; // z속도
        Vector3 newVelocity = new Vector3( xSpeed, 0f, zSpeed); // 속도의 vector3값
        playerRigidbody.velocity = newVelocity; // 속도 값 대입

        
    }

    public void Die()
    {
        // 게임 오브젝트 비활성화
        gameObject.SetActive(false);
        
    }
}
