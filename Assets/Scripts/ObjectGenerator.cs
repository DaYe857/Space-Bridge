using System;
using System.Collections;
using System.Collections.Generic;
using Mirror.Examples.RigidbodyBenchmark;
using UnityEngine;
using Object = System.Object;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] 
    private string objectTag;
    
    [SerializeField]
    private Transform generationPoint;

    [SerializeField] 
    private int frequency = 10;
    
    private int generateCount = 0;

    private void Start()
    {
        generateCount = ObjectPoolManager.Instance.GetPoolSize(objectTag);
        for (int i = 0; i < generateCount; i++)
        {
            GameObject obj = ObjectPoolManager.Instance.SpawnFromPool(objectTag,transform.position,Quaternion.identity);
            obj.GetComponent<Rigidbody>().AddForce(generationPoint.right * frequency);
        }

    }
}
