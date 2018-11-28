using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candle : MonoBehaviour {

    public ParticleSystem flame;
    public bool lit;
    
    public gameController gc;
    //public Light flame_light;

	// Use this for initialization
	void Start () {
        flame = GetComponentInChildren<ParticleSystem>();
        lit = false;
        gc = FindObjectOfType<gameController>();
        //flame_light.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        
	}
   
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag.Equals("FireMagic")&&!lit ) {
            lit = true;

           
            //var lights = flame.lights;
            //lights.ratio = 0.3f;
            //lights.light = light_template;
            //lights.useParticleColor = true;
            //lights.useRandomDistribution = true;
            //lights.sizeAffectsRange = true;
            //lights.alphaAffectsIntensity = true;
            //lights.intensityMultiplier = 5.0f;
            //lights.maxLights = 10;
            //lights.rangeMultiplier = 2.0f;
            //lights.enabled = true;


        }
        if (!flame.isPlaying)
        {
            if (lit)
            {
                flame.Play();
                //flame_light.gameObject.SetActive(true);
                 Collider collider = this.gameObject.GetComponent<Collider>();
                collider.enabled = false;
            }
        }
        }
   }

    

