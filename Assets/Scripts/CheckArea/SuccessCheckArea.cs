using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SuccessCheckArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BasePlayerController>())
        {
            GameManager.Instance.AddSuccessPlayer();
            other.GetComponent<BasePlayerController>().SetRightSpeed(0);
        }

        if (other.GetComponent<LaserObject>())
        {
            LaserObject laser = other.GetComponent<LaserObject>();
            laser.SetDirection();
        }
    }
}
