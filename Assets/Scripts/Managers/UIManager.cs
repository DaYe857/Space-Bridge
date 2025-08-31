using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] 
    private GameObject gameTimer;
    [SerializeField] 
    private GameObject losePanel;
    [SerializeField]
    private GameObject winPanel;

    private void Awake()
    {
        if(Instance == null){Instance = this;}
        else{Destroy(gameObject);}
    }

    private void OnEnable()
    {
        EventHandler.LoseGameEvent += () => losePanel.SetActive(true);
        EventHandler.WinGameEvent += () => winPanel.SetActive(true);
    }

    private void OnDisable()
    {
        EventHandler.LoseGameEvent -= () => losePanel.SetActive(true);
        EventHandler.WinGameEvent -= () => winPanel.SetActive(true);
    }
    
    public void ShowGameTimer() => gameTimer.SetActive(true);
}
