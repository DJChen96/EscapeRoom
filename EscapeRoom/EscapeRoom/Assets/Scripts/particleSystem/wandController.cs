using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wandController : MonoBehaviour {

    public playerController pc;
    public GameObject firePrefab;
    public bool fire_generated = false;

    public GameObject thunderPrefab;
    public bool thunder_generated = false;

    public GameObject timePrefab;
    public bool time_generated = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void FixedUpdate()
    {
        castingMagic();

        
    }

    void castingMagic() {
        if (pc.firemode)
            castingFire();
        else if (pc.thundermode)
            castingThunder();
        else if (pc.timemode)
            castingTime();
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

    void castingTime() {
        if (pc.time_triggered && !time_generated && pc.timemode)
        {
            if (timePrefab != null)
            {
                print("TIME GENERATED");
                Instantiate(timePrefab, transform.position + 5.0f*transform.forward + 5.0f*transform.up, pc.transform.rotation);
                time_generated = true;
            }
            else
                print("NULL TIME PREFAB");
        }
        else if (!time_generated)
        {
            time_generated = false;
        }
    }
}
