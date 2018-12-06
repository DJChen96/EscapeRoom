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

    private bool triggered_Dissolve;

    private int shaderProperty;
    // Use this for initialization
    void Start () {
        triggered_Dissolve = false;
        shaderProperty = Shader.PropertyToID("_cutoff");

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void Visible_and_disappear()
    {
        Cloak.GetComponent<Renderer>().material = dissolveMaterial;
        for (int i = 0; i < seed_box.Length; i ++) {
            seed_box[i].SetActive(true);
        }
        StartCoroutine(CloakDissolve());
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag.Equals("GrowthMagic") && !triggered_Dissolve)
        {
            Visible_and_disappear();
            triggered_Dissolve = true;
        }
    }

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
