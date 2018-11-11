using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lock_test : MonoBehaviour {
    
    public Transform transform_controlled;
    private bool opened = false;

	// Use this for initialization
	void Start () {
        opened = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (opened && transform_controlled != null) {
            transform_controlled.transform.Translate(0f,0f,0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (transform_controlled != null)
            {
                opened = true;
            }
        }
    }


}
