using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class wandController : MonoBehaviour {

    [Tooltip("Activates an action set when switching magic")]
    public SteamVR_ActionSet activateActionSetOnAttach;

    [Tooltip("Activates an action default")]
    public SteamVR_ActionSet defaultAction;

    [Tooltip("Activates an action default")]
    public SteamVR_ActionSet platformAction;

    public float fire_cooldown = 2.0f;
   // public bool fire_inCD = false;
    public bool fireMode = false;

    public float water_cooldown = 2.0f;
    //public bool water_inCD = false;
    public bool waterMode = false;
    
    public bool timeMode = false;
    public bool time_triggered = false;

    public float growth_cooldown = 4.0f;
    public bool growthMode = false;
    //public bool growth_inCD = false;

    
    public bool waterEnabled = false;
    public bool growthEnabled = false;
    public bool timeEnabled = false;


    public playerController pc;
    public GameObject firePrefab;
    public bool fire_generated = false;

    public ParticleSystem waterPrefab;
    public bool water_generated = false;

    public GameObject timePrefab;
    public bool time_generated = false;

    public GameObject growthPrefab;
    public bool growth_generated = false;

    [SteamVR_DefaultActionSet("default")]
    public SteamVR_ActionSet actionSet;

    [SteamVR_DefaultAction("steering", "position")]
    public SteamVR_Action_Vector2 a_move;

    [SteamVR_DefaultAction("brake", "position")]
    public SteamVR_Action_Boolean ccSet;

    int index;

    //public GameObject tcc;
    public GameObject cc;//Choice controller Prefab
    public bool cc_generated;

    public ParticleSystem wandEffect;

    //public ParticleSystem ember;

    public bool[] magic_mode = new bool[4];

    GameObject temp;

    // @Author Xiaotong Bao
    public AudioClip[] MagicClips;
    public SoundEffectAudioSource MagicAudioSource;



    // Use this for initialization
    void Start () {

        defaultAction.ActivatePrimary();
        platformAction.ActivateSecondary();

        pc = FindObjectOfType<playerController>();
        wandEffect = GetComponentInChildren<ParticleSystem>();
        
        cc_generated = false;

        for (int i = 0; i < magic_mode.Length; i++) {
            magic_mode[i] = false;
        }

        waterEnabled = growthEnabled = true;
        //timeEnabled = true;
        growthMode = true;
    }
	
	// Update is called once per frame
	void Update () {
        CastFireMagic();
        CastWaterMagic();
        CastTimeMagic();
        CastGrowthMagic();
        
        //castingMagic();
        switchMagic();
    }

   /* void castingMagic() {
        if (fireMode) {
        }
        //castingFire();
        else if (waterMode)
            castingWater();
        else if (timeMode)
            castingTime();
        else if (growthMode)
            castingGrowth();
    }

    void castingFire() {
        if (fire_inCD )
        {
            if (firePrefab != null)
            {
                
                fire_generated = true;
                
            }
            else
                print("NULL FIRE PREFAB");
        }
        else if (!fire_inCD)
        {
            
        }
    }

    void castingWater()
    {
        if (waterEnabled)
        {
            if (water_inCD && !water_generated && waterMode)
            {
                if (waterPrefab != null)
                {
                    print("WATER GENERATED");
                    //Instantiate(waterPrefab, transform.position + new Vector3(offsetX * 1f, offsetY * 1f, offsetZ * 1f), new Quaternion(0f, 0f, 0f, 0f), this.transform);
                   
                }
                else
                    print("NULL WATER PREFAB");
            }
            else if (!water_inCD)
            {
                water_generated = false;
            }
        }
    }

    void castingGrowth()
    {
        if (growth_inCD && !growth_generated && growthMode)
        {
            if (growthPrefab != null)
            {
                print("GROWTH GENERATED");
                
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
                //Instantiate(timePrefab, transform.position + 5.0f*transform.forward + 5.0f*transform.up, pc.transform.rotation);
                
            }
            else
                print("NULL TIME PREFAB");
        }
        else if (!time_generated)
        {
            time_generated = false;
        }
    }*/

    void CastFireMagic()
    {
        
        //firemode = true;
        if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand) && fireMode && !fire_generated)
        {
            //fire_inCD = true;
            Instantiate(firePrefab, transform.position, transform.parent.rotation, this.transform);
            // @Author Xiaotong Bao
            MagicAudioSource.Play(MagicClips[0]);
            //righthand.TriggerHapticPulse(1000);send pulse haptics
            fire_generated = true;
        }
        if (fire_generated && fire_cooldown > 0.0f)
            fire_cooldown -= Time.deltaTime;
        if (fire_cooldown <= 0.0f)
        {
            fire_cooldown = 2.0f;
            //fire_inCD = false;
            fire_generated = false;
        }
    }

    void CastWaterMagic()
    {

        //watermode = true;
        if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand) && waterMode && !water_generated)
        {
           //water_inCD = true;
            //righthand.TriggerHapticPulse(1000);send pulse haptics
            waterPrefab.Play();
            water_generated = true;
            // @Author Xiaotong Bao
            MagicAudioSource.Play(MagicClips[1]);
        }

        if (water_generated && water_cooldown > 0.0f)
            water_cooldown -= Time.deltaTime;
        if (water_cooldown <= 0.0f)
        {
            waterPrefab.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            water_cooldown = 2.0f;
            //water_inCD = false;
            water_generated = false;
        }
    }

    void CastGrowthMagic()
    {
        if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand) && growthMode && !growth_generated)
        {
            //growth_inCD = true;
            //righthand.TriggerHapticPulse(1000);send pulse haptics
            Instantiate(growthPrefab, transform.position, new Quaternion(0f, 0f, 0f, 0f), this.transform);
            growth_generated = true;
            // @Author Xiaotong Bao
            MagicAudioSource.Play(MagicClips[2]);
        }

        if (growth_generated && growth_cooldown > 0.0f)
            growth_cooldown -= Time.deltaTime;
        if (growth_cooldown <= 0.0f)
        {
            growth_cooldown = 4.0f;
            //growth_inCD = false;
            growth_generated = false;
        }
    }

    void switchMagic()
    {

        if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand)&&!cc_generated)
        {
           // if (tutorial)
            //{
                //waterEnabled = growthEnabled = timeEnabled = false;
            //}
                Quaternion q = new Quaternion(0, transform.parent.rotation.y,0,transform.parent.rotation.w);
                temp = Instantiate(cc, this.transform.position, q, pc.transform);
            
            cc_generated = true;
            if (activateActionSetOnAttach != null)
                activateActionSetOnAttach.ActivatePrimary();         
        }
        //else if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand))
        else if (ccSet.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            cc_generated = false;
            GameObject.Destroy(temp.gameObject);

            fireMode = magic_mode[0];
            waterMode = magic_mode[1];
            growthMode = magic_mode[2];
            timeMode = magic_mode[3];

            //if (hand.otherHand.currentAttachedObjectInfo.HasValue == false || (hand.otherHand.currentAttachedObjectInfo.Value.interactable != null &&
            //    hand.otherHand.currentAttachedObjectInfo.Value.interactable.activateActionSetOnAttach != this.activateActionSetOnAttach))
            //{
            defaultAction.ActivatePrimary();
            platformAction.ActivateSecondary();
            activateActionSetOnAttach.Deactivate();   
        }


        if (cc_generated) {
            platformAction.Deactivate();
            Vector2 m = a_move.GetAxis(SteamVR_Input_Sources.RightHand);
            float result = m.y / m.x;
            
            if ((-1.0f < result && result < 1.0f) && m.x < 0)
            {
                magic_mode[0] = false;
                magic_mode[1] = false;
                magic_mode[2] = true && growthEnabled;
                magic_mode[3] = false;
            }
            else if ((-1.0f > result || result > 1.0f) && m.y < 0)
            {
                magic_mode[0] = false;
                magic_mode[1] = true && waterEnabled;
                magic_mode[2] = false;
                magic_mode[3] = false;
            }
            else if ((-1.0f > result || result > 1.0f) && m.y > 0)
            {
                magic_mode[0] = false;
                magic_mode[1] = false;
                magic_mode[2] = false;
                magic_mode[3] = true && timeEnabled;
            }
            else if ((-1.0f < result && result < 1.0f) && m.x > 0)
            {
                magic_mode[0] = true;
                magic_mode[1] = false;
                magic_mode[2] = false;
                magic_mode[3] = false;
            }
            else {


            }
            //print(magic_mode[0].ToString() + " " + magic_mode[1].ToString() + " " + magic_mode[2].ToString() + " " + magic_mode[3].ToString());
        }
        

        
    }

    void CastTimeMagic()
    {

        if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand) && !time_triggered && timeMode)
        {
            //var wand_main = wandEffect.main;
            //wand_main.startColor = new Color(0f, 255f, 0f);
            Debug.Log("IN TIME MODE");
            time_triggered = true;

            timePrefab.SetActive(true);
            time_generated = true;
            // @Author Xiaotong Bao
            MagicAudioSource.Play(MagicClips[3]);
            //fireMode = false;
        }
        else if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand) && time_triggered && timeMode)
        {//on CD
            time_triggered = false;
            
            var array = timePrefab.GetComponentsInChildren<ParticleSystem>();
            foreach ( ParticleSystem p in array) {
                p.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
            timePrefab.GetComponent<TimeMagic>().Uncontrolled();
            timePrefab.SetActive(false);
        }
    }

}
