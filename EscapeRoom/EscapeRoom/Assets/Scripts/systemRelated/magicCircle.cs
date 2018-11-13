using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicCircle : MonoBehaviour {

    public fireStone fs;
    public bool fire = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("FireStone") && !fs.beingCarried) {
            
            fire = true;
            Destroy(this.gameObject);
        }
    }
}
