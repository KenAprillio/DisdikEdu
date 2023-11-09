using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_InGameController : MonoBehaviour
{
    [Header("InGame Panel")]
    public GameObject WinPanel;
    public GameObject LostPanel;

    [SerializeField] AudioMixer audioMixer;

    int enemyDead = 0;
    public static UI_InGameController Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddDefeatedEnemies()
    {
        enemyDead++;

        if (enemyDead >= 3)
        {
            ShowWinPanel();
        }
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #region InGamePanel UI Script

    public void ShowWinPanel()
    {
        WinPanel.SetActive(true);
    }

    public void HideWinPanel ()
    {
        WinPanel.SetActive(false);
    }

    public void ShowLostPanel()
    {
        LostPanel.SetActive(true);
    }

    public void HideLostPanel()
    {
       LostPanel.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("mainVolume", volume);
    }
    #endregion

}