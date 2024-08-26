using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using TMPro;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    private void OnEnable()
    {
        DamageHealth.OnHealthChanged += UpdateHealthUI;
        //CounterManager.OnBulletCountChanged += UpdateCount;
    }
    private void OnDisable()
    {
        DamageHealth.OnHealthChanged -= UpdateHealthUI;
        //CounterManager.OnBulletCountChanged -= UpdateCount;
    }
    private void UpdateHealthUI(float currentHealth)
    {
        timeText.text = $" Health: {currentHealth}";
        //timeText.text = $" Balas: {CounterManager.BulletCount}";
    }
}
