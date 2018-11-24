using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5Controller : MonoBehaviour {

    public GameObject[] completeObjectsBeforeMirrorBreak;
    public GameObject brokenObjectsAfterMirrorBreak;
    public GameObject completeObjectsAfterMirrorBreak;
    public bool debug_triger = false;
    // Use this for initialization
    void Start () {
		
	}

    public void MirrorBreak ()
    {

        brokenObjectsAfterMirrorBreak.SetActive(true);
        completeObjectsAfterMirrorBreak.SetActive(true);

        for (int i=0; i < completeObjectsBeforeMirrorBreak.Length; i++)
        {
            Destroy(completeObjectsBeforeMirrorBreak[i]);
        }


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
