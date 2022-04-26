using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1번에 60도씩 회전
        transform.Rotate(0f, rotationSpeed*Time.deltaTime, 0f);
    }
}
