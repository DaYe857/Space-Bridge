using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateX : MonoBehaviour
{
    [SerializeField] 
    private float rotationSpeed = 10f;
    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
