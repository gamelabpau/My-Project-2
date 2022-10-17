using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField]
    private SpawnCoin _spawnCoin;

    private void Start()
    {
        _spawnCoin = FindObjectOfType<SpawnCoin>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add points
            Debug.Log("10$");
            Destroy(gameObject);
            _spawnCoin.spawnNewCoin();
        }
    }
}
