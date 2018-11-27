using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class clock : MonoBehaviour {

    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f;
        
    public Transform hours;
    public Transform minutes;


    public bool controlled;

    public float hour;
    public float minute;

    public float deltaEuler;

    public float deltaMinute;

    void Start()
    {
        
        hour = 11;
        minute = 30;
        deltaEuler = 0;
       
        controlled = false;

        hours.eulerAngles = new Vector3(0, 0, hour * -hoursToDegrees);
        minutes.eulerAngles = new Vector3(0, 0, minute * -minutesToDegrees);

    }

    void Update()
    {

        hours.eulerAngles = new Vector3(0, 0, hour * -hoursToDegrees);
        minutes.eulerAngles = new Vector3(0, 0, minute * -minutesToDegrees);

        if (!controlled)
        {
            minute += Time.deltaTime / 60;
            hour += (int)minute/60;
        }// In update
        else if (controlled)
        {
            if (hour == 12) {
                Debug.Log("------YEAH------");
            }
            minute += (deltaEuler%359f);
            Debug.Log(hour+" " + deltaEuler);
            
            hour += (deltaEuler % 359f) / 60;
        }
        if (minute < 0)
            minute = 59.99f;
        //Debug.Log((int)hour);
        hour = Math.Abs(hour % 12);
        minute = minute % 60;

    }

    private void FixedUpdate()
    {

       


        


    }
}
