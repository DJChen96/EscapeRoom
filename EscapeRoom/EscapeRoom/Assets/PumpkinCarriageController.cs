using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinCarriageController : MonoBehaviour
{

    public GameObject pumpkin;
    public GameObject small_carriage;
    // Use this for initialization
    private bool isRunning = false;


    private void Start()
    {
       //StartCoroutine(Carriage_shrink());
    }

    public void CarriageChange()
    {
        StartCoroutine(Carriage_shrink());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Carriage_shrink()
    {
        isRunning = true;
        while (true)
        {
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, small_carriage.transform.localScale, Time.deltaTime * 0.5f);
            this.transform.position = Vector3.Lerp(this.transform.position, small_carriage.transform.position, Time.deltaTime * 0.5f);
            yield return null;
            if (Vector3.Distance(this.transform.localScale, small_carriage.transform.localScale) +
                Vector3.Distance(this.transform.position, small_carriage.transform.position) < 0.5f)
                break;
        }
        isRunning = false;
        pumpkin.SetActive(true);
        Destroy(this.gameObject);
    }
}

