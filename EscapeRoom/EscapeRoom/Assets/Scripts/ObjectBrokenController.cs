using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ObjectBrokenController : MonoBehaviour {

    public AudioClip breakAudioClip;
    public SoundEffectAudioSource soundEffectAudioSource;
    public GameObject completeObj;
    public GameObject brokenObj;
    private float waitingTime = 3f;
    public bool debug_triger = false;

    private Interactable interactable_broken;

    public GameObject objectAppearBeforeBroken;

    private bool breaked =false;
	// Use this for initialization
	void Start () {
        interactable_broken = this.gameObject.GetComponent<Interactable>();
    }

    public void Break()
    {
        if (breaked) return;
        breaked = true;
        brokenObj.SetActive(true);
        soundEffectAudioSource.Play(breakAudioClip);
        StartCoroutine(Broken_box_disappear());
        this.gameObject.GetComponent<Collider>().enabled = false;

        if (objectAppearBeforeBroken) {
            objectAppearBeforeBroken.SetActive(true);
        }

        Destroy(completeObj.gameObject);

    }


    // Update is called once per frame
    void Update () {
        if (interactable_broken != null)
        {
            if (interactable_broken.wasHovering)
            {
                if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
                {
                    Break();
                }
            }
        }
        if(debug_triger == true && gameController.debugMode == true)
        {
            Break();
        }
	}
    IEnumerator Broken_box_disappear()
    {
        if (GameObject.Find("Highlighter"))
        {
            GameObject highlighter = GameObject.Find("Highlighter");
            Destroy(highlighter);
        }
        this.GetComponent<Interactable>().highlightOnHover = false;

        if (brokenObj.gameObject.GetComponent<Interactable>() != null)
        {
            brokenObj.gameObject.GetComponent<Interactable>().highlightOnHover = false;

        }

        yield return new WaitForSeconds(waitingTime);
        Destroy(brokenObj.gameObject);
        Destroy(this.gameObject);
    }

    //private void OnParticleCollision(GameObject other)
    //{
    //    if (other.tag.Equals("FireMagic")) {
    //        Break();

    //    }
    //}
}
