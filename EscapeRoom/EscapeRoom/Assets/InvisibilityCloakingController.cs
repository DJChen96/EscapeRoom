﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityCloakingController : MonoBehaviour {
    public Material dissolveMaterial;
    public GameObject[] seed_box;

    private int shaderProperty;
    // Use this for initialization
    void Start () {
        shaderProperty = Shader.PropertyToID("_cutoff");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Visible_and_disappear()
    {
        this.gameObject.GetComponent<Renderer>().material = dissolveMaterial;
        for (int i = 0; i < seed_box.Length; i ++) {
            seed_box[i].SetActive(true);
        }
        StartCoroutine(CloakDissolve());
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag.Equals("FireMagic"))
        {
            Visible_and_disappear();
        }
    }

    IEnumerator CloakDissolve()
    {
        float cutoff = 0;
        yield return new WaitForSeconds(1f);
        while (cutoff < 1)
        {
            cutoff += Time.deltaTime * 0.5f;
            this.gameObject.GetComponent<Renderer>().material.SetFloat(shaderProperty, cutoff);
            yield return null;
        }
        Destroy(this.gameObject);
    }

}
