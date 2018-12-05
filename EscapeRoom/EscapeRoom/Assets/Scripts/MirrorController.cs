using RogoDigital.Lipsync;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class MirrorController : MonoBehaviour {

    public LipSyncData[] lipSyncDatas;
    public GameObject mirror_head;
    public Transform mirror_head_appear;
    public Transform mirror_head_disappear;
    public LipSync lipSync;

    private int stage = 1;
    public bool speaking = false;

    public bool isRunning = false;

    public bool HeadAppear = false;
    public bool HeadDisappear = false;
    void Start () {
    }
	
    public void SetStage (int _stage)
    {
        this.stage = _stage;
        MirrorSpeak();
    }

    
    public void MirrorSpeak()
    {
        if (speaking)
            return;

        if (stage == 0 || stage > 5)
            return;

        HeadAppear = true;
        
    }


    // Update is called once per frame
    private float mask_mouth_moving_time = 0;
	void Update () {


        if (this.gameObject.GetComponent<Interactable>())
        {
            //Debug.Log("FOUND INTERACTABLE COMPONENT");
            if (this.gameObject.GetComponent<Interactable>().wasHovering)
            {
                Debug.Log("____________mirror" + "_________________");
                if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
                {
                    MirrorSpeak();
                }
            }
        }



        if (!lipSync.IsPlaying && speaking && !HeadAppear)
        {
            HeadDisappear = true;
        }
         
        if (HeadAppear)
        {
            speaking = true;
            mirror_head.transform.position =
            Vector3.Lerp(mirror_head.transform.position, mirror_head_appear.position, Time.deltaTime * 2.5f);
            if (Vector3.Distance(mirror_head.transform.position, mirror_head_appear.position) < 0.01f)
            {
                HeadAppear = false;
                lipSync.Play(lipSyncDatas[stage - 1]);
                
            }
        }

        if (HeadDisappear)
        {
            mirror_head.transform.position =
                Vector3.Lerp(mirror_head.transform.position, mirror_head_disappear.position, Time.deltaTime * 2.5f);
            if (Vector3.Distance(mirror_head.transform.position, mirror_head_disappear.position) < 0.01f)
            {
                HeadDisappear = false;
                speaking = false;
            }

        }

        if (gameController.debugMode == false || true)
            return;

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            SetStage(1);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            SetStage(2);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            SetStage(3);
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            SetStage(4);
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            SetStage(5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("sword")) {
            Stage5Controller s5controller = FindObjectOfType<Stage5Controller>();
            s5controller.MirrorBreak();

        }
    }

}
