using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage6Controller : MonoBehaviour {

    public Monster monster;
    public GameObject teleport_s6;
    public bool kissed = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (monster != null && monster.dead) {
            teleport_s6.SetActive(true);
            GameObject.Destroy(monster.gameObject);
            monster = null;
        }
	}
}
