using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : BasePlayerController
{
    private AnotherPlayerController anotherPlayerController;
    private void Awake()
    {
        anotherPlayerController = FindObjectOfType<AnotherPlayerController>();
    }

    public void Update()
    {
        if (isSelfMovement)
        {
            transform.Translate(Vector2.right * rightSpeed * Time.deltaTime);
            SelfMove();
        }

    }
    
    private void SelfMove()
    {
        float horizontal = Input.GetAxis("WASD_Horizontal"); // A/D �� [-1,1]
        //float vertical = Input.GetAxis("Vertical");     // W/S �� [-1,1]


        Vector3 movement = new Vector3(0f, anotherPlayerController.GetVertical(),-horizontal); // 3D����
        
        // ��׼����ֹб���ƶ�����
        if (movement.magnitude > 1f) movement.Normalize();

        // ����������ϵ�ƶ�
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    private void UnSelfMove()
    {
        float vertical = Input.GetAxis("Arrow_Vertical");     // W/S �� [-1,1]
        
        Vector3 movement = new Vector3(0f, vertical,anotherPlayerController.GetHorizontal()); // 3D����
        // Vector3 movement = new Vector3(horizontal, vertical, 0f); // 2D����

        // ��׼����ֹб���ƶ�����
        if (movement.magnitude > 1f) movement.Normalize();

        // ����������ϵ�ƶ�
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
    
    public float GetHorizontal() => Input.GetAxis("WASD_Horizontal");
    public float GetVertical() => Input.GetAxis("Arrow_Vertical");
    
}
