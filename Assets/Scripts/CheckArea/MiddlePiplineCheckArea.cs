using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePiplineCheckArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BasePlayerController>())
        {
            other.GetComponent<BasePlayerController>().SetRightSpeed();
        }
    }
}
