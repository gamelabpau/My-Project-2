using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float health = 100.0f;

    // Cached references
    private SpawnCoin _spawnCoin;
    [SerializeField] private TextMeshProUGUI _txtCoins;
    [SerializeField] private TextMeshProUGUI _txtWinMessage;
    [SerializeField] private Button _btnReiniciar;
    [SerializeField] private GameObject _player;
    [SerializeField] private Slider _healthBar;
    private bool win = false;
    [SerializeField] private int level = 0;

    private void Start()
    {
        _spawnCoin = FindObjectOfType<SpawnCoin>();
        _txtWinMessage.gameObject.SetActive(false);
        _btnReiniciar.onClick.AddListener(GameOver);
        _btnReiniciar.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        if (!PlayerPrefs.HasKey("level"))
        {
            level = 1;
            PlayerPrefs.SetInt("level", level);
            PlayerPrefs.Save();
        }
        else
        {
            level = PlayerPrefs.GetInt("level");
            if ( level == 1)
            {
                // nivell 1
            }
            else if (level == 2)
            {
                // nivell 2
            }
            else
            {
                // ERROR
            }
        }
    }

    private void ReiniciarNivel()
    {
        SceneManager.LoadScene(0);
    }

    private void GameOver()
    {
        if (level == 1 && win)
        {
            PlayerPrefs.SetInt("level", 2);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Level2");
        }
        else //if (level == 1 && !win)
        {
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameOver");
        }
        // else if (level == 2 && win)
        // {
        //     // GameOver
        // }
        // else if (level == 2 && !win)
        // {
        //     // GameOver
        // }
    }
    
    public void takeDamage(float damageAmount)
    {
        health = health - damageAmount;
        _healthBar.value = health;
 
        if (health <= 0f)
        {
            // die
            Destroy(_player);
            EndLevel("You die! Game Over");
            win = false;
        }   
    }
    
    private int coinCount = 0;
    
    public void IncrementarMonedas()
    {
        if (coinCount < 1)
        {
            coinCount++;
            _txtCoins.text = "$ " + coinCount * 10;
            _spawnCoin.SpawnNewCoin();
        }
        else
        {
            win = true;
            if (level == 1)
            {
                EndLevel("Congratulations. Go to level 2!");
            }
            else if (level == 2)
            {
                EndLevel("You win!");
            }
        }
    }

    private void EndLevel(string message)
    {
        _txtWinMessage.gameObject.SetActive(true);
        _txtWinMessage.text = message;
        _btnReiniciar.gameObject.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
            
        //Pausar el juego
        Time.timeScale = 0;
    }
}
