using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class BookBody : MonoBehaviour {

    Book book;
    public int index;
	// Use this for initialization
	void Start () {
        book = FindObjectOfType<Book>();
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.GetComponent<Interactable>().wasHovering)
        {
            // Debug.Log("____________book"+ index+"_________________");
            if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                if (index == 0)
                    book.NextPage();
                if (index == 1)
                    book.PrePage();
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    
}
