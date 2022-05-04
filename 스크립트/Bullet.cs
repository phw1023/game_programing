using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    public float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {   // 충돌한 상대가 Player 태그를 가진다면?
        if (other.tag == "Player")
        {
            PlayerContorller playerController = other.GetComponent<PlayerContorller>();

            if(playerController != null)
            {
                playerController.Die();
            }
            
        }
    }
}
