using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TimeMagic : MonoBehaviour
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


    //public Transform minutes;
    //public Transform hours;
    public Vector3 movement;
    public Vector2 old;
    public float turnAmount;

    public float old_eulerAngle;
    public float deltaEuler;
    public ClockTimeController clockPrefab;//This is the clock controlled on the wall;
    public ClockTimeController theClockOnWand;
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
            clockPrefab.controlled = true;
            theClockOnWand.gameObject.SetActive(true);
            theClockOnWand.controlled = true;
            if (wc.time_triggered)
            {
                
                Vector2 m = a_move.GetAxis(SteamVR_Input_Sources.RightHand);
                movement = new Vector3(m.x, 0, m.y);
                turnAmount = Mathf.Atan2(movement.z, movement.x);

                float minutesFloat = XYCoordinationToMinutesFloat(m.x, m.y);
                clockPrefab.SetTime(minutesFloat);
                theClockOnWand.SetTime(minutesFloat);
                //old_minutes_float = minutes_float = clockPrefab.minutes_float;
                //Debug.Log(turnAmount);
                //old_eulerAngle = 0;
                //deltaEuler =  Mathf.Acos(Vector3.Dot(movement, new Vector3(0.0f, 0.0f, 1.0f)))-1.57f-old_eulerAngle;
                //deltaEuler = turnAmount;

                //clockPrefab.deltaMinutes = deltaEuler*Time.deltaTime*2;
                //old_eulerAngle = Mathf.Acos(Vector3.Dot(movement, new Vector3(0.0f, 0.0f, 1.0f)));
                //old_eulerAngle = turnAmount;
                //old = m;

                //Vector2.Dot();

                var array = this.gameObject.GetComponentsInChildren<ParticleSystem>();
                foreach (ParticleSystem p in array)
                {
                    if (p.velocityOverLifetime.enabled)
                    {
                        var velocityOverLifetime = p.velocityOverLifetime;
                        velocityOverLifetime.orbitalY = turnAmount;
                    }
                }

            }
        }
        else {
            theClockOnWand.controlled = false;
            theClockOnWand.gameObject.SetActive(false);
            clockPrefab.controlled = false;
        }

    }


    private float last_input_time = 0;
    //private float old_miniuntOnController = 0;
    private float XYCoordinationToMinutesFloat(float x, float y)
    {
        float miniuntOnController;
        float arctandxdy = Mathf.Atan(x / y);


        if (x >= 0 && y >= 0)
        {
            miniuntOnController = arctandxdy * (30 / Mathf.PI);
        }
        else if (x < 0 && y >= 0)
        {
            miniuntOnController = (2 * Mathf.PI + arctandxdy) * (30 / Mathf.PI);
        }
        else
        {
            miniuntOnController = (Mathf.PI + arctandxdy) * (30 / Mathf.PI);
        }


        float time_diff = last_input_time == 0 ? 0 : Time.time - last_input_time;

        float miniuntOnClock = minutes_float % 60;
        float hourOnClock = (minutes_float - miniuntOnClock) / 60;

        if (time_diff < 0.5f)
        {
            if (57 <= miniuntOnClock && miniuntOnClock <= 60 && 0 <= miniuntOnController && miniuntOnController <= 3)
            {
                hourOnClock = hourOnClock == 11 ? 0 : hourOnClock + 1;
            }
            if (57 <= miniuntOnController && miniuntOnController <= 60 && 0 <= miniuntOnClock && miniuntOnClock <= 3)
            {
                hourOnClock = hourOnClock == 0 ? 11 : hourOnClock - 1;
            }
        }

        last_input_time = Time.time;
        return hourOnClock * 60 + miniuntOnController;
    }


}