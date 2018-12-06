using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class InvisibilityCloakingController : MonoBehaviour {
    public Material dissolveMaterial;
    public GameObject[] seed_box;
    public GameObject Cloak;

    private int shaderProperty;
    // Use this for initialization
    void Start () {
        shaderProperty = Shader.PropertyToID("_cutoff");

    }
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.GetComponent<Interactable>())
        {
            //Debug.Log("FOUND INTERACTABLE COMPONENT");
            if (this.gameObject.GetComponent<Interactable>().wasHovering)
            { 
                if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
                {
                    Visible_and_disappear();
                }
            }
        }
    }

    private void Visible_and_disappear()
    {
        Cloak.GetComponent<Renderer>().material = dissolveMaterial;
        for (int i = 0; i < seed_box.Length; i ++) {
            seed_box[i].SetActive(true);
        }
        StartCoroutine(CloakDissolve());
    }

    //private void OnParticleCollision(GameObject other)
    //{
    //    if (other.tag.Equals("FireMagic"))
    //    {
    //        Visible_and_disappear();
    //    }
    //}

    IEnumerator CloakDissolve()
    {
        float cutoff = 0;
        yield return new WaitForSeconds(1f);
        while (cutoff < 1)
        {
            cutoff += Time.deltaTime * 0.5f;
            Cloak.GetComponent<Renderer>().material.SetFloat(shaderProperty, cutoff);
            yield return null;
        }
        Destroy(this.gameObject);
    }

}
