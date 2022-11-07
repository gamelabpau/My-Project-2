using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Button _btnGoToMainMenu;
    [SerializeField] private Button _btnPlayLevel1;
    [SerializeField] private Button _btnQuitGame;
    
    // Start is called before the first frame update
    void Start()
    {
        _btnGoToMainMenu.onClick.AddListener(GoToMainMenu);
        _btnPlayLevel1.onClick.AddListener(PlayLevel1);
        _btnQuitGame.onClick.AddListener(QuitGame);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    private void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    
    private void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
