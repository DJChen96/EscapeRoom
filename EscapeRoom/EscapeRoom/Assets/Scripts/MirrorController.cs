using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorController : MonoBehaviour {

    public AudioClip[] stageAudioClip;
    public GameObject masksUp;
    public GameObject masksDown;
    public AudioSource audioSource;
    private int stage = 0;
    private bool speaking = false;

    private Vector3[] originPosition = new Vector3[2];
    // Use this for initialization
    void Start () {
        originPosition[0] = masksUp.transform.position;
        originPosition[1] = masksDown.transform.position;


    }
	
    public void SetStage (int _stage)
    {
        this.stage = _stage;
        MirrorSpeak();

    }

    
    public void MirrorSpeak()
    {
        if (speaking) return;

        if (stage == 0 || stage > 5) return;

        audioSource.clip = stageAudioClip[stage-1];
        audioSource.Play();
        speaking = true;

    }


	// Update is called once per frame
    private float mask_mouth_moving_time = 0;
	void Update () {
        if (!audioSource.isPlaying && speaking)
        {
            speaking = false;
        }

        if (speaking)
        {
            mask_mouth_moving_time += Time.deltaTime * 10f;

            //masksUp.transform.position = new Vector3(originPosition[0].x, originPosition[0].y + 0.01f + 0.02f *Mathf.Sin(mask_mouth_moving_time), originPosition[0].z);
            //masksDown.transform.position = new Vector3(originPosition[0].x, originPosition[0].y - 0.01f - 0.02f * Mathf.Sin(mask_mouth_moving_time), originPosition[0].z);
            masksUp.transform.position = new Vector3(originPosition[0].x, originPosition[0].y + 0.02f, originPosition[0].z);
            masksDown.transform.position = new Vector3(originPosition[1].x, originPosition[1].y - 0.02f, originPosition[1].z);
        }
        else
        {
            masksUp.transform.position = originPosition[0];
            masksDown.transform.position = originPosition[1];
        }



        if (gameController.debugMode == false)
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
}
