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

	// Use this for initialization
	void Start () {
        shaderProperty = Shader.PropertyToID("_cutoff");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AbsorbMagic()
    {
        deadEffect.Play();
        StartCoroutine(CrystalDissolve());
    }

    IEnumerator CrystalDissolve()
    {
        float cutoff = 0;
        while (cutoff < 1)
        {
            cutoff += Time.deltaTime * 0.5f;
            this.gameObject.GetComponent<Renderer>().material.SetFloat(shaderProperty, cutoff);
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
