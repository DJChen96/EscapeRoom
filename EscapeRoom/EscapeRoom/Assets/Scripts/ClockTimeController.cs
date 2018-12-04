using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTimeController : MonoBehaviour
{
    public static bool time_stop = false;
    public GameObject centre;
    public GameObject hour_hand;
    public GameObject minute_hand;
    public GameObject pendulum;
    public PumpkinCarriageController pumpkinCarriageController;
    public float minutes_float = 690;
    public float deltaMinutes;
    public bool controlled = false;

    private readonly float pendulu_max_degree = 10;
    private float pendulu_speed = 10;
    private float pendulu_degree = 0;
    private int pendulu_direction = 1;
    private Vector3 centre_position;

    public AudioClip bellAudioClip;
    public SoundEffectAudioSource soundEffectAudioSource;

    public void SetTime(float given_minutes_float)
    {
        given_minutes_float = given_minutes_float > 720 ? given_minutes_float - 720 : given_minutes_float;

        float miuntes_float_change = given_minutes_float - minutes_float;
        hour_hand.transform.RotateAround(centre_position, new Vector3(0, 0, 1), miuntes_float_change * 0.5f);
        minute_hand.transform.RotateAround(centre_position, new Vector3(0, 0, 1), miuntes_float_change * 6);
        minutes_float = given_minutes_float;
    }


    // Use this for initialization
    void Start()
    {
        centre_position = centre.transform.position;
        Zeroing();
        hour_hand.transform.RotateAround(centre_position, new Vector3(0, 0, 1), minutes_float * 0.5f);
        minute_hand.transform.RotateAround(centre_position, new Vector3(0, 0, 1), minutes_float * 6);
    }

    // Update is called once per frame
    void Update()
    {
        if (controlled) return;
        Clock_Rotation();


        if (gameController.debugMode == false || true)
            return;

    }




    void Zeroing()
    {
        //Zeroing 
        hour_hand.transform.RotateAround(centre_position, new Vector3(0, 0, 1), 70);
        minute_hand.transform.RotateAround(centre_position, new Vector3(0, 0, 1), 103);
    }

    void Clock_Rotation()
    {
        // Carriage to Pumpkin 
        if ((minutes_float > 718 || minutes_float < 2))
        {
            if (pumpkinCarriageController)
                pumpkinCarriageController.CarriageChange();
            if (soundEffectAudioSource && bellAudioClip)
                soundEffectAudioSource.Play(bellAudioClip);
        }

        minutes_float += Time.deltaTime / 60;
        minutes_float = minutes_float > 720 ? minutes_float - 720 : minutes_float;

        hour_hand.transform.RotateAround(centre_position, new Vector3(0, 0, 1), (0.1f / 12f) * Time.deltaTime);
        minute_hand.transform.RotateAround(centre_position, new Vector3(0, 0, 1), 0.1f * Time.deltaTime);

        //Pendulu animation
        if (!pendulum) return;
        pendulu_speed = (20 - Mathf.Abs(pendulu_degree)) / 2;
        if (pendulu_direction == 1)
        {
            pendulu_degree += pendulu_speed * Time.deltaTime;
            pendulum.transform.RotateAround(centre_position, new Vector3(0, 0, 1), pendulu_speed * Time.deltaTime);
            pendulu_direction = pendulu_degree > pendulu_max_degree ? -pendulu_direction : pendulu_direction;
        }
        else
        {
            pendulu_degree -= pendulu_speed * Time.deltaTime;
            pendulum.transform.RotateAround(centre_position, new Vector3(0, 0, 1), -pendulu_speed * Time.deltaTime);
            pendulu_direction = pendulu_degree < -pendulu_max_degree ? -pendulu_direction : pendulu_direction;
        }

    }
}
