﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TutorialController : MonoBehaviour {

    public GameObject teleport_t;

    public GameObject player;
    public AudioClip[] tutorialAudioArray;
    public AudioSource audioSource;

    public Vector3 playerOrigin;

    public bool audioPlayed = true;
    public bool audioPlaying = false;
    public int state =-1;
    private bool state_change = true;

    public wandController wc;

    public FadeCamera fadeCamera;
    public GameObject TutorialStage; 
    public GameObject[] arrowList;
    public GameObject[] controllerList;

    public Interactable apple;
   
    public Candle candle;
   
    public int[] status;

    bool s1passed = false;
    // Use this for initialization
    void Start () {
        if (wc == null) {
            wc = FindObjectOfType<wandController>();
        }
       
	}
	
	// Update is called once per frame
	void Update () {
        if (!audioPlayed && state >= 0)
        {
            print("tutorialAudioArray_state = " + state);

            audioSource.clip = tutorialAudioArray[state];
            audioSource.Play();
            audioPlayed = true;
            audioPlaying = true;
        }


        if (audioPlaying && !audioSource.isPlaying)
        {
            audioPlaying = false;
        }

        switch (state)
        {
            case 0:
                // Hey there, welcome to the magic escape room, we are not responsible for severed, 
                // exploded or lost body parts. 
                audioPlayed = state_change ?  false : audioPlayed;
                audioPlaying = state_change ? true : audioPlaying;
                state_change = state_change ? false : state_change;
                if (!audioPlaying )
                {
                    state_change = true;
                    state = 1;
                }
                break;

            case 1:
                //  Let me first to tell you some basic knowledge, before you can enjoy yourself.
                audioPlayed = state_change ? false : audioPlayed;
                audioPlaying = state_change ? true : audioPlaying;
                state_change = state_change ? false : state_change;

                controllerList[0].SetActive(true);
                controllerList[1].SetActive(true);

                if (!audioPlaying)
                {
                    state_change = true;
                    state = 2;
                    print("state = " + state);
                }
                break;

            case 2:
                // Pick up the item in front of you with your left hand.
                audioPlayed = state_change ? false : audioPlayed;
                audioPlaying = state_change ? true : audioPlaying;
                state_change = state_change ? false : state_change;

                arrowList[0].SetActive(true);
                if (apple.attachedToHand != null) {
                    s1passed = (apple.attachedToHand.handType == Valve.VR.SteamVR_Input_Sources.LeftHand)? true : false;
                }
                if (!audioPlaying && s1passed)
                {
                    arrowList[0].SetActive(false);
                    state_change = true;
                    state = 3;
                }
                break;

            case 3:
                // Use your wand to move around. 
                audioPlayed = state_change ? false : audioPlayed;
                audioPlaying = state_change ? true : audioPlaying;
                playerOrigin = state_change ? player.transform.position : playerOrigin;//Record the position at the first frame
                state_change = state_change ? false : state_change;

                arrowList[1].SetActive(true);

                if (!audioPlaying && playerOrigin  != null && Vector3.Distance(player.transform.position,playerOrigin)>0.1f)
                {
                    arrowList[1].SetActive(false);
                    state_change = true;
                    state = 4;
                }
                break;

            case 4:
                // you need to use the Grip to switch to the fire magic mode.
                audioPlayed = state_change ? false : audioPlayed;
                audioPlaying = state_change ? true : audioPlaying;
                state_change = state_change ? false : state_change;

                arrowList[3].SetActive(true);
                arrowList[4].SetActive(true);

                if (!audioPlaying && wc.fireMode)
                {
                    arrowList[3].SetActive(false);
                    arrowList[4].SetActive(false);
                    state_change = true;
                    state = 5;
                }
                break;

            case 5:
                // Now, lit the candle, using what you’ve just learned.
                audioPlayed = state_change ? false : audioPlayed;
                audioPlaying = state_change ? true : audioPlaying;
                state_change = state_change ? false : state_change;

                arrowList[2].SetActive(true);

                if (!audioPlaying && candle.lit)
                {
                    arrowList[2].SetActive(false);
                    state_change = true;
                    state = 6;

                    teleport_t.SetActive(false);
                }

                
                break;
            case 6:
                // Great! Let the game begin!
                audioPlayed = state_change ? false : audioPlayed;
                audioPlaying = state_change ? true : audioPlaying;
                state_change = state_change ? false : state_change;
                if (!audioPlaying)
                {
                    state_change = true;
                    state = 7;
                }
                break;
            case 7:
               
                fadeCamera.RedoFade();
                player.transform.position = new Vector3(3.932f, 0.752f, -6.82f);
                Destroy(TutorialStage);
                break;               
        }

        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            state = 0;
        }

        // Debug
        if (gameController.debugMode == false)
            return;

        
    }
}
