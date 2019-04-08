using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_Behaviour : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    void Start() {
        playButton.onClick.AddListener(TaskOnClick);
        quitButton.onClick.AddListener(QuitOnClick);
    }

    void TaskOnClick() {
        SceneManager.LoadScene("MainGame");
    }

    void QuitOnClick() {
        Application.Quit();
    }
}
