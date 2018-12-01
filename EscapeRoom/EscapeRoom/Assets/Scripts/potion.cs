using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class potion : MonoBehaviour {

    ParticleSystem ps;

    // @Author Xiaotog Bao
    public GameObject cap;
    public AudioSource potionSpeaker;
    private float MAX_flowingTime = 4;
    private float flowingTime = 0;

    // Use this for initialization
    void Start () {
        ps = GetComponentInChildren<ParticleSystem>();
	}


    // Update is called once per frame
    void Update () {
        
        
        if (Vector3.Angle(this.transform.up,new Vector3(0,1,0))>90.0f && flowingTime < MAX_flowingTime) {
            
            ps.Play();


            // @Author Xiaotog Bao
            potionSpeaker.Play();
            cap.SetActive(false);
            flowingTime = flowingTime + Time.deltaTime;
        }
        else{
            
            ps.Stop();

            // @Author Xiaotog Bao
            potionSpeaker.Stop();
            cap.SetActive(true);
            flowingTime = 0;
}
    }
}
