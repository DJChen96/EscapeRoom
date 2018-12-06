using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Controller : MonoBehaviour {

    public GameObject torchGroup;
    public bool lit_room = false;
    //public magicCircle mc;
    public bool s1Passed = false;
    public MagicCrystal waterStone;

    public Candle candle;

    public Light l1;
    public Light l2;
    public Light l3;
    public Light l4;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (candle.lit && !lit_room) {
            var torchs = torchGroup.GetComponentsInChildren<Candle>();
            foreach (Candle t in torchs) {
                t.lit = true;
            }
            l1.intensity = 0.5f;
            l2.intensity = 0.5f;
            l3.intensity = 0.5f;
            l4.intensity = 0.5f;
            waterStone.gameObject.SetActive(true);
            lit_room = true;
        }
	}

    //IEnumerator FirstPuzzle()
    //{
    //    while (!candle.lit)
    //    {
    //        
    //        yield return null;
    //    }

    //    yield return new WaitForSeconds(2.0f);

    //    
        
        
    //}
}
