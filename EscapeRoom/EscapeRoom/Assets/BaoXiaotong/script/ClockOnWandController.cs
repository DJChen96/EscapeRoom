using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockOnWandController : MonoBehaviour {

    public ClockTimeController clockTimeController;

    public Transform hour_hand;
    public Transform minute_hand;

    public float minutes_float = 690;

    // Use this for initialization
    void Start()
    {

        clockTimeController = FindObjectOfType<ClockTimeController>();
    }
    public void SetTime(float given_minutes_float)
    {

        float minuteOnClock = given_minutes_float % 60;
        hour_hand.localRotation = Quaternion.Euler(0, 0, -given_minutes_float / 2);
        minute_hand.localRotation = Quaternion.Euler(0, 0, -minuteOnClock * 6);
    }



    // Update is called once per frame
    void Update()
    {
        SetTime(clockTimeController.minutes_float);
    }

}
