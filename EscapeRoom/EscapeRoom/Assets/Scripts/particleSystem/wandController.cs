using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class wandController : MonoBehaviour {

    public float fire_cooldown = 2.0f;
    public bool fire_inCD = false;
    public bool fireMode = true;

    public float water_cooldown = 3.0f;
    public bool water_inCD = false;
    public bool waterMode = false;

    public bool timeMode = false;
    public bool time_triggered = false;

    public float growth_cooldown = 4.0f;
    public bool growthMode = false;
    public bool growth_inCD = false;


    public playerController pc;
    public GameObject firePrefab;
    public bool fire_generated = false;

    public GameObject waterPrefab;
    public bool water_generated = false;

    public GameObject timePrefab;
    public bool time_generated = false;

    public GameObject growthPrefab;
    public bool growth_generated = false;

    public float rotationX;
    public float rotationY;
    public float rotationZ;
    public float offsetX;
    public float offsetY;
    public float offsetZ;

    public GameObject cc;
    public ParticleSystem wandEffect;

    public ParticleSystem ember;

    public bool[] magic_mode = new bool[4];

    public bool cc_generated;

    GameObject temp;

    // Use this for initialization
    void Start () {
        pc = FindObjectOfType<playerController>();
        wandEffect = GetComponentInChildren<ParticleSystem>();
        
        // var wand_main = wandEffect.main;
        //wand_main.startColor = new Color(255f, 58f, 0f);
        cc_generated = false;

        for (int i = 0; i < magic_mode.Length; i++) {
            magic_mode[i] = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        CastFireMagic();
        CastWaterMagic();
        CastTimeMagic();
        CastGrowthMagic();
        castingMagic();
        switchMagic();
    }




    void castingMagic() {
        if (fireMode)
            castingFire();
        else if (waterMode)
            castingWater();
        else if (timeMode)
            castingTime();
        else if (growthMode)
            castingGrowth();
    }

    void castingFire() {
        if (fire_inCD && !fire_generated && fireMode)
        {
            if (firePrefab != null)
            {
                Instantiate(firePrefab, transform.position, transform.parent.rotation, this.transform);
                fire_generated = true;
            }
            else
                print("NULL FIRE PREFAB");
        }
        else if (!fire_inCD)
        {
            fire_generated = false;
        }
    }

    void castingWater()
    {
        if (water_inCD && !water_generated && waterMode)
        {
            if (waterPrefab != null)
            {
                print("WATER GENERATED");
                Instantiate(waterPrefab, transform.position + new Vector3(offsetX * 1f, offsetY * 1f, offsetZ * 1f), new Quaternion(0f, 0f, 0f, 0f), this.transform);
                water_generated = true;
            }
            else
                print("NULL WATER PREFAB");
        }
        else if (!water_inCD)
        {
            water_generated = false;
        }
    }

    void castingGrowth()
    {
        if (growth_inCD && !growth_generated && growthMode)
        {
            if (growthPrefab != null)
            {
                print("GROWTH GENERATED");
                Instantiate(growthPrefab, transform.position, new Quaternion(0f, 0f, 0f, 0f), this.transform);
                growth_generated = true;
            }
            else
                print("NULL GROWTH PREFAB");
        }
        else if (!growth_inCD)
        {
            growth_generated = false;
        }
    }

    void castingTime() {
        if (time_triggered && !time_generated && timeMode)
        {
            if (timePrefab != null)
            {
                print("TIME GENERATED");
                Instantiate(timePrefab, transform.position + 5.0f*transform.forward + 5.0f*transform.up, pc.transform.rotation);
                time_generated = true;
            }
            else
                print("NULL TIME PREFAB");
        }
        else if (!time_generated)
        {
            time_generated = false;
        }
    }

    void CastFireMagic()
    {

        //firemode = true;
        if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand) && fireMode)
        {
            fire_inCD = true;
            //righthand.TriggerHapticPulse(1000);send pulse haptics
        }

        if (fire_inCD && fire_cooldown > 0.0f)
            fire_cooldown -= Time.deltaTime;
        if (fire_cooldown <= 0.0f)
        {
            fire_cooldown = 2.0f;
            fire_inCD = false;
        }
    }

    void CastWaterMagic()
    {

        //watermode = true;
        if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand) && waterMode)
        {
            water_inCD = true;
            //righthand.TriggerHapticPulse(1000);send pulse haptics
        }

        if (water_inCD && water_cooldown > 0.0f)
            water_cooldown -= Time.deltaTime;
        if (water_cooldown <= 0.0f)
        {
            water_cooldown = 3.0f;
            water_inCD = false;
        }
    }

    void CastGrowthMagic()
    {
        if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand) && growthMode)
        {
            growth_inCD = true;
            //righthand.TriggerHapticPulse(1000);send pulse haptics
        }

        if (growth_inCD && growth_cooldown > 0.0f)
            growth_cooldown -= Time.deltaTime;
        if (growth_cooldown <= 0.0f)
        {
            growth_cooldown = 3.0f;
            growth_inCD = false;
        }
    }

    void switchMagic()
    {
        if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand)&&!cc_generated)
        {
            Quaternion q = new Quaternion(0, transform.parent.rotation.y,0,transform.parent.rotation.w);
            temp = Instantiate(cc, this.transform.position+-1.0f*transform.right, q, pc.transform);
            
            cc_generated = true;
        }
        else if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand)&& cc_generated) {
            cc_generated = false;
            GameObject.Destroy(temp.gameObject);
            temp = null;
            
            fireMode = magic_mode[0];
            waterMode = magic_mode[1];
            growthMode = magic_mode[2];
            timeMode = magic_mode[3];
            print(fireMode.ToString()+" "+waterMode.ToString()+" "+timeMode.ToString());
        }

        

        //if (cc_generated) {
        //    if () {
        //        firemode = true;
        //        watermode = timemode = false;
        //    }
        //    else if ()
        //    {
        //        watermode = true;
        //        firemode = timemode = false;
        //    }
        //}
    }



    void CastTimeMagic()
    {

        if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand) && !time_triggered && timeMode)
        {
            //var wand_main = wandEffect.main;
            //wand_main.startColor = new Color(0f, 255f, 0f);
            Debug.Log("IN TIME MODE");
            time_triggered = true;
            //fireMode = false;
        }
        else if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand) && time_triggered && timeMode)
        {//on CD
            time_triggered = false;
        }
    }
}
