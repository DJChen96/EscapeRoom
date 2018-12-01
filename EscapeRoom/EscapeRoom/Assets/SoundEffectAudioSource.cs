using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectAudioSource : MonoBehaviour {

    private bool isPlaying = false;
    public AudioSource audioSource;
	// Use this for initialization
	void Start () {
		
	}
	public void Play(AudioClip audioClip)
    {
        if (this.isPlaying)
            return;
        this.isPlaying = true;
        audioSource.clip = audioClip;
        audioSource.Play();
    } 
	// Update is called once per frame
	void Update () {
		if (!audioSource.isPlaying && this.isPlaying)
        {
            this.isPlaying = false;
        }
	}
}
