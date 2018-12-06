using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Stage5Controller : MonoBehaviour {

    public GameObject[] completeObjectsBeforeMirrorBreak;
    public GameObject brokenObjectsAfterMirrorBreak;
    public GameObject completeObjectsAfterMirrorBreak;
    public GameObject swordBreak;
    public bool debug_triger = false;
    public AudioClip breakAudioClip;
    public SoundEffectAudioSource soundEffectAudioSource;

    public GameObject teleportArea;

    // Use this for initialization
    void Start () {
		
	}

    public void MirrorBreak ()
    {
        if (GameObject.Find("Highlighter")) {
            GameObject highlighter = GameObject.Find("Highlighter");
            Destroy(highlighter);
        }

        soundEffectAudioSource.Play(breakAudioClip);
        brokenObjectsAfterMirrorBreak.SetActive(true);
        completeObjectsAfterMirrorBreak.SetActive(true);
        if (swordBreak) swordBreak.SetActive(true);
        for (int i=0; i < completeObjectsBeforeMirrorBreak.Length; i++)
        {
            //if (completeObjectsBeforeMirrorBreak[i].gameObject.GetComponent<Interactable>()) {
            //    completeObjectsBeforeMirrorBreak[i].GetComponent<Interactable>().highlightOnHover = false;
            //    //If it could find an interactable component of objects we want to delete, set the highlight Hover
            //    // To false, then delete.
            //}
            if (GameObject.Find("Highlighter"))
            {
                GameObject highlighter = GameObject.Find("Highlighter");
                Destroy(highlighter);
            }
            Destroy(completeObjectsBeforeMirrorBreak[i]);
        }

        teleportArea.SetActive(true);
        StartCoroutine(Broken_obj_disappear());
    }

    // Update is called once per frame
    void Update()
    {

        if (debug_triger == true && gameController.debugMode == true)
        {
            MirrorBreak();
        }
    }
    IEnumerator Broken_obj_disappear()
    {
        yield return new WaitForSeconds(3f);

        //Destroy(brokenObjectsAfterMirrorBreak);
        Destroy(this);

    }
}
