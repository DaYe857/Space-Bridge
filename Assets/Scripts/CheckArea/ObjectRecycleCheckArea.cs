using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRecycleCheckArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BaseObject>())
        {
            BaseObject obj = other.GetComponent<BaseObject>();
            ObjectPoolManager.Instance.ReturnToPool(obj.GetObjecctTag(),obj.gameObject);
        }
    }
}
