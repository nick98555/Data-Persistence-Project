using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{

    public Text HighScoreText;

    private void Start()
    {
        LoadHighScore();
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
                Application.Quit(); // original code to quit Unity player
#endif

        MainManager.Instance.SaveHighScore();
    }

    public void LoadHighScore()
    {
        int highscore = MainManager.Instance.getHighScore();
        HighScoreText.text = $"Best Score : {highscore.ToString()}";
    }
}

