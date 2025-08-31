using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    [SerializeField]
    private Button restartButton;

    [SerializeField] 
    private Button backToMainButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(() => {LSM.Instance.LoadNextScene(SceneName.GamePlay);});
        backToMainButton.onClick.AddListener(() => {LSM.Instance.LoadNextScene(SceneName.Main);});
    }
}
