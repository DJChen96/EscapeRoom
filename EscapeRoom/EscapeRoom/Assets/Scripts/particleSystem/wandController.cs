using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wandController : MonoBehaviour {

    public playerController pc;
    public GameObject firePrefab;
    public bool fire_generated = false;

    public GameObject thunderPrefab;
    public bool thunder_generated = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void FixedUpdate()
    {
        castingFire();
        castingThunder();
    }

    void castingFire() {
        if (pc.fire_inCD && !fire_generated && pc.firemode)
        {
            if (firePrefab != null)
            {
                Instantiate(firePrefab, transform.position, pc.transform.rotation, this.transform);
                fire_generated = true;
            }
            else
                print("NULL FIRE PREFAB");
        }
        else if (!pc.fire_inCD)
        {
            fire_generated = false;
        }
    }

    void castingThunder()
    {
        if (pc.thunder_inCD && !thunder_generated && pc.thundermode)
        {
            if (thunderPrefab != null)
            {
                print("THUNDER GENERATED");
                Instantiate(thunderPrefab, transform.position, pc.transform.rotation, this.transform);
                thunder_generated = true;
            }
            else
                print("NULL THUNDER PREFAB");
        }
        else if (!pc.thunder_inCD)
        {
            thunder_generated = false;
        }
    }
}
