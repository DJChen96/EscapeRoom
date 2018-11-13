using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactItem : MonoBehaviour {

    public playerController player;
   // public Transform playerCam;

    bool hasPlayer;
    public bool beingCarried = false;
    public float dist_threshold = 1.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        RangeTest();
        PickUp();
    }

    void RangeTest() {
        if (Vector3.Distance(player.transform.position, this.transform.position) < dist_threshold)
        {
            Debug.Log("with in range");
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
    }

    void PickUp() {
        if ( !beingCarried && hasPlayer && Input.GetKeyDown(KeyCode.F)) {
            //Debug.Log("pick up"+ this.gameObject.name);
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = player.transform;
            player.carryItem = this;
            beingCarried = true;
        }

        else if (beingCarried && Input.GetKeyDown(KeyCode.F)) {
            //Debug.Log("drop" + this.gameObject.name);
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
            beingCarried = false;
        }
    }
}
