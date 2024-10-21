using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed = 3f;
    public float fireRate = 0.1f;
    public float nextShotTime;

    private Vector2 shootDirection = Vector2.down;

    private void Update()
    {
        UpdateShootDirection();
        UpdateShootPoint();
    }

    private void FixedUpdate()
    {
        Shoot();
    }

    private void UpdateShootDirection()
    {
        if(Input.GetKey(KeyCode.W))
            shootDirection = Vector2.up;
        else if(Input.GetKey(KeyCode.S))
            shootDirection = Vector2.down;
        else if (Input.GetKey(KeyCode.D))
            shootDirection = Vector2.right;
        else if (Input.GetKey(KeyCode.A))
            shootDirection = Vector2.left;
    }

    private void UpdateShootPoint()
    {
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        shootPoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (Time.time >= nextShotTime)
            {

                nextShotTime = Time.time + fireRate;

                float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
                GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.Euler(0, 0, angle));

                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = shootDirection * bulletSpeed;
            }
        }
    }
}
