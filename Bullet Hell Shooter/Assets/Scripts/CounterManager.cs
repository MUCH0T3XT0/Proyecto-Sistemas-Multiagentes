using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class CounterManager
{
    public static int BulletCount = 0;

    public static event System.Action OnBulletCountChanged;

    public static void IncrementBulletCount()
    {
        BulletCount++;
        OnBulletCountChanged?.Invoke();
    }

    public static void DecrementBulletCount()
    {
        BulletCount--;
        OnBulletCountChanged?.Invoke();
    }
}