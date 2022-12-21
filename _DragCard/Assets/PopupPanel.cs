using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PopupPanel : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Text msgText;
    
    private void Awake()
    {
        restartButton.onClick.AddListener(restartGame);
        quitButton.onClick.AddListener(quitGame);
    }

    private void quitGame()
    {
        Application.Quit();
    }

    private void restartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void MsgBox(string msg)
    {
        msgText.text = msg;
    }
}
