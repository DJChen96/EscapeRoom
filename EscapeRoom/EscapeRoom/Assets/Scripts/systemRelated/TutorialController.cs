using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {

    public GameObject player;
    public AudioClip[] tutorialAudioArray;
    public AudioSource audioSource;

    public bool audioPlayed = true;
    public bool audioPlaying = false;
    public int state =-1;
    private bool state_change = true;

    public FadeCamera fadeCamera;
    public GameObject TutorialStage; 
    public GameObject[] arrowList;
    public GameObject[] controllerList;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!audioPlayed && state >= 0)
        {
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
                }
                break;

            case 2:
                // Pick up the item in front of you with your left hand.
                audioPlayed = state_change ? false : audioPlayed;
                audioPlaying = state_change ? true : audioPlaying;
                state_change = state_change ? false : state_change;

                arrowList[0].SetActive(true);

                if (!audioPlaying)
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
                state_change = state_change ? false : state_change;

                arrowList[1].SetActive(true);

                if (!audioPlaying)
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
                if (!audioPlaying)
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
                if (!audioPlaying)
                {
                    arrowList[2].SetActive(false);
                    state_change = true;
                    state = 6;
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











        // Debug
        if (gameController.debugMode == false)
            return;
        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            state = 0;
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            state = 1;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            state = 2;
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            state = 3;
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            state = 4;
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            state = 5;
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            state = 6;
        }
    }
}
