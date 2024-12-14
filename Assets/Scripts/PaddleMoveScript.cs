using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMoveScript : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float speedDirection = x * speed * Time.deltaTime;
        transform.position += new Vector3(speedDirection, 0, 0);
    }
}
