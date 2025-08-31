using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rightSpeed = 0.5f;
    public bool isSelfMovement = true;
    private Collider collider;

    private void Start()
    {
        //rightSpeed = PlayerPrefs.GetFloat("RightSpeed", 1f);
        collider = GetComponent<CapsuleCollider>();
        collider.enabled = false;
        StartCoroutine(DelayRB());
    }

    IEnumerator DelayRB()
    {
        yield return new WaitForSeconds(3f);
        collider.enabled = true;
    }

    private void OnEnable()
    {
        EventHandler.LoseGameEvent += () => { enabled = false; };
        EventHandler.WinGameEvent += () => { enabled = false; };
    }

    private void OnDisable()
    {
        EventHandler.LoseGameEvent -= () => { enabled = false; };
        EventHandler.WinGameEvent -= () => { enabled = false; };
    }

    private void Update()
    {
        if (rightSpeed <= 0f)
        {
            rightSpeed = 0.1f;
        }
    }

    public void SetRightSpeed() => rightSpeed *= 2;
    
    public void SetRightSpeed(float rightSpeed) => this.rightSpeed = rightSpeed;
    
    public void ReduceRightSpeed(float speed) => rightSpeed -= speed;
    
    public void IncreaseMoveSpeed(float speed) => moveSpeed += speed;
    
    public void DecreaseMoveSpeed(float speed) => moveSpeed -= speed;
}
