using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSpeedCheckArea : BaseObject
{
    [SerializeField]
    private float rightSpeed;
    
    private void Start()
    {
        StartCoroutine(DelayCanTrigger());
    }

    IEnumerator DelayCanTrigger()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<CapsuleCollider>().isTrigger = true;
        
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<BasePlayerController>())
        {
            collision.GetComponent<BasePlayerController>().ReduceRightSpeed(rightSpeed);
        }
    }
}
