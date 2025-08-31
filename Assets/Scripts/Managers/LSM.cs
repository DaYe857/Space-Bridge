using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneName
{
    public const string GamePlay = "GamePlay";
    public const string Main = "Main";
}

public class LSM : MonoBehaviour
{
    public static LSM Instance;
    private void Awake()
    {
        if(Instance == null){Instance = this;}
        else{Destroy(gameObject);}
    }

    public void LoadNextScene(string sceneName)
    {
        GameManager.Instance.ResumeGame();
        SceneManager.LoadSceneAsync(sceneName);
    }
}
