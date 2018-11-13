using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class potion : MonoBehaviour {

    private const float
       secondsToDegrees = 360f / 60f;

    ParticleSystem ps;

    // Use this for initialization
    void Start () {
        ps = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        TimeSpan timespan = DateTime.Now.TimeOfDay;
        this.transform.localRotation =
               Quaternion.Euler(0f, 0f, (float)timespan.TotalSeconds * -secondsToDegrees);

        if (Vector3.Angle(this.transform.up,new Vector3(0,1,0))>90.0f) {
            ps.Play();
        }
        else{
            ps.Stop();
        }
    }
}
