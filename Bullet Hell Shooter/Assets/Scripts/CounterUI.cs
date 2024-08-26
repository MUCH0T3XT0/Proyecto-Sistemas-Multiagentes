using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using TMPro;

public class CounterUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    private void OnEnable()
    {
        CounterManager.OnBulletCountChanged += UpdateCount;
    }
    private void OnDisable()
    {
        CounterManager.OnBulletCountChanged -= UpdateCount;
    }
    private void UpdateCount()
    {
        timeText.text = $" Balas: {CounterManager.BulletCount}";
    }
}
