using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicCircle : MonoBehaviour {

    public fireStone fs;
    public bool fire = false;
    public GameObject waterStone;

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
            Instantiate(waterStone, this.transform.position+new Vector3(0.0f,1.0f, 0.0f), this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
