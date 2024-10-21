using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float enemySpeed = 0.3f;
    public int enemyHealth = 200;

    private SpriteRenderer enemySprite;
    private bool isFacingLeft;

    private void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        player = FindAnyObjectByType<PlayerController>().transform;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.fixedDeltaTime);
        FlipSprite();
    }

    private void Flip()
    {
        isFacingLeft = !isFacingLeft;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void FlipSprite()
    {
        if(player.position.x < transform.position.x && isFacingLeft)
        {
            Flip();
        }
        else if(player.position.x > transform.position.x && !isFacingLeft)
        {
            Flip();
        }
    }

    private void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator FlashRed()
    {
        enemySprite.color = Color.red;
        yield return new WaitForSecondsRealtime(0.5f);
        enemySprite.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            TakeDamage(collision.GetComponent<Bullet>().damage);
            StartCoroutine(FlashRed());
        }
    }
}
