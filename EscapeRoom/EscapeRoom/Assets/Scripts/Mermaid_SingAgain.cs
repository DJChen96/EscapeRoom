using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Mermaid_SingAgain : MonoBehaviour {

    public AudioClip partOfYourWorld;
    private MermaidController mc;

    public AudioSource mermailAudioSource;
    // Use this for initialization
    void Start () {
        mc = FindObjectOfType<MermaidController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<Interactable>().isHovering && mc.mermaidWatered && !mc.speaking)
        {
            //Debug.Log("____________mirror" + "_________________");
            if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                //MirrorSpeak();
                mermailAudioSource.clip = partOfYourWorld;
                mermailAudioSource.Play();
                mc.speaking = true;
            }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag.Equals("LeftController"))
    //    {
    //        //Debug.Log("____________mirror" + "_________________");
    //        if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
    //        {
    //            //MirrorSpeak();
    //            soundEffectAudioSource.Play(partOfYourWorld);
    //        }
    //    }
    //}
}
