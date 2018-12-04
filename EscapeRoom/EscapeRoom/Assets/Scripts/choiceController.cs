using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choiceController : MonoBehaviour {

    public wandController wc;

    public Transform fire;
    public Transform water;
    public Transform growth;
    public Transform time;

    public GameObject firePre;
    public GameObject waterPre;
    public GameObject growthPre;
    public GameObject timePre;

    public GameObject unknown;


    // Use this for initialization
    void Start () {
        wc = FindObjectOfType<wandController>();
        checkStatus();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void checkStatus() {
        if (!wc.waterEnabled)
        {
            Instantiate(unknown, water.position, unknown.transform.rotation, water);
        }
        else {
            Debug.Log(wc.waterEnabled);
            //Instantiate(waterPre, water.position, water.rotation, water);
            waterPre.SetActive(true);
        }

        if (!wc.timeEnabled)
        {

            Instantiate(unknown, time.position, unknown.transform.rotation, time);
        }
        else
        {
            Debug.Log(wc.timeEnabled);
            Instantiate(timePre, time.position, time.rotation, time);
        }

        if (!wc.growthEnabled)
        {
            Instantiate(unknown, growth.position, unknown.transform.rotation, growth);
        }
        else
        {
            Debug.Log(wc.growthEnabled);
            Instantiate(growthPre, growth.position, growth.rotation, growth);
        }

        Instantiate(firePre, fire.position, fire.rotation, fire);
    }


}
