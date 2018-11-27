using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class input_test : MonoBehaviour {

	// Use this for initialization
	void Start () {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand)) {
            Debug.Log("123321");
        }
    }

  


}
