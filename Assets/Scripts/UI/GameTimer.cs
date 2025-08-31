using UnityEngine;
using System;
using UnityEngine.UI;

/// <summary>
/// 游戏计时器单例类，用于管理游戏中的时间。
/// </summary>
public class GameTimer : MonoBehaviour
{
    public static GameTimer instance;
    private float gameTime;
    private Text timelineText;
    private float currentTime = 0f; // 当前经过的时间
    private bool isRunning = false; // 计时器是否正在运行
    private float pauseTime = 0f;   // 暂停时的时间

    public string GameLeftTime => FormatTime(gameTime-currentTime);
    bool isPasued=false;
    bool isPlay = false;

    private void Awake()
    {
        if(instance == null)
        instance = this;
        else{ Destroy(gameObject);}

        gameTime = GameManager.Instance.GetLeftTime();
        timelineText = transform.GetChild(0).GetComponent<Text>();
    }

    private void OnEnable()
    {
        EventHandler.WinGameEvent += end;
        EventHandler.LoseGameEvent += end;
    }

    private void OnDisable()
    {
        EventHandler.WinGameEvent -= end;
        EventHandler.LoseGameEvent -= end;
    }

    public void Start()
    {
        StartTimer();
    }

    /// <summary>
    /// 开始计时器。
    /// </summary>
    public void StartTimer()
    {
        isPasued = false;
        isRunning = true;
    }
    /// <summary>
    /// 暂停计时器。
    /// </summary>
    public void PauseTimer()
    {
        isRunning = false;
        isPasued = true;
        pauseTime = currentTime;
    }

    private void end( )
    {   
        isPasued=true;
        isRunning = false;
    }

    /// <summary>
    /// Unity生命周期方法，每帧调用一次。
    /// </summary>
    private void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
            timelineText.text = GameLeftTime;
        }
        else
        {
            if (isPasued)
            {
                PauseTimer();
            }
        }

        if ((gameTime - currentTime) < 5f && isPlay == false)
        {
            isPlay = true;
        }

        if (currentTime > gameTime) 
        {
            EventHandler.LoseGame();
            currentTime = 0;
            Debug.Log(1);
        }
    }


    /// <summary>
    /// 将给定的时间（以秒为单位）格式化为“分:秒”形式。
    /// </summary>
    /// <param name="timeInSeconds">要格式化的时间，以秒为单位。</param>
    /// <returns>格式化后的时间字符串。</returns>
    private string FormatTime(float timeInSeconds)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);
        return string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
    }

    public string GetLeftTime() => FormatTime(currentTime);
    public void SetGameTime(float time) => gameTime = time;
}