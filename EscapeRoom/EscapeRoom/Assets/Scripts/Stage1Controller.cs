using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Controller : MonoBehaviour {

    public GameObject torchGroup;
    public bool lit_room;
    public magicCircle mc;
    public bool s1Passed = false;
    public MagicCrystal waterStone;

    public Light l1;
    public Light l2;
    public Light l3;
    public Light l4;

	// Use this for initialization
	void Start () {
        StartCoroutine(FirstPuzzle());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator FirstPuzzle()
    {
        while (!lit_room)
        {
            bool lit = true;
            var torchs = torchGroup.GetComponentsInChildren<Candle>();
            foreach (Candle t in torchs)
            {
               lit &= t.lit;
            }

            lit_room = lit;

            if (torchs[0].lit && !torchs[0].added)
            {
                l1.intensity += 0.5f;
               torchs[0].added = true;
            }

            if (torchs[1].lit && !torchs[1].added)
            {
                l2.intensity += 0.5f;
                torchs[1].added = true;
            }
            if (torchs[2].lit && !torchs[2].added)
            {
                l3.intensity += 0.5f;
                torchs[2].added = true;
            }
            if (torchs[3].lit && !torchs[3].added)
            {
                l4.intensity += 0.5f;
                torchs[3].added = true;
            }
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);

        mc.gameObject.SetActive(true);
        
        
    }
}
