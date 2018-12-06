using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class magicCircle : MonoBehaviour {
    
    public bool fire = false;
    public GameObject waterStone;
    //public Interactable fireStone;
   // public ParticleSystem ps;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Check particle see if it is about to die.
        //if (!ps.IsAlive(true)) {
        //    Destroy(this.gameObject);
        //}	
	}

    private void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.tag.Equals("FireStone") ) {
        //    if (GameObject.Find("Highlighter"))
        //    {
        //        GameObject highlighter = GameObject.Find("Highlighter");
        //        Destroy(highlighter);
        //    }
        //    if(other.gameObject.GetComponent<Interactable>())
        //        other.gameObject.GetComponent<Interactable>().highlightOnHover = false;
        //    //fire = true;
        //    //Instantiate(waterStone, this.transform.position+new Vector3(0.0f,1.0f, 0.0f), this.transform.rotation, this.transform.parent);
        //    if(!waterStone.activeInHierarchy)
        //        waterStone.SetActive(true);
        //    //ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        //    Destroy(other.gameObject);
        //}
    }
}
