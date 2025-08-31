using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int successPlayer = 0;
    private float leftTime = 30f;

    private void Awake()
    {
        if(Instance == null){Instance = this;}
        else{Destroy(gameObject);}
    }

    private void OnEnable()
    {
        EventHandler.LoseGameEvent += PauseGame;
        EventHandler.WinGameEvent += PauseGame;
    }

    private void OnDisable()
    {
        EventHandler.LoseGameEvent -= PauseGame;
        EventHandler.WinGameEvent -= PauseGame;
    }

    public void AddSuccessPlayer()
    {
        successPlayer++;
        if (successPlayer == 1)
        {
            UIManager.Instance.ShowGameTimer();
        }
        if (successPlayer == 2)
        {
            EventHandler.WinGame();
            PlayerPrefs.SetFloat("RightSpeed", PlayerPrefs.GetFloat("RightSpeed")*2);
        }
    }
    private void PauseGame() => Time.timeScale = 0;
    public void ResumeGame() => Time.timeScale = 1;
    
    public void AddLeftTime(float time) => leftTime += time; 
    
    public float GetLeftTime() => leftTime;
}
