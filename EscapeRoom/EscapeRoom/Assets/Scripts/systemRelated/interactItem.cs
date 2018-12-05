using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class interactItem : MonoBehaviour {

    //public playerController player;
    // public Transform playerCam;
    public Interactable interactable_object;

    public bool interact_particleSystem;
    public bool interact_sound;
    public bool interact_throwable;

    public ParticleSystem ps;
    public AudioClip audio;

    private bool triggered = false;

    SoundEffectAudioSource soundEffectAudioSource;

    // Use this for initialization
    void Start () {
        //interactable_object = this.gameObject.GetComponent<Interactable>();
        soundEffectAudioSource = FindObjectOfType<SoundEffectAudioSource>();
        interactable_object.highlightOnHover = true;
	}
	
	// Update is called once per frame
	void Update () {
        Interaction_Items();
    }

    void Interaction_Items() {

        if (interact_particleSystem)
        {

            if (ps!=null)
            {

                if (this.gameObject.GetComponent<Interactable>().wasHovering)
                {
                    Debug.Log("particle system is hovering" + SteamVR_Input._default.inActions.GrabGrip.GetStateDown(SteamVR_Input_Sources.LeftHand));
                    if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand) && !triggered)
                    {
                        ps.Play(true);
                        triggered = true;
                    }
                    else if (!ps.IsAlive(true))
                    {
                        triggered = false;
                    }
                }
            }

        }

        if (interact_sound)
        {
            if (audio)
            {
                if (interactable_object.gameObject.GetComponent<AudioClip>())
                {
                    Debug.Log("ERROR: COUND NOT FOUND SOUND ON INTERACTABLE ITEMS");
                    return;
                }

                if (!soundEffectAudioSource)
                {
                    Debug.Log("ERROR: NO SOUND EFFECT AUDIO SOURCE");
                    return;
                }

                if (interactable_object.wasHovering)
                {
                    if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
                    {
                        soundEffectAudioSource.Play(interactable_object.gameObject.GetComponent<AudioClip>());
                    }

                }
            }
        }

        if (interact_throwable)
        {
            if (interactable_object.gameObject.GetComponent<Throwable>())
            {
                Debug.Log("ERROR: COUND NOT FOUND THROWABLE ON INTERACTABLE ITEMS");
                return;
            }

            Throwable th_on_Object = interactable_object.GetComponent<Throwable>();

            th_on_Object.restoreOriginalParent = true;
            th_on_Object.scaleReleaseVelocity = th_on_Object.GetComponent<Rigidbody>().mass;

        }

    }
}
