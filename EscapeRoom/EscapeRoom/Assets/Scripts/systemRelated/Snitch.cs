using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Snitch : MonoBehaviour {

    public GameObject stone;
	// Use this for initialization
	void Start () {
        //StoneApear();

    }
	
    public void StoneApear()
    {
        stone.SetActive(true);
        this.gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
        if (this.GetComponent<Interactable>().isHovering)
        {
            Debug.Log("LeftController Got");
            if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                if (GameObject.Find("Highlighter"))
                {
                    GameObject highlighter = GameObject.Find("Highlighter");
                    Destroy(highlighter);
                }
                this.GetComponent<Interactable>().highlightOnHover = false;
                Debug.Log("GRAB PRESSED");
                StoneApear();
            }
        }
    }
}
