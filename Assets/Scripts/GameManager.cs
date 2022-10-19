using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Cached references
    private SpawnCoin _spawnCoin;
    [SerializeField] private TextMeshProUGUI _txtCoins;
    
    private void Start()
    {
        _spawnCoin = FindObjectOfType<SpawnCoin>();
    }

    private int coinCount = 0;
    
    public void IncrementarMonedas()
    {
        if (coinCount < 5)
        {
            coinCount++;
            // Debug.Log($"You have ${coinCount*10}");
            _txtCoins.text = "$ " + coinCount * 10;
            _spawnCoin.SpawnNewCoin();
        }
        else
        {
            Debug.Log($"You win!");
        }
    }
}
