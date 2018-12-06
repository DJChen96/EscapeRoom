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

    private bool previous_attached;

    public bool resetTransformAfterInteraction;

    public ParticleSystem ps;
    public AudioClip audio;

    private Vector3 originalPos;
    private Quaternion originalRot;
    private Vector3 originalScale;

    private bool triggered = false;

    SoundEffectAudioSource soundEffectAudioSource;

    // Use this for initialization
    void Start () {

        previous_attached = false;

        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        originalRot = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
        originalScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

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
            
                if (audio == null)
                {
                    Debug.Log("ERROR: COUND NOT FOUND SOUND ON INTERACTABLE ITEMS");
                    return;
                }

                if (soundEffectAudioSource == null)
                {
                    Debug.Log("ERROR: NO SOUND EFFECT AUDIO SOURCE");
                    return;
                }

                if (interactable_object.wasHovering)
                {
                    if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
                    {
                             soundEffectAudioSource.Play(audio);
                    //soundEffectAudioSource.Play(interactable_object.gameObject.GetComponent<AudioClip>());
                    }

                }
            
        }

       

        if (resetTransformAfterInteraction) {

            bool Attach = interactable_object.attachedToHand != null;
            if (!Attach && previous_attached)
            {
                Debug.Log("----interactable_object.attachedToHand == null----");
                if (GameObject.Find("Highlighter"))
                {
                    GameObject highlighter = GameObject.Find("Highlighter");
                    Destroy(highlighter);
                }
                //interactable_object.highlightOnHover = false;

                this.transform.position = originalPos;
                this.transform.rotation = originalRot;
                this.transform.localScale = originalScale;

                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
            }

                //Debug.Log("----interactable_object.attachedToHand is not null----");
                //if (!interactable_object.highlightOnHover)
                //    interactable_object.highlightOnHover = true;


                previous_attached = Attach;

        }
        

    }
}
