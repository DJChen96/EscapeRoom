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
    public bool fire_inCD = false;
    public bool fireMode = true;

    public float water_cooldown = 2.0f;
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

    public GameObject cc;
    public ParticleSystem wandEffect;

    //public ParticleSystem ember;

    public bool[] magic_mode = new bool[4];

    public bool cc_generated;

    GameObject temp;

    // Use this for initialization
    void Start () {

        defaultAction.ActivatePrimary();
        platformAction.ActivateSecondary();

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
                //Instantiate(waterPrefab, transform.position + new Vector3(offsetX * 1f, offsetY * 1f, offsetZ * 1f), new Quaternion(0f, 0f, 0f, 0f), this.transform);
                waterPrefab.Play();
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
                //Instantiate(timePrefab, transform.position + 5.0f*transform.forward + 5.0f*transform.up, pc.transform.rotation);
                timePrefab.SetActive(true);
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
            waterPrefab.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            water_cooldown = 2.0f;
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
            //temp = Instantiate(cc, this.transform.position, q, pc.transform);
            cc_generated = true;
            if (activateActionSetOnAttach != null)
                activateActionSetOnAttach.ActivatePrimary();
            Debug.Log(activateActionSetOnAttach.IsActive());
        }
        //else if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand))
        else if (ccSet.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            cc_generated = false;
            //GameObject.Destroy(temp.gameObject);
            //temp = null;

            Debug.Log("EXIT CHOICE MODE");
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
            
            
            Debug.Log(activateActionSetOnAttach.IsActive());
            //}

        }


        if (cc_generated) {
            platformAction.Deactivate();
            Vector2 m = a_move.GetAxis(SteamVR_Input_Sources.RightHand);
            float result = m.y / m.x;
            //Debug.Log(m.x+" "+m.y+" "+result);
            if ((-1.0f < result && result < 1.0f) && m.x < 0)
            {
                magic_mode[0] = false;
                magic_mode[1] = false;
                magic_mode[2] = true;
                magic_mode[3] = false;
            }
            else if ((-1.0f > result || result > 1.0f) && m.y < 0)
            {
                magic_mode[0] = false;
                magic_mode[1] = true;
                magic_mode[2] = false;
                magic_mode[3] = false;
            }
            else if ((-1.0f > result || result > 1.0f) && m.y > 0)
            {
                magic_mode[0] = false;
                magic_mode[1] = false;
                magic_mode[2] = false;
                magic_mode[3] = true;
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
            print(magic_mode[0].ToString() + " " + magic_mode[1].ToString() + " " + magic_mode[2].ToString() + " " + magic_mode[3].ToString());
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
            //fireMode = false;
        }
        else if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand) && time_triggered && timeMode)
        {//on CD
            time_triggered = false;
            var array = timePrefab.GetComponentsInChildren<ParticleSystem>();
            foreach ( ParticleSystem p in array) {
                p.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
            timePrefab.SetActive(false);
        }
    }

    private void ChangeActionSet(Hand hand)
    {
       

        //if (onAttachedToHand != null)
        //{
        //    onAttachedToHand.Invoke(hand);
        //}

        //attachedToHand = hand;
    }

    private void ResetActionSet(Hand hand)
    {
        if (activateActionSetOnAttach != null)
        {
            
        }

        //if (onDetachedFromHand != null)
        //{
        //    onDetachedFromHand.Invoke(hand);
        //}

        //attachedToHand = null;
    }
}
