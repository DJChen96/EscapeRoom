using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetClockTime : MonoBehaviour {
    //public static bool time_stop = false;
    public GameObject centre;
    public GameObject hour_hand;
    public GameObject minute_hand;
    public float minute_float;

    private Vector3 cenre_position;
    // Use this for initialization
    void Start () {
        cenre_position = centre.transform.position;
        zeroing();

        hour_hand.transform.RotateAround(cenre_position, new Vector3(0, 0, 1), minute_float *0.5f );
        minute_hand.transform.RotateAround(cenre_position, new Vector3(0, 0, 1), minute_float * 6);
    }
	
	// Update is called once per frame
	void Update () {
        //if (time_stop) return;

        minute_float += Time.deltaTime / 60;
        hour_hand.transform.RotateAround(cenre_position, new Vector3(0,0,1), (0.1f/12f)* Time.deltaTime);
        minute_hand.transform.RotateAround(cenre_position, new Vector3(0, 0, 1), 0.1f * Time.deltaTime);
    }

    void zeroing()
    {
        //Zeroing 
        hour_hand.transform.RotateAround(cenre_position, new Vector3(0, 0, 1), 70);
        minute_hand.transform.RotateAround(cenre_position, new Vector3(0, 0, 1), 103);
    }
}
