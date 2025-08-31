using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserObject : MonoBehaviour
{
    [SerializeField] 
    private float speed;
    private Vector3 direction;
    private int mainLayer;
    private int anotherLayer;

    private void Awake()
    {
        mainLayer = LayerMask.NameToLayer("Main");
        anotherLayer = LayerMask.NameToLayer("Another");
        direction = Vector3.up;
        gameObject.layer = mainLayer;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection()
    {
        direction = -direction;
        if (gameObject.layer == mainLayer)
        {
            gameObject.layer = anotherLayer;
            return;
        }

        if (gameObject.layer == anotherLayer)
        {
            gameObject.layer = mainLayer;
        }
    }
}
