using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class timeMagic : MonoBehaviour
{
    public wandController wc;
    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f;

    public Transform minutes;
    public Transform hours;
    public Transform seconds;

    public clock clockPrefab;

    float hour;
    float minute;
    float second;

    void Start()
    {
        if (clockPrefab == null)
            clockPrefab = FindObjectOfType<clock>();
        wc = FindObjectOfType<wandController>();
        hour = 11f;
        minute = 30f;
        second = 0f;
    }

    void Update()
    {
        
            
        
    }

    private void FixedUpdate()
    {
       

        hour += (Time.deltaTime * Time.deltaTime * Time.deltaTime);
        minute += (Time.deltaTime*Time.deltaTime);
        second += Time.deltaTime;

       
    }

   


}