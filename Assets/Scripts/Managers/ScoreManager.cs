using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : Singleton<ScoreManager>
{
    public int totalPearlsAvailable = 10;
    private int remainingPearls;
    public int RemainingPearls 
    { 
        get
        {
            if (remainingPearls > 0)
                return remainingPearls;
            else
                return 0;
        } 
    }

    public Action<int> OnPearlLose;

    private void Start()
    {
        remainingPearls = totalPearlsAvailable;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyBase enemy = other.gameObject.GetComponent<EnemyBase>();
            Destroy(enemy.gameObject);
            remainingPearls -= 1;
            OnPearlLose?.Invoke(1);
        }
    }
}
