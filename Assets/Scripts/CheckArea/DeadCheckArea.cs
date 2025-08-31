using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class DeadCheckArea : MonoBehaviour
{
    [SerializeField] 
    private float speed = 0.2f;

    [SerializeField] 
    private GameObject targetObject;
    
    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetObject)
        {
            EventHandler.LoseGame();
        }
    }
}
