using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candle : MonoBehaviour {

    public ParticleSystem flame;
    bool lit;
    public Light light_template;
    public gameController gc;

	// Use this for initialization
	void Start () {
        flame = GetComponentInChildren<ParticleSystem>();
        lit = false;
        gc = FindObjectOfType<gameController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
   
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag.Equals("FireMagic")&&!lit ) {
            lit = true;
            gc.lit_room = true;

            flame.Play();

            var lights = flame.lights;
            lights.ratio = 0.3f;
            lights.light = light_template;
            lights.useParticleColor = true;
            lights.useRandomDistribution = true;
            lights.sizeAffectsRange = true;
            lights.alphaAffectsIntensity = true;
            lights.intensityMultiplier = 5.0f;
            lights.maxLights = 10;
            lights.rangeMultiplier = 2.0f;
            lights.enabled = true;


        }
    }
}
