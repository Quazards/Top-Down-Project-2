using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 3f;
    public int damage = 50;

    private void Start()
    {
        Destroy(gameObject, lifetime);
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            var health = collision.GetComponent<Health>();
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
