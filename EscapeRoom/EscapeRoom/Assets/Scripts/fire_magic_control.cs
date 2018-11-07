using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_magic_control : MonoBehaviour {
    private ParticleSystem ps;
   
    // Use this for initialization
    void Start () {
        //print("SUCCESSFULLY INSTANSTIATED");
        ps = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpate() {
        if (ps != null && !ps.isPlaying)
        {
            print("IS FIRING");
            ps.Play();
        }
        if (!ps.IsAlive())
        {
            print("Destroyed Magic");
            Destroy(this.gameObject);
        }
    }
}
