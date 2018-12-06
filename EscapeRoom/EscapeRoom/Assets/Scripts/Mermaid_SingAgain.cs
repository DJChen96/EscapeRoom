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
        

        if (this.gameObject.GetComponent<Interactable>().wasHovering && mc.mermaidWatered && !mc.speaking)
        {
           
            if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                //MirrorSpeak();
                mermailAudioSource.clip = partOfYourWorld;
                mermailAudioSource.Play();
                mc.speaking = true;
            }
        }
    }

    //private void OnParticleCollision(GameObject other)
    //{
    //    Debug.Log("_PARTICLE:-------------" + other.gameObject.name + "------------");
    //    if (mc.mermaidWatered && !mc.speaking)
    //    {
    //        mc.speaking = true;
    //        if (other.tag.Equals("splitPotion"))
    //        {
    //            Debug.Log("Oh nice. I shall give you this");
    //            mc.MermaidDispearSet[0] = 1;
    //        }
    //        else if (other.tag.Equals("lovePotion"))
    //        {
    //            mc.audioSource.clip = mc.mermailAudios[2];
    //            mc.audioSource.Play();
    //        }
    //        else if (other.tag.Equals("truthSerum"))
    //        {
    //            mc.audioSource.clip = mc.mermailAudios[1];
    //            mc.audioSource.Play();
    //        }
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("------------" + mc.mermaidWatered  +" " + mc.speaking);
        if (mc.mermaidWatered && !mc.speaking)
        {
            Debug.Log("COLLISION_BIG_MERMAID:-------------" + other.gameObject.tag + "------------");
            Debug.Log("lovePotion :" + other.gameObject.tag.Equals("lovePotion"));
            
            if (other.gameObject.tag.Equals("splitPotion"))
            {
                Debug.Log("SPLITPOTION----ABSORB");
                mc.MermaidDispearSet[0] = 1;
                mc.speaking = true;
            }
            else if (other.gameObject.tag.Equals("lovePotion"))
            {
                Debug.Log("LOVEPOTION----ABSORB");
                mc.audioSource.clip = mc.mermailAudios[2];
                mc.audioSource.Play();
                mc.speaking = true;
            }
            else if (other.gameObject.tag.Equals("truthSerum"))
            {
                Debug.Log("TRUTHPOTION----ABSORB");
                mc.audioSource.clip = mc.mermailAudios[1];
                mc.audioSource.Play();
                mc.speaking = true;

            }
        }
    }
}
