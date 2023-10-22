using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGameController : MonoBehaviour
{
    [Header("InGame Panel")]
    public GameObject WinPanel;
    public GameObject LostPanel;
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
    #endregion

}