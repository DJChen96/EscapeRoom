﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SwordController : MonoBehaviour {

    public GameObject swordOnHand;
    public GameObject theElderWand;
    private bool movingSword = false;

    public GameObject swordAura;

    public AudioClip sowrdAudioClip;
    public SoundEffectAudioSource soundEffectAudioSource;

    private Book book;
    private MirrorController mirrorController;
    // Use this for initialization
    void Start () {
        book = FindObjectOfType<Book>();
        mirrorController = FindObjectOfType<MirrorController>();
        swordAura.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {

        if (this.GetComponent<Interactable>().wasHovering)
        {
            Debug.Log("LeftController Got");
            if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                Debug.Log("GRAB PRESSED");
                swordAura.SetActive(false);
                movingSword = true;
                soundEffectAudioSource.Play(sowrdAudioClip);
            }
        }

        if (movingSword)
        {

            if (GameObject.Find("Highlighter"))
            {
                GameObject highlighter = GameObject.Find("Highlighter");
                Destroy(highlighter);
            }
            this.GetComponent<Interactable>().highlightOnHover = false;
            this.gameObject.layer = 2;
            this.transform.position = Vector3.Lerp(this.transform.position, swordOnHand.transform.position, Time.deltaTime * 10f);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, swordOnHand.transform.rotation, Time.deltaTime * 10f);

            if (Vector3.Distance(this.transform.position, swordOnHand.transform.position) < 0.1f && Quaternion.Angle(this.transform.rotation, swordOnHand.transform.rotation) < 1)
            {
                movingSword = false;
                swordOnHand.SetActive(true);
                theElderWand.SetActive(false);

                book.SetStage(5);
                mirrorController.SetStage(5);

                Destroy(this.gameObject);
                //this.gameObject.SetActive(false);
            }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag.Equals("LeftController") )
    //    {
            
    //    }
    //}
}
