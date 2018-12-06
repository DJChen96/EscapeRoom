using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class MagicCrystal : MonoBehaviour {

    //[Tooltip("The index of the magic in the magic array")]
    public int index;

    private Book book;
    private MirrorController mirrorController;

    public bool absorbed = false;
    public ParticleSystem deadEffect;
    public ParticleSystem flareEffect;
    public GameObject aura;

    private int shaderProperty;
    public Material dissolve;

    //public ParticleSystem absorbSystem;
    private SoundEffectAudioSource soundEffectAudio;
    public AudioClip sound;
    wandController wc;

    public Interactable interactable;

	// Use this for initialization
	void Start () {

        shaderProperty = Shader.PropertyToID("_cutoff");
        soundEffectAudio = FindObjectOfType<SoundEffectAudioSource>();
        wc = FindObjectOfType<wandController>();
        book = FindObjectOfType<Book>();
        mirrorController = FindObjectOfType<MirrorController>();

        interactable = this.gameObject.GetComponent<Interactable>();
        aura.SetActive(true);
    }


    
    private void OnDestroy()
    {
        //Debug.Log(index);
        if (book)
            book.SetStage(index + 2);
        mirrorController.SetStage(index + 2);
        
        if (GameObject.Find("Highlighter"))
        {
            GameObject highlighter = GameObject.Find("Highlighter");
            Destroy(highlighter);
        }
    }
    // Update is called once per frame
    void Update () {

        if (interactable) {
            if (interactable.wasHovering && !absorbed) {
                if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
                 {
                    Debug.Log("Absorbed");
                    if (GameObject.Find("Highlighter"))
                    {
                        GameObject highlighter = GameObject.Find("Highlighter");
                        Destroy(highlighter);
                    }
                    interactable.highlightOnHover = false;
                    this.gameObject.GetComponent<Collider>().enabled = false;
                    //this.gameObject.GetComponent<Rigidbody>().enabled = false;
                    AbsorbMagic(1f);
                    absorbed = true;
                }
            }
        }
        
	}

    public void AbsorbMagic(float waitTime)
    {
        wandController wc1 = FindObjectOfType<wandController>();
        wc1.Haptics(20f);
        if (soundEffectAudio && sound)
            soundEffectAudio.Play(sound);
        //Animation will invoke this method so that it will start coroutine to destroy crystal.
        StartCoroutine(CrystalDissolve(waitTime));
    }

    IEnumerator CrystalDissolve(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        //SteamVR_Input.actions.
        //absorbed = true;
        if (index == 0)
        {
            wc.waterEnabled = true;
            wc.waterMode = true;
            wc.fireMode = false;
            wc.growthMode = false;
            wc.timeMode = false;
        }

        else if (index == 1)
        {
            wc.growthEnabled = true;
            wc.waterMode = false;
            wc.fireMode = false;
            wc.growthMode = true;
            wc.timeMode = false;
        }

        else if (index == 2)
        {
            wc.timeEnabled = true;
            wc.waterMode = false;
            wc.fireMode = false;
            wc.growthMode = false;
            wc.timeMode = true;
        }

        deadEffect.Play();

        //absorbSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        this.GetComponent<Renderer>().material = dissolve;

        float cutoff = 0;

        while (cutoff < 1)
        {
            cutoff += Time.deltaTime * 0.25f;
            this.gameObject.GetComponent<Renderer>().material.SetFloat(shaderProperty, cutoff);
            yield return null;
        }

        flareEffect.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        deadEffect.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        while(deadEffect.IsAlive(true)){
            yield return null;
        }
        if (aura.GetComponentInChildren<ParticleSystem>()) {
            ParticleSystem auraGroup = aura.GetComponentInChildren<ParticleSystem>();
            auraGroup.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
        aura.SetActive(false);
        Destroy(this.gameObject);

    }
}
