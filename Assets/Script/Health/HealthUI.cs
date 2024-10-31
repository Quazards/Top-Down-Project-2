using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image healthBarForeground;

    public void UpdateHealthBar(Health _health)
    {
        healthBarForeground.fillAmount = _health.RemainingHealthPercentage; 
    }
}
