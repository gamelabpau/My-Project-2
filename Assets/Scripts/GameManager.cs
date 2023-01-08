using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // private float health = 100.0f;
    private bool win = false;
    private int level = 0;
    private int coinCount = 0;
    
    // Cached references
    private SpawnCoin _spawnCoin;
    [SerializeField] private TextMeshProUGUI _txtCoins;
    [SerializeField] private TextMeshProUGUI _txtWinMessage;
    [SerializeField] private Button _btnOk;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        InitLevel();
    }

    private void InitLevel()
    {
        win = false;
        _spawnCoin = FindObjectOfType<SpawnCoin>();
        _txtWinMessage.gameObject.SetActive(false);
        _btnOk.onClick.AddListener(GameOver);
        _btnOk.gameObject.SetActive(false);
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
        }
    }
    
    private void GameOver()
    {
        if (level == 1 && win)
        {
            win = false;
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
        InitLevel();
    }
    
    public void IncrementarMonedas()
    {
        if (level == 1)
        {
            if (coinCount < 3)
            {
                coinCount++;
                _txtCoins.text = "$ " + coinCount * 10;
                _spawnCoin.SpawnNewCoin();
            }
            else
            {
                coinCount++;
                _txtCoins.text = "$ " + coinCount * 10;
                if (!PlayerPrefs.HasKey("level"))
                {
                    level = 2;
                    PlayerPrefs.SetInt("level", level);
                    PlayerPrefs.Save();
                }
                EndLevel("Congratulations. Go to level 2!", true);
            }
        }
        else if (level == 2)
        {
            if (coinCount < 5)
            {
                coinCount++;
                _txtCoins.text = "$ " + coinCount * 10;
                _spawnCoin.SpawnNewCoin();
            }
            else
            {
                coinCount++;
                _txtCoins.text = "$ " + coinCount * 10;
                
                EndLevel("You win!", true);
            }
        }
    }

    public void EndLevel(string message, bool win)
    {
        this.win = win;
        _txtWinMessage.gameObject.SetActive(true);
        _txtWinMessage.text = message;
        _btnOk.gameObject.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
            
        //Pausar el juego
        Time.timeScale = 0;
    }
}
