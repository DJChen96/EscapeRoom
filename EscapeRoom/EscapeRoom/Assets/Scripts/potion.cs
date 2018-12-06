using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Valve.VR.InteractionSystem;

public class potion : MonoBehaviour
{

    ParticleSystem ps;
    public Interactable int_gameObject;

    public GameObject mermaid_transform;

    // @Author Xiaotog Bao
    public GameObject cap;
    public AudioSource potionSpeaker;
    private float MAX_flowingTime = 4;
    private float flowingTime = 0;

    public MermaidController mc;

    private Vector3 originalPos;
    private Quaternion originalRot;
    private Vector3 originalScale;

    private bool previous_attached;
    // Use this for initialization
    void Start()
    {
        originalScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        originalRot = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);

        mc = FindObjectOfType<MermaidController>();
        ps = GetComponentInChildren<ParticleSystem>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Angle(this.transform.up, new Vector3(0, 1, 0)) > 85.0f && flowingTime < MAX_flowingTime)
        {

            ps.Play();
            // @Author Xiaotog Bao
            potionSpeaker.Play();
            cap.SetActive(false);
            flowingTime = flowingTime + Time.deltaTime;
        }
        else if (Vector3.Angle(this.transform.up, new Vector3(0, 1, 0)) <= 85.0f)
        {
            cap.SetActive(true);
            flowingTime = 0;
            potionSpeaker.Stop();
            ps.Stop();
        }
        else
        {

            ps.Stop();

            // @Author Xiaotog Bao
            potionSpeaker.Stop();
            cap.SetActive(true);

        }

        bool Attach = int_gameObject.attachedToHand != null;
        if (!Attach && previous_attached)
        {
            //Debug.Log("----interactable_object.attachedToHand == null----");
            if (GameObject.Find("Highlighter"))
            {
                GameObject highlighter = GameObject.Find("Highlighter");
                Destroy(highlighter);
            }

            this.transform.position = originalPos;
            this.transform.rotation = originalRot;
            this.transform.localScale = originalScale;

            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        }

        previous_attached = Attach;

        //if (mc.mermaidWatered && !mc.speaking)
        //{
        //    if (Vector3.Distance(mermaid_transform.transform.position, this.transform.position) < 0.6f) {
        //        if (this.gameObject.tag.Equals("splitPotion"))
        //        {
        //            Debug.Log("DISTANCE----Split");
        //            mc.MermaidDispearSet[0] = 1;
        //        }
        //        else if (this.gameObject.tag.Equals("lovePotion")) {
        //            Debug.Log("DISTANCE----Love");
        //            mc.audioSource.clip = mc.mermailAudios[2];
        //            mc.audioSource.Play();
        //        }


        //        else if (this.gameObject.tag.Equals("truthSerum")) {
        //            Debug.Log("DISTANCE----Truth");
        //            mc.audioSource.clip = mc.mermailAudios[1];
        //            mc.audioSource.Play();
        //        }

        //    }
        //}

    }


}

