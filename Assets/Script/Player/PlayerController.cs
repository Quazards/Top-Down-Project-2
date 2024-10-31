using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 movementInput;
    public Rigidbody2D rb;
    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.05f;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //animation
        animator.SetFloat("Horizontal", movementInput.x);
        animator.SetFloat("Vertical", movementInput.y);

        if(movementInput != Vector2.zero)
        {
            animator.SetFloat("RecentHorizontal", movementInput.x);
            animator.SetFloat("RecentVertical", movementInput.y);
        }

    }

    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            bool success = moveCheck(movementInput);

            if (!success && movementInput.x > 0)
            {
                success = moveCheck(new Vector2(movementInput.x, 0));

                if (!success && movementInput.y > 0)
                {
                    success = moveCheck(new Vector2(0, movementInput.y));
                }
            }

        }
       
    }

    private void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    private void OnFire()
    {
        animator.SetTrigger("gunShoot");
    }

    private bool moveCheck(Vector2 direction)
    {
            int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else return false;
    }

    public void playerDeath()
    {
        animator.SetTrigger("playerDeath");
    }
}
