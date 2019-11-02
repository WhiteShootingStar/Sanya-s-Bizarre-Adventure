﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoving : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);    
    }
}
