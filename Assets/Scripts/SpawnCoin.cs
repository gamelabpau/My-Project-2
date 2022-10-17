using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCoin : MonoBehaviour
{
    private int coinCount = 0;
    
    [SerializeField]
    private GameObject coinPrefab;

    private int xMin = -5;
    private int xMax = 20;
    private int zMin = 17;
    private int zMax = 35;
    private int yInicial = 9;
    
    private void Start()
    {
        spawnNewCoin();
    }

    public void spawnNewCoin()
    {
        if (coinCount < 5)
        {
            int xOffset = Random.Range(xMin, xMax);
            int zOffset = Random.Range(zMin, zMax);
            Vector3 offset = new Vector3(xOffset, yInicial, zOffset);
            Instantiate(coinPrefab, offset, Quaternion.identity);
            coinCount++;
            Debug.Log($"You have ${coinCount*10}");
        }
        else
        {
            Debug.Log("Congrats. You win!");
        }
    }
}
