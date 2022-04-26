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

        // 3�� �� �ڱ��ڽ��� �ı�
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ��밡 Player�±׸� �����ٸ�
        if (other.tag == "Player")
        {
            // PlayerController ������Ʈ ��������(�Ʊ�� ��ũ��Ʈ)
            PlayerController playerController = other.GetComponent<PlayerController>();

            // PlayerController ������Ʈ�� �����Ѵٸ� (��������)
            if (playerController != null)
            {
                // �� Ŭ������ Die() ����
                playerController.Die();
            }
        }
    }
}
