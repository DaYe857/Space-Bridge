using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimerCheckArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BasePlayerController>())
        {
            GameManager.Instance.AddLeftTime(3f);
            gameObject.SetActive(false);
        }
    }
}
