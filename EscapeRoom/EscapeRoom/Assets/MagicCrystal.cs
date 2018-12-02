using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCrystal : MonoBehaviour {

    [Tooltip("The index of the magic in the magic array")]
    public int index;

    public bool absorbed = false;
    public ParticleSystem deadEffect;
    private int shaderProperty;
    public Material dissolve;

    wandController wc;

	// Use this for initialization
	void Start () {
        shaderProperty = Shader.PropertyToID("_cutoff");
        wc = FindObjectOfType<wandController>();
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void AbsorbMagic()
    {
        //Animation will invoke this method so that it will start coroutine to destroy crystal.

        StartCoroutine(CrystalDissolve());
    }

    IEnumerator CrystalDissolve()
    {

        absorbed = true;
        deadEffect.Play();

        this.GetComponent<Renderer>().material = dissolve;

        float cutoff = 0;
        while (cutoff < 1)
        {
            cutoff += Time.deltaTime * 0.25f;
            this.gameObject.GetComponent<Renderer>().material.SetFloat(shaderProperty, cutoff);
            yield return null;
        }

        deadEffect.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        while(deadEffect.IsAlive(true)){
            yield return null;
        }

        Destroy(this.gameObject);

    }
}
