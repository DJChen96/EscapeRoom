using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCrystal : MonoBehaviour {

    //[Tooltip("The index of the magic in the magic array")]
    public int index;

    private Book book;
    private MirrorController mirrorController;

    public bool absorbed = false;
    public ParticleSystem deadEffect;
    private int shaderProperty;
    public Material dissolve;

    wandController wc;

	// Use this for initialization
	void Start () {
        shaderProperty = Shader.PropertyToID("_cutoff");
        wc = FindObjectOfType<wandController>();
        book = FindObjectOfType<Book>();
        mirrorController = FindObjectOfType<MirrorController>();


    }

    private void OnDestroy()
    {
        book.SetStage(index + 2);
        mirrorController.SetStage(index + 2);
    }
    // Update is called once per frame
    void Update () {
        
	}

    public void AbsorbMagic(float waitTime)
    {
        //Animation will invoke this method so that it will start coroutine to destroy crystal.
        StartCoroutine(CrystalDissolve(waitTime));
    }

    IEnumerator CrystalDissolve(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //absorbed = true;
        if(index == 0)
            wc.waterEnabled = true;

        else if (index == 1)
            wc.growthEnabled = true;

        else if (index == 2)
            wc.timeEnabled = true;

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
