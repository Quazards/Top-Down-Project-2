using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int enemyDamageAmount;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("player"))
        {
            var health = collision.gameObject.GetComponent<Health>();

            health.TakeDamage(enemyDamageAmount);

            Debug.Log("Attacking player");
        }
    }
}
