﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerEffect : MonoBehaviour
{
    public DimFire timer;
    public GameObject ball;
    public float speed;
    private bool turnOn = false;
    public float degree;
    // Start is called before the first frame update
    void Start()
    {
        ball.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer.getTimer > 0)
        {
            ball.SetActive(true);
            turnOn = true;
        }
        if(turnOn == true)
        {
            RotateCircle();
        }
        

    }

    public void RotateCircle()
    {
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * speed, degree)-90);
    }

    
}