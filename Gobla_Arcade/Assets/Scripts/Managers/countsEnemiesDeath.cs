using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class countsEnemiesDeath : MonoBehaviour
{
    private int totalEnemiesLevel;
    private int actualEnemiesDeath = 0;

    private void Start()
    {
        GameObject[] EnemiesLevel = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemiesLevel = EnemiesLevel.Length;
    }

    public void addDeathEnemy()
    {
        actualEnemiesDeath++;
        AreAllEnemiesDeath();
    }

    private void AreAllEnemiesDeath()
    {
        if (totalEnemiesLevel == actualEnemiesDeath)
        {
            SceneManager.LoadScene("WinMenu");
        }
    }
}
