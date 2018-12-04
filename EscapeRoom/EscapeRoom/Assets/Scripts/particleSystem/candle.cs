using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour {

    public ParticleSystem flame;
    public bool lit;
    public bool added = false;//This is the variable to tell game controller that if it is already counted into the light intensity or not.

	// Use this for initialization
	void Start () {
        flame = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update() {
        if (!flame.isPlaying)
        {
            if (lit)
            {
                flame.Play();
                //flame_light.gameObject.SetActive(true);
                //Collider collider = this.gameObject.GetComponent<Collider>();
                //collider.enabled = false;
            }
        }
    }
   
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag.Equals("FireMagic")&&!lit ) {
           
            lit = true;
        }
    }
}

    

