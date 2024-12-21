using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMoveScript : MonoBehaviour
{
    public float speed = 5f;
    public float fireRate = 2f;
    float timeFromLastShot = 0;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float speedDirection = x * speed * Time.deltaTime;
        transform.position += new Vector3(speedDirection, 0, 0);
    }

    void Shoot()
    {
        timeFromLastShot += Time.deltaTime;
        Vector3 position = transform.position + new Vector3(0, 1, 0);

        //if (timeFromLastShot >= (1f / fireRate))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bullet, position, Quaternion.identity);
                timeFromLastShot = 0;
            }
        }
    }
}
