using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinCarriageController : MonoBehaviour {

    public GameObject pumpkin;
	// Use this for initialization
	void Start () {
		
	}
	
    public void carriageChange()
    {
        pumpkin.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
