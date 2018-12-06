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
        Quaternion q = new Quaternion(wc.transform.parent.rotation.x, wc.transform.parent.rotation.y, wc.transform.parent.rotation.z, wc.transform.parent.rotation.w);
        this.transform.rotation = q;
        this.transform.position = wc.transform.position + new Vector3(0f, 0.03f, 0f);
	}

    void checkStatus() {
        if (!wc.waterEnabled)
        {
            Quaternion q = new Quaternion(0f,0f,0f,0f);
            Instantiate(unknown, water.position, q, water);
        }
        else {
            Debug.Log(wc.waterEnabled);
            //Instantiate(waterPre, water.position, water.rotation, water);
            waterPre.SetActive(true);
        }

        if (!wc.timeEnabled)
        {
            Quaternion q = new Quaternion(0f, 0f, 0f, 0f);
            Instantiate(unknown, time.position, q, water);
            //Instantiate(unknown, time.position, unknown.transform.rotation, time);
        }
        else
        {
            Debug.Log(wc.timeEnabled);
            Instantiate(timePre, time.position, time.rotation, time);
        }

        if (!wc.growthEnabled)
        {
            Quaternion q = new Quaternion(0f, 0f, 0f, 0f);
            Instantiate(unknown, growth.position, q, water);
        }
        else
        {
            Debug.Log(wc.growthEnabled);
            Instantiate(growthPre, growth.position, growth.rotation, growth);
        }

        Instantiate(firePre, fire.position, fire.rotation, fire);
    }


}
