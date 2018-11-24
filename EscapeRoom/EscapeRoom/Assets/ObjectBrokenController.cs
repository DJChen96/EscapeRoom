using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBrokenController : MonoBehaviour {

    public GameObject completeObj;
    public GameObject brokenObj;
    private float waitingTime = 3f;
    public bool debug_triger = false;

	// Use this for initialization
	void Start () {
 
    }

    public void Break()
    {

        brokenObj.SetActive(true);

        Destroy(completeObj.gameObject);
        StartCoroutine(Broken_box_disappear());
    }


    // Update is called once per frame
    void Update () {
		
        if (debug_triger == true && gameController.debugMode ==true)
        {
            Break();
        }
	}
    IEnumerator Broken_box_disappear()
    {
        yield return new WaitForSeconds(waitingTime);
        Destroy(brokenObj.gameObject);
        Destroy(this.gameObject);
    }
}
