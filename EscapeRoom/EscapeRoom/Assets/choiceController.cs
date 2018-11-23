using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choiceController : MonoBehaviour {

    public wandController wc;

    public int index = 0;

    // Use this for initialization
    void Start () {
        wc = FindObjectOfType<wandController>();

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        print("-----------------------------------");
        if (other.tag.Equals("wand")) {
            wc.magic_mode[index] = true;
            for (int i = 0; i < wc.magic_mode.Length; i++) {
                if (i != index) {
                    wc.magic_mode[i] = false;
                }
            }
        }
    }


}
