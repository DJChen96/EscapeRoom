﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTimeController : MonoBehaviour {
    public static bool time_stop = false;
    public GameObject centre;
    public GameObject hour_hand;
    public GameObject minute_hand;
    public GameObject pendulum;
    public PumpkinCarriageController pumpkinCarriageController;
    public float minutes_float = 690;
    public float deltaMinutes;
    public bool controlled = false;

    

    private float pendulu_max_degree = 10;
    private float pendulu_speed = 10;
    private float pendulu_degree = 0;
    private int pendulu_direction = 1;
    private Vector3 cenre_position;

    public AudioClip bellAudioClip;
    public SoundEffectAudioSource soundEffectAudioSource;

    public void SetTime(float given_minutes_float)
    {
        hour_hand.transform.RotateAround(cenre_position, new Vector3(0, 0, 1), given_minutes_float * 0.5f);
        minute_hand.transform.RotateAround(cenre_position, new Vector3(0, 0, 1), given_minutes_float * 6);
    }


    // Use this for initialization
    void Start () {
        cenre_position = centre.transform.position;
        zeroing();
        hour_hand.transform.RotateAround(cenre_position, new Vector3(0, 0, 1), minutes_float *0.5f );
        minute_hand.transform.RotateAround(cenre_position, new Vector3(0, 0, 1), minutes_float * 6);
    }
	
	// Update is called once per frame
	void Update () {
        Clock_Rotation();
    }

    void zeroing()
    {
        //Zeroing 
        hour_hand.transform.RotateAround(cenre_position, new Vector3(0, 0, 1), 70);
        minute_hand.transform.RotateAround(cenre_position, new Vector3(0, 0, 1), 103);
    }

    void Clock_Rotation()
    {
        //Clock rotation
        if (controlled)
        {
            SetTime(deltaMinutes);
            minutes_float += deltaMinutes;
        }

        minutes_float += Time.deltaTime / 60;
        minutes_float = minutes_float > 720 ? minutes_float - 720 : minutes_float;

        hour_hand.transform.RotateAround(cenre_position, new Vector3(0, 0, 1), (0.1f / 12f) * Time.deltaTime);
        minute_hand.transform.RotateAround(cenre_position, new Vector3(0, 0, 1), 0.1f * Time.deltaTime);

        //Pendulu animation
        pendulu_speed = (20 - Mathf.Abs(pendulu_degree)) / 2;
        if (pendulu_direction == 1)
        {
            pendulu_degree += pendulu_speed * Time.deltaTime;
            pendulum.transform.RotateAround(cenre_position, new Vector3(0, 0, 1), pendulu_speed * Time.deltaTime);
            pendulu_direction = pendulu_degree > pendulu_max_degree ? -pendulu_direction : pendulu_direction;
        }
        else
        {
            pendulu_degree -= pendulu_speed * Time.deltaTime;
            pendulum.transform.RotateAround(cenre_position, new Vector3(0, 0, 1), -pendulu_speed * Time.deltaTime);
            pendulu_direction = pendulu_degree < -pendulu_max_degree ? -pendulu_direction : pendulu_direction;
        }


       
        // music

        // Carriage to Pumpkin 
        if (minutes_float > 718 || minutes_float < 2)
        {
            pumpkinCarriageController.CarriageChange();
            soundEffectAudioSource.Play(bellAudioClip);
        }
    }
}
