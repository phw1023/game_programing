using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; // 오브젝트의 Rigidbody에 접근할 용도
    public float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if((Input.GetKey(KeyCode.UpArrow)==true))
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        if ((Input.GetKey(KeyCode.DownArrow) == true))
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        if ((Input.GetKey(KeyCode.RightArrow) == true))
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
        if ((Input.GetKey(KeyCode.LeftArrow) == true))
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
        */
        // 수평, 수직축의 입력값을 감지해 저장
        float xInput = Input.GetAxis("Horizontal");
        float zinput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zinput * speed;

        // Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3 (xSpeed, 0f, zSpeed);
        // 리지드바디의 속도에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;

    }

    public void Die()
    {
        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        // 씬에 존재하는 GameManager 타입의 오브젝트 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();
        // 가져온 GameManager 오브젝트의 EndGame() 메서드 실행
        gameManager.EndGame();
    }
}
