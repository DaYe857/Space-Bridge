using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 3.0f;
    public float distance = 5.0f;
    public float height = 2.0f;
    private float currentRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate() {
        // ������ˮƽ��ת
        currentRotation += Input.GetAxis("Mouse X") * rotationSpeed;
        // �������λ�ã���������ϵ��
        Vector3 dir = new Vector3(0, height, -distance);
        Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);
        transform.position = target.position + rotation * dir;
        transform.LookAt(target);
    }
}
