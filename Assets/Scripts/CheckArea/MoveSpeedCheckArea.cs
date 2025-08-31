using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveSpeedCheckArea : BaseObject
{
    [SerializeField] 
    private float moveSpeed = 5f;

    private void Start()
    {
        StartCoroutine(DelayCanTrigger());
    }

    IEnumerator DelayCanTrigger()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<CapsuleCollider>().isTrigger = true;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BasePlayerController>())
        {
            BasePlayerController player = other.GetComponent<BasePlayerController>();
            int rand =Random.Range(0, 1);
            if(rand == 0){player.IncreaseMoveSpeed(5f);}
            if(rand == 1){player.DecreaseMoveSpeed(5f);}
            gameObject.SetActive(false);
        }
    }
}
