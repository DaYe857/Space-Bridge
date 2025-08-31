using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    [SerializeField]
    private string tag;
    
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        StartCoroutine(DelayCloseRB());
    }

    IEnumerator DelayCloseRB()
    {
        yield return new WaitForSeconds(3f);
        Destroy(rb);
    }

    public string GetObjecctTag() => tag;
}
