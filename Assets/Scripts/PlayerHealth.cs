using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private PlayerHPSO playerHealth;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        healthBar.value = playerHealth.PlayerHp;
    }

    public void TakeDamage(float damageAmount)
    {
        //health = health - damageAmount;
        
        playerHealth.PlayerHp -= damageAmount;
        healthBar.value = playerHealth.PlayerHp;
        if (playerHealth.PlayerHp <= 0f)
        {
            // die
            Destroy(gameObject);
            gameManager.EndLevel("You die! Game Over", false);
        }   
    }
    
}
