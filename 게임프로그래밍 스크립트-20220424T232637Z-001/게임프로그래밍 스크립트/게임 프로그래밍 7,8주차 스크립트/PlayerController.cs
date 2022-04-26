using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; // ������Ʈ�� Rigidbody�� ������ �뵵
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
        // ����, �������� �Է°��� ������ ����
        float xInput = Input.GetAxis("Horizontal");
        float zinput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zinput * speed;

        // Vector3 �ӵ��� (xSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3 (xSpeed, 0f, zSpeed);
        // ������ٵ��� �ӵ��� newVelocity �Ҵ�
        playerRigidbody.velocity = newVelocity;

    }

    public void Die()
    {
        // �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

        // ���� �����ϴ� GameManager Ÿ���� ������Ʈ ã�Ƽ� ��������
        GameManager gameManager = FindObjectOfType<GameManager>();
        // ������ GameManager ������Ʈ�� EndGame() �޼��� ����
        gameManager.EndGame();
    }
}
