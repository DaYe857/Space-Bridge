using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLaserCheckArea : MonoBehaviour
{
    [SerializeField] 
    private GameObject laser;
    private bool isTriggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BasePlayerController>()&&isTriggered == false)
        {
            laser.SetActive(true);
            isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BasePlayerController>())
        {
            laser.SetActive(false);
        }
    }
}
