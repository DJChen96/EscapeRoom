using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinController : MonoBehaviour {

    public GameObject big_pumkin;
    private bool isRunning = false;
    public float waitingTime = 5f;
    // Use this for initialization
    void Start () {
        //StartCoroutine(Pumpkin_growth_animation());
        Pumpkin_growth();
    }


    public void Pumpkin_growth ()
    {
       //StartCoroutine(Pumpkin_growth_animation());
    }

    // Update is called once per frame
    void Update () {
		
	}
    IEnumerator Pumpkin_growth_animation()
    {
        isRunning = true;
        while (true)
        {
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, big_pumkin.transform.localScale, Time.deltaTime * 0.5f);
            this.transform.position = Vector3.Lerp(this.transform.position, big_pumkin.transform.position, Time.deltaTime * 0.5f);
            yield return null;
            if (Vector3.Distance(this.transform.localScale, big_pumkin.transform.localScale) +
                Vector3.Distance(this.transform.position, big_pumkin.transform.position) < 1f)
                break;
        }
        isRunning = false;
        big_pumkin.SetActive(true);
        StartCoroutine(Big_Pumpkin_Destory());
        this.gameObject.GetComponent<Renderer>().enabled = false;
    }
    IEnumerator Big_Pumpkin_Destory()
    {
        yield return new WaitForSeconds(waitingTime);
        Destroy(big_pumkin.gameObject);
        Destroy(this.gameObject);
    }
}
