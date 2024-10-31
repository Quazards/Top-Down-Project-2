using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private Health _health;
    private SpriteRenderer sprite;
    [SerializeField] private float duration;

    private void Awake()
    {
        _health = GetComponent<Health>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void StartInvincibility(float duration)
    {
        StartCoroutine(invinciblityCoroutine(duration));
    }

    private IEnumerator invinciblityCoroutine(float invincibilityDuration)
    {
        _health.isInvincible = true;
        sprite.color = Color.red;
            yield return new WaitForSeconds(invincibilityDuration);
        sprite.color = Color.white;
        _health.isInvincible = false;
    }
}
