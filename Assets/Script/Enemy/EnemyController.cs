using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float enemySpeed = 0.3f;
    private Animator animator;

    private SpriteRenderer enemySprite;
    private bool isFacingLeft;

    private void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        player = FindAnyObjectByType<PlayerController>().transform;
        animator = GetComponent<Animator>();
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

    public void EnemyDeath()
    {
        animator.SetTrigger("enemyDeath");
    }

    private void RemoveEnemy()
    {
        Destroy(gameObject);
    }
}
