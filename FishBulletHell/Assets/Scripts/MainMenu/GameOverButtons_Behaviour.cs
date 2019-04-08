using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverButtons_Behaviour : MonoBehaviour
{
    public Button restartButton;
    public Button mainMenuButton;

    void Start() {
        restartButton.onClick.AddListener(RestartOnClick);
        mainMenuButton.onClick.AddListener(MainMenuOnClick);
    }

    void RestartOnClick() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainGame");
    }

    void MainMenuOnClick() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
