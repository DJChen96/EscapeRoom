using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class potion : MonoBehaviour {

    ParticleSystem ps;

    // Use this for initialization
    void Start () {
        ps = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        

        if (Vector3.Angle(this.transform.up,new Vector3(0,1,0))>90.0f) {
            ps.Play();
        }
        else{
            ps.Stop();
        }
    }
}
