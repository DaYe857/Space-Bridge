using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] 
    private Button continueButton;

    [SerializeField] 
    private Button backToMainButton;

    private void Awake()
    {
        continueButton.onClick.AddListener(() => LSM.Instance.LoadNextScene(SceneName.GamePlay));
        backToMainButton.onClick.AddListener(() => {LSM.Instance.LoadNextScene(SceneName.Main);});
    }
}
