using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3Controller : MonoBehaviour {

    public MistletoeGrowthController mgc;
    public bool stage3Passed = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag.Equals("growthMagic")) {
            mgc.Plant_growth();
            stage3Passed = true;
        }
    }
}
