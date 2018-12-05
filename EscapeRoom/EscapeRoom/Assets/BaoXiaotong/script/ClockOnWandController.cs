using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockOnWandController : MonoBehaviour {

    public ClockTimeController clockTimeController;

    public Transform hour_hand;
    public Transform minute_hand;

    public float minutes_float = 690;
    public GameObject sphere;

    public GameObject timeMagic;
    private float pre_minutes_float =  -1;
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
    float timePass = 0;
    void Update()
    {
        timePass = timePass + Time.deltaTime;
        SetTime(clockTimeController.minutes_float);
        if (pre_minutes_float != -1)
        {
            float minutes_pass = clockTimeController.minutes_float - pre_minutes_float;
            sphere.GetComponent<Renderer>().material.
                SetTextureOffset("_MainTex", new Vector2(minutes_pass * -0.005f, timePass * 0.3f));


            var array = timeMagic.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem p in array)
            {
                if (p.velocityOverLifetime.enabled)
                {
                    var velocityOverLifetime = p.velocityOverLifetime;
                    velocityOverLifetime.orbitalY = minutes_pass * -0.0005f;
                }
            }

        }
        pre_minutes_float = minutes_float;
    }

}
