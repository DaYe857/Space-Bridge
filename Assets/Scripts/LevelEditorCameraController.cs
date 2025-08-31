using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorCameraController : MonoBehaviour
{
    public int index = 0;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField] 
    private List<Transform> cameraDatas;

    private Vector3 movement;

    private void Awake()
    {
        movement = Vector3.zero;
    }

    public void SetCameraPos(int index)
    {
        transform.position = cameraDatas[index].position;
        transform.rotation = cameraDatas[index].rotation;
    }

    private void LateUpdate()
    {
        MoveCamera();
        ScaleCamera();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            index++;
            if (index == cameraDatas.Count)
            {
                index = 0;
            }
            SetCameraPos(index);

        }
    }

    private void MoveCamera()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        switch (index)
        {
            case 0:
                movement = new Vector3(xAxis, yAxis, 0.0f);
                break;
            case 1:
                movement = new Vector3(0.0f, yAxis, -xAxis);
                break;
            case 2:
                movement = new Vector3(-xAxis, yAxis, 0.0f);
                break;
            case 3:
                movement = new Vector3(0.0f, yAxis, xAxis);
                break;
            case 4:
                movement = new Vector3(xAxis, 0.0f, yAxis);
                break;
            case 5:
                movement = new Vector3(xAxis, 0.0f, -yAxis);
                break;
            default:
                movement = Vector3.zero;
                break;
                
        }
        
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
    
    private void ScaleCamera()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 10)
            {
                Camera.main.fieldOfView -= 2;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView < 60)
            {
                Camera.main.fieldOfView += 2;
            }
        }
    }
}
