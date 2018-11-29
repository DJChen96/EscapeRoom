using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class timeMagic : MonoBehaviour
{

    [SteamVR_DefaultActionSet("default")]
    public SteamVR_ActionSet actionSet;

    [SteamVR_DefaultAction("move", "default")]
    public SteamVR_Action_Vector2 a_move;

    public float old_minutes_float;

    public wandController wc;
    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f;

    public Transform minutes;
    public Transform hours;
    public Vector3 movement;
    public Vector2 old;
    public float turnAmount;

    public float old_eulerAngle;
    public float deltaEuler;
    public ClockTimeController clockPrefab;//This is the clock controlled on the wall;

    public float minutes_float;


    void Start()
    {

        old_minutes_float = minutes_float = clockPrefab.minutes_float;

        old = new Vector2(0f,0f);
        if (clockPrefab == null)
            clockPrefab = FindObjectOfType<ClockTimeController>();

        wc = FindObjectOfType<wandController>();
    }

    void Update()
    {
        if (wc.timeMode)
        {
            {
                clockPrefab.controlled = true;
                Debug.Log("Attached completed");
                old_minutes_float = minutes_float = clockPrefab.minutes_float;
                Vector2 m = a_move.GetAxis(SteamVR_Input_Sources.RightHand);
                
                //movement = new Vector3(m.x, 0, m.y);
                movement = new Vector3(m.x, 0, m.y);
                //Vector2.Dot();
                turnAmount = Mathf.Atan2(movement.x, movement.z);
                
                //old_eulerAngle = 0;
                //deltaEuler =  Mathf.Acos(Vector3.Dot(movement, new Vector3(0.0f, 0.0f, 1.0f)))-1.57f-old_eulerAngle;
                deltaEuler = turnAmount;
                clockPrefab.deltaMinutes = deltaEuler*Time.deltaTime*2;
                //old_eulerAngle = Mathf.Acos(Vector3.Dot(movement, new Vector3(0.0f, 0.0f, 1.0f)));
                old_eulerAngle = turnAmount;
                old = m;

            }
        }
        else {
            clockPrefab.controlled = false;
        }

    }   

    


}