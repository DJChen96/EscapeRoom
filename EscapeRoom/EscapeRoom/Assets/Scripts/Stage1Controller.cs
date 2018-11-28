using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Controller : MonoBehaviour {

    public GameObject torchGroup;
    public bool lit_room;
    public magicCircle mc;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator FirstPuzzle()
    {

        print("Hi adventurer, nice to meet you in this dark, dark room, use fire to burn the darkness!");


        var torchs = torchGroup.GetComponentsInChildren<candle>();
        foreach (candle t in torchs)
        {
            lit_room &= t.lit;
        }
        while (!lit_room)
        {
            yield return null;

        }

        yield return new WaitForSeconds(2.0f);

        mc.gameObject.SetActive(true);

        while (mc != null && !mc.fire)
        {
            yield return null;
        }


        mc = null;


        yield return new WaitForSeconds(1.0f);
        Debug.Log("------------FIRST PUZZLE PASSED------------");


    }
}
