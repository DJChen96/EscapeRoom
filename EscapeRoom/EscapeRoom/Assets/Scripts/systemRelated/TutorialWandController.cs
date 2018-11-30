using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class TutorialWandController : MonoBehaviour {

    [SteamVR_DefaultActionSet("default")]
    public SteamVR_ActionSet actionSet;

    [SteamVR_DefaultAction("move", "default")]
    public SteamVR_Action_Vector2 a_move;

    public GameObject pc;

    public float fire_cooldown = 2.0f;
    public bool fire_inCD = false;
    public bool fireMode = true;

    public GameObject firePrefab;
    public bool fire_generated = false;

    public bool cc_generated;
    
    public GameObject cc;
    public ParticleSystem wandEffect;

    public bool[] magic_mode = new bool[1];


    GameObject temp;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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

    void switchMagic()
    {
        if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand) && !cc_generated)
        {
            Quaternion q = new Quaternion(0, transform.parent.rotation.y, 0, transform.parent.rotation.w);
            temp = Instantiate(cc, this.transform.position, q, pc.transform);
            cc_generated = true;
        }
        if (cc_generated)
        {
            Vector2 m = a_move.GetAxis(SteamVR_Input_Sources.RightHand);
            if (m.x > 0 && m.y > 0)
            {
                magic_mode[0] = true;
            }
            else {//Select empty magic prefab and pop up a question mark.

            }
            
        }
        else if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand) && cc_generated)
        {
            cc_generated = false;
            GameObject.Destroy(temp.gameObject);
            temp = null;

            fireMode = magic_mode[0];
        }


    }
}
