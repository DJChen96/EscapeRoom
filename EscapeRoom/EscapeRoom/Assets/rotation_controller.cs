using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_controller : MonoBehaviour {

    public bool attached;
    public Transform wand;
    public GameObject second;

    public clock clockPrefab;
    Vector3 oldEuler;

	// Use this for initialization
	void Start () {
        attached = false;
        second = transform.parent.gameObject;
        oldEuler = this.transform.parent.parent.eulerAngles;
    }
	
	// Update is called once per frame
	void Update () {
        rotate_wand();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("wand"))
        {
            if (Input.GetMouseButton(1) && !this.attached)
            {
                clockPrefab.controlled = true;
                this.attached = true;
                wand = other.gameObject.transform;
            }
            
        }
        else
            Debug.Log("null wand prefab");
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag.Equals("wand") && this.attached)
    //    {
    //        Debug.Log("Leaving timeMagic");
    //        wand = null;
    //        this.attached = false;
    //        clockPrefab.controlled = false;
    //    }
    //}

    private void rotate_wand()
    {
       
        if (this.attached && wand!=null)
        {
            this.transform.position = new Vector3(wand.position.x, wand.position.y);
            this.transform.parent.parent.up = new Vector3(wand.position.x - this.transform.parent.parent.position.x, wand.position.y - this.transform.parent.parent.position.y);

            clockPrefab.deltaEuler = (-this.transform.parent.parent.eulerAngles.z + oldEuler.z);
            oldEuler = this.transform.parent.parent.eulerAngles;
           
           
        }

    }

}
