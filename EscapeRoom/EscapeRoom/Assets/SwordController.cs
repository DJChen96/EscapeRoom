using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SwordController : MonoBehaviour {

    public GameObject swordOnHand;
    public GameObject theElderWand;
    private bool movingSword = false;

    public AudioClip sowrdAudioClip;
    public SoundEffectAudioSource soundEffectAudioSource;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (movingSword)
        {
            this.gameObject.layer = 2;
            this.transform.position = Vector3.Lerp(this.transform.position, swordOnHand.transform.position, Time.deltaTime * 2f);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, swordOnHand.transform.rotation, Time.deltaTime * 1.7f);

            if (Vector3.Distance(this.transform.position, swordOnHand.transform.position) < 0.1f && Quaternion.Angle(this.transform.rotation, swordOnHand.transform.rotation) < 1)
            {
                movingSword = false;
                swordOnHand.SetActive(true);
                theElderWand.SetActive(false);

                Destroy(this.gameObject);
                //this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("LeftController") )
        {
            Debug.Log("LeftController Got");
            if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                Debug.Log("GRAB PRESSED");
                movingSword = true;
                soundEffectAudioSource.Play(sowrdAudioClip);
            }
        }
    }
}
