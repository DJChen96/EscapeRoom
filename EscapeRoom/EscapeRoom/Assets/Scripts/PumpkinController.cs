using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinController : MonoBehaviour
{

    public GameObject big_pumkin;
    private bool isRunning = false;
    public float waitingTime = 5f;
    public SoundEffectAudioSource soundEffectAudioSource;
    public AudioClip audio;
    public bool debug_triger = false;

    private bool pumpkinGrowthed = false;

    public GameObject sword;

    private bool breaked = false;
    // Use this for initialization
    void Start()
    {
        //StartCoroutine(Pumpkin_growth_animation());
        Pumpkin_growth();
    }


    public void Pumpkin_growth()
    {
        if (isRunning || pumpkinGrowthed) return;

        this.gameObject.GetComponent<Collider>().enabled = false;
        StartCoroutine(Pumpkin_growth_animation(soundEffectAudioSource, audio));
        pumpkinGrowthed = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (debug_triger == true && gameController.debugMode == true)
        {
            Pumpkin_growth();
        }

    }
    IEnumerator Pumpkin_growth_animation(SoundEffectAudioSource soundEffectAudioSource, AudioClip audio)
    {

        isRunning = true;
        while (true)
        {
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, big_pumkin.transform.localScale, Time.deltaTime * 0.35f);
            this.transform.position = Vector3.Lerp(this.transform.position, big_pumkin.transform.position, Time.deltaTime * 0.35f);
            yield return null;
            if (Vector3.Distance(this.transform.localScale, big_pumkin.transform.localScale) +
                Vector3.Distance(this.transform.position, big_pumkin.transform.position) < 0.3f)
                break;
        }
        isRunning = false;

        soundEffectAudioSource.Play(audio);
        big_pumkin.SetActive(true);
        sword.SetActive(true);
        StartCoroutine(Big_Pumpkin_Destory());

        this.gameObject.GetComponent<Renderer>().enabled = false;

    }
    IEnumerator Big_Pumpkin_Destory()
    {
        yield return new WaitForSeconds(waitingTime);
        Destroy(big_pumkin.gameObject);
        Destroy(this.gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag.Equals("GrowthMagic") && !isRunning)
        {

            Debug.Log("GROW");
            Pumpkin_growth();

        }
    }
}
