using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snitch : MonoBehaviour {

    public GameObject stone;
	// Use this for initialization
	void Start () {
        StoneApear();

    }
	
    public void StoneApear()
    {
        stone.SetActive(true);
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
